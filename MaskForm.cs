using OpenCvSharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace VideoMotionDetect
{
	public partial class MaskForm : Form
	{
		private const int BRUSH_SIZE_MIN = 1;
		private const int BRUSH_SIZE_MAX = 1000;

		private int m_CurrentBrushSize = -1;

		private bool m_MarkTool = false;
		private bool m_IsDrawing = false;
		private bool m_DidDraw = false;

		private int m_DrawStartX = -1;
		private int m_DrawStartY = -1;

		private Mat m_Frame = null;
		private Mat m_ROI = null;
		private Mat m_Merged = null;


		public MaskForm(string videoFile)
		{
			if (videoFile == null)
				throw new ArgumentNullException("input_file");

			if (!File.Exists(videoFile))
				throw new FileNotFoundException("Input file was not found.");

			InitializeComponent();

			using (VideoCapture capture = new VideoCapture(videoFile))
			{
				if (!capture.IsOpened())
					throw new InvalidDataException("Video file could not be opened.");

				if (!capture.Grab())
					throw new InvalidDataException("Could not grab first frame from video.");

				m_Frame = capture.RetrieveMat();

				capture.Release();
			}

			m_ROI = new Mat(m_Frame.Rows, m_Frame.Cols, MatType.CV_8UC3, 0);
			m_Merged = new Mat(m_Frame.Rows, m_Frame.Cols, MatType.CV_8UC3, 0);

			m_Frame.CopyTo(m_Merged);

			if (Properties.Settings.Default.BrushSize < BRUSH_SIZE_MIN ||
				Properties.Settings.Default.BrushSize > BRUSH_SIZE_MAX)
			{
				Properties.Settings.Default.BrushSize = BRUSH_SIZE_MIN;
			}

			brushSizeToolStripComboBox.Text =
				Properties.Settings.Default.BrushSize.ToString(CultureInfo.InvariantCulture);

			if (Properties.Settings.Default.DisplayMode < 0 ||
				Properties.Settings.Default.DisplayMode >= displayModeToolStripComboBox.Items.Count)
			{
				Properties.Settings.Default.DisplayMode = 0;
			}

			displayModeToolStripComboBox.SelectedIndex = Properties.Settings.Default.DisplayMode;

			markToolStripButton_Click(null, EventArgs.Empty);
		}
		private void TranslateCoordinates(int X, int Y, out int tX, out int tY)
		{
			switch (pictureBox.SizeMode)
			{
				case PictureBoxSizeMode.StretchImage:
					tX = (int)(m_Merged.Cols * X / (double)pictureBox.ClientSize.Width);
					tY = (int)(m_Merged.Rows * Y / (double)pictureBox.ClientSize.Height);
					break;
				default:
					tX = X;
					tY = Y;
					break;
			}
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			DialogResult ret =
				MessageBox.Show(this, Properties.Resources.NewROIPrompt,
				Properties.Resources.NewROITitle, MessageBoxButtons.YesNo,
				MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

			if (ret != DialogResult.Yes)
				return;

			m_ROI.SetTo(Scalar.Black);
			m_Frame.CopyTo(m_Merged);
			Cv2.AddWeighted(m_Frame, 1, m_ROI, 0.3, 0, m_Merged);
			pictureBox.Invalidate();
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			this.UseWaitCursor = true;
			toolStrip.Enabled = false;
			Application.DoEvents();

			Mat roiCurrent = m_ROI.Clone();

			try
			{
				ReadROIFile(openFileDialog.FileName);
			}
			catch (Exception ex)
			{
				m_ROI.Release();
				m_ROI = roiCurrent;

				this.UseWaitCursor = false;

				MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
					Properties.Resources.OpenROIError, ex.Message),
					Properties.Resources.OpenROITitle,
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				goto done;
			}

			roiCurrent.Release();

			m_Frame.CopyTo(m_Merged);
			Cv2.AddWeighted(m_Frame, 1, m_ROI, 0.3, 0, m_Merged);

			pictureBox.Invalidate();

		done:
			this.UseWaitCursor = false;
			toolStrip.Enabled = true;
		}

		private void ReadROIFile(string file)
		{
			if (string.IsNullOrEmpty(file))
				throw new ArgumentNullException("file");

			using (FileStream fs = File.OpenRead(file))
			{
				using (BinaryReader br = new BinaryReader(fs, Encoding.UTF8, true))
				{
					if (br.ReadChar() != 'R')
						throw new InvalidDataException("Bad header 1.");
					if (br.ReadChar() != 'O')
						throw new InvalidDataException("Bad header 2.");
					if (br.ReadChar() != 'I')
						throw new InvalidDataException("Bad header 2.");

					int cols = br.ReadUInt16();
					int rows = br.ReadUInt16();

					if (cols != m_ROI.Cols || rows != m_ROI.Rows)
						throw new InvalidDataException("Dimensions of ROI file do not match current matrix.");
				}

				Vec3b vec = new Vec3b((byte)Scalar.Yellow.Val0, (byte)Scalar.Yellow.Val1, (byte)Scalar.Yellow.Val2);

				using (GZipStream gzs = new GZipStream(fs, CompressionMode.Decompress, true))
				{
					for (int x = 0; x < m_ROI.Cols; x++)
						for (int y = 0; y < m_ROI.Rows; y++)
						{
							int b = gzs.ReadByte();

							if (b == -1)
								throw new InvalidDataException("End of data while populating matrix.");

							if (b == 1)
								m_ROI.Set(y, x, vec);
						}
				}

				fs.Close();
			}
		}
		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			this.UseWaitCursor = true;
			toolStrip.Enabled = false;
			Application.DoEvents();

			try
			{
				WriteROIFile(saveFileDialog.FileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
					Properties.Resources.OpenROIError, ex.Message),
					Properties.Resources.OpenROITitle,
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				goto done;
			}

		done:
			this.UseWaitCursor = false;
			toolStrip.Enabled = true;
		}

		private void WriteROIFile(string file)
		{
			if (string.IsNullOrEmpty(file))
				throw new ArgumentNullException("file");

			/* The file format is as follows:
			 * 
			 * Header:
			 * Byte 0-3: Literal text "ROI"
			 * Byte 4-5: Two bytes for width (unsigned short)
			 * Byte 6-7: Two bytes for height (unsigned short)
			 * 
			 * Data:
			 * GZip compressed stream of the binary (monochrome) bitmap that
			 * represents the region of interest, scanline by scanline.
			 */

			using (FileStream fs = File.OpenWrite(file))
			{
				using (BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8, true))
				{
					bw.Write('R');
					bw.Write('O');
					bw.Write('I');
					bw.Write((ushort)m_ROI.Cols);
					bw.Write((ushort)m_ROI.Rows);
					bw.Flush();
				}

				using (GZipStream gzs = new GZipStream(fs, CompressionLevel.Optimal, true))
				{
					for (int x = 0; x < m_ROI.Cols; x++)
						for (int y = 0; y < m_ROI.Rows; y++)
						{
							if (m_ROI.At<int>(y, x) != 0)
								gzs.WriteByte(1);
							else
								gzs.WriteByte(0);
						}

					gzs.Flush();
				}

				fs.Close();
			}
		}

		private void markToolStripButton_Click(object sender, EventArgs e)
		{
			m_MarkTool = true;
			clearToolStripButton.Checked = false;
			markToolStripButton.Checked = true;
		}

		private void clearToolStripButton_Click(object sender, EventArgs e)
		{
			m_MarkTool = false;
			clearToolStripButton.Checked = true;
			markToolStripButton.Checked = false;
		}

		private void brushSizeToolStripComboBox_TextChanged(object sender, EventArgs e)
		{
			bool ok = int.TryParse(brushSizeToolStripComboBox.Text,
				NumberStyles.None, CultureInfo.InvariantCulture, out int size);

			if (!ok)
			{
				brushSizeToolStripComboBox.Text = "1";
				size = 1;
			}

			m_CurrentBrushSize = size;

			Properties.Settings.Default.BrushSize = size;
		}

		private void displayModeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int idx = displayModeToolStripComboBox.SelectedIndex;

		again:
			switch (idx)
			{
				default:
					Trace.Fail("Invalid mode selected.");
					idx = 0;
					goto again;
				case 0: // Stretch to window;
					pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
					pictureBox.Dock = DockStyle.Fill;
					break;
				case 1: // Actual pixels
					pictureBox.Dock = DockStyle.None;
					pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
					pictureBox.Width = m_Merged.Cols;
					pictureBox.Height = m_Merged.Rows;
					break;
			}

			Properties.Settings.Default.DisplayMode = idx;
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			m_DrawStartX = e.X;
			m_DrawStartY = e.Y;
			m_IsDrawing = true;
			m_DidDraw = false;
		}

		private void pictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (!m_IsDrawing)
				return;

			m_DidDraw = true;

			TranslateCoordinates(m_DrawStartX, m_DrawStartY, out int tx1, out int ty1);
			TranslateCoordinates(e.X, e.Y, out int tx2, out int ty2);

			Scalar color = m_MarkTool ? Scalar.Yellow : Scalar.Black;

			m_ROI.Line(tx1, ty1, tx2, ty2, color, m_CurrentBrushSize);

			m_DrawStartX = e.X;
			m_DrawStartY = e.Y;

			m_Frame.CopyTo(m_Merged);
			Cv2.AddWeighted(m_Frame, 1, m_ROI, 0.3, 0, m_Merged);

			// TODO: How do I get the bounding rectangle of m_ROI.Line without
			// allocating yet another Mat just for difference comparison?
			//
			// Invalidating the entire picture box on every stroke is slow.

			pictureBox.Invalidate();
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			if (!m_DidDraw)
			{
				// Fake a mouse move to make it draw something. This allows you
				// to click the mouse with a huge brush size and get a blob of
				// highlighter at that area.
				pictureBox_MouseMove(sender, e);
			}

			m_IsDrawing = false;
			m_DrawStartX = -1;
			m_DrawStartY = -1;
		}

		private void pictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (m_Merged == null)
			{
				e.Graphics.FillRectangle(SystemBrushes.Window, e.ClipRectangle);
				return;
			}

			// This is OK in the Paint event handler, because it just creates
			// a bitmap structure around the existing bytes in memory.
			//
			// BUG: It causes AccessViolationExceptions in DEBUG builds, but
			// not in RELEASE builds. WTF?
			using (Bitmap bmp = new Bitmap(m_Merged.Cols, m_Merged.Rows,
				(int)m_Merged.Step(), PixelFormat.Format24bppRgb, m_Merged.Ptr()))
			{
				if (pictureBox.SizeMode == PictureBoxSizeMode.AutoSize)
				{
					e.Graphics.DrawImage(bmp, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
					return;
				}

				int sX = (int)(m_Merged.Cols * e.ClipRectangle.X / (double)pictureBox.ClientSize.Width);
				int sY = (int)(m_Merged.Rows * e.ClipRectangle.Y / (double)pictureBox.ClientSize.Height);
				int sH = (int)(m_Merged.Cols * e.ClipRectangle.Width / (double)pictureBox.ClientSize.Width);
				int sW = (int)(m_Merged.Rows * e.ClipRectangle.Height / (double)pictureBox.ClientSize.Height);

				e.Graphics.DrawImage(bmp, e.ClipRectangle, sX, sY, sH, sW, GraphicsUnit.Pixel);
			}
		}

		private void finishedToolStripButton_Click(object sender, EventArgs e)
		{
			this.UseWaitCursor = true;
			toolStrip.Enabled = false;

			Application.DoEvents();

			Mat mask = m_ROI.InRange(Scalar.Yellow, Scalar.Yellow);
			m_ROI.SetTo(Scalar.White, mask);
			mask.Release();

			Cv2.CvtColor(m_ROI, m_ROI, ColorConversionCodes.RGB2GRAY);

			if (m_ROI.CountNonZero() == 0)
				goto emptyROI;

			// m_ROI.CountNonZero() != 0

			Mat nonzero = m_ROI.FindNonZero();
			RotatedRect rotatedrct = nonzero.MinAreaRect();
			Rect rct = rotatedrct.BoundingRect();

			// BoundingRect will do things like set rct.X to -1 or the
			// height and width larger than the frame if you highlight
			// the entire frame, e.g. with brush size 1000.
			if (rct.X < 0) rct.X = 0;
			if (rct.Y < 0) rct.Y = 0;
			if (rct.Width > m_ROI.Cols) rct.Width = m_ROI.Width;
			if (rct.Height > m_ROI.Rows) rct.Height = m_ROI.Height;

			bool roiSpansEntireFrame =
				rct.X == 0 &&
				rct.Y == 0 &&
				rct.Width == m_ROI.Cols &&
				rct.Height == m_ROI.Rows;

			if (!roiSpansEntireFrame)
			{
				Mat cropped = new Mat(m_ROI, rct);

				if (MotionDetector.MotionMask != null)
					MotionDetector.MotionMask.Release();

				MotionDetector.MotionMask = cropped;
				MotionDetector.BoundingRect = rct;

				Close();
				return;
			}

			// roiSpansEntireFrame == true

			DialogResult result = MessageBox.Show(this,
				Properties.Resources.SillyROIMessage, this.Text,
				MessageBoxButtons.YesNo, MessageBoxIcon.None);

			if (result == DialogResult.No)
				return;

			// User wants to discard it, so pretend ROI is empty.

		emptyROI:
			if (MotionDetector.MotionMask != null)
				MotionDetector.MotionMask.Release();

			MotionDetector.MotionMask = null;
			MotionDetector.BoundingRect = Rect.Empty;

			Close();
		}

		private void MaskForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			pictureBox.Image = null;

			m_Frame.Release();
			m_ROI.Release();
			m_Merged.Release();

			// Don't dispose bitmap; it is just referencing memory held by m_Merged.
			// If you do, opening MaskForm a second time causes an access violation.
			//m_DrawBitmap.Dispose();

			GC.Collect();

			Properties.Settings.Default.Save();
		}
	}
}