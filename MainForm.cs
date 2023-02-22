using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoMotionDetect
{
	public partial class MainForm : Form
	{
		private const int STATUS_ITEMS_MAX = 500;

		private string[] m_SelectedVideoFiles = null;

		public MainForm()
		{
			InitializeComponent();

			totalFilesLabel.Text = string.Empty;
			remainingFilesLabel.Text = string.Empty;

			MotionDetector.LogMessage += LogMessageFromMotionDetection;
		}
		private void LogMessageFromMotionDetection(string msg)
		{
			statusListBox.InvokeIfRequired(c =>
			{
				while (c.Items.Count > STATUS_ITEMS_MAX)
					c.Items.RemoveAt(statusListBox.Items.Count - 1);

				c.Items.Insert(0, string.Format(CultureInfo.CurrentCulture,
					"{0:T} {1}", DateTime.Now, msg));
			});
		}

		private void createMaskButton_Click(object sender, System.EventArgs e)
		{
			openFileDialog.Multiselect = false;

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			MaskForm mf = null;

			try
			{
				mf = new MaskForm(openFileDialog.FileName);
				mf.ShowDialog(this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
					Properties.Resources.OpenMaskFormError, ex.Message),
					this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (mf != null)
					mf.Dispose();
			}
		}

		private void selectVideoFilesButton_Click(object sender, EventArgs e)
		{
			openFileDialog.Multiselect = true;

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			m_SelectedVideoFiles = openFileDialog.FileNames;

			totalFilesLabel.Text = string.Format(CultureInfo.CurrentCulture,
				Properties.Resources.FilesSelectedCount,
				m_SelectedVideoFiles.Length);

			remainingFilesLabel.Text = string.Empty;
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			DateTime start = DateTime.Now;

			StreamWriter sw = (StreamWriter)e.Argument;
			int count = 0;

			Parallel.ForEach
			(
				m_SelectedVideoFiles,
				new ParallelOptions() { MaxDegreeOfParallelism = (int)parallelismNumericUpDown.Value },
				videoFile =>
				{
					int result = -1;

					try
					{
						result = MotionDetector.video_motion_detection(videoFile,
							 (int)thresholdNumericUpDown.Value, (int)maxDeviationUpDown.Value,
							(int)sensitivityUpDown.Value, (int)continuationUpDown.Value,
							verboseCheckBox.Checked);
					}
					catch (Exception ex)
					{
						sw.WriteLine(string.Format(CultureInfo.InvariantCulture,
							"NG\t{0}\t{1}", videoFile, ex.ToString()));
						sw.Flush();
					}

					lock (sw)
					{
						sw.WriteLine(string.Format(CultureInfo.InvariantCulture, "OK\t{0}\t{1}", videoFile, result));
						sw.Flush();

						count++;

						backgroundWorker.ReportProgress
						(
							count / m_SelectedVideoFiles.Length * 100,
							m_SelectedVideoFiles.Length - count
						);
					}
				}
			);

			sw.Close();
			sw.Dispose();

			e.Result = start;
		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			remainingFilesLabel.Text = string.Format(CultureInfo.CurrentCulture,
				Properties.Resources.FilesRemainingCount, (int)e.UserState);
		}

		private void startButton_Click(object sender, EventArgs e)
		{
			if (m_SelectedVideoFiles == null || m_SelectedVideoFiles.Length == 0)
			{
				MessageBox.Show(this, Properties.Resources.NoVideosMessage,
					this.Text, MessageBoxButtons.OK);

				return;
			}

			if (MotionDetector.MotionMask == null || MotionDetector.MotionMask.Empty())
			{
				DialogResult ret = MessageBox.Show(this, Properties.Resources.NoROIMessage,
					this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (ret == DialogResult.No)
					return;
			}

			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			StreamWriter sw;

			try
			{
				sw = File.CreateText(saveFileDialog.FileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
					Properties.Resources.OpenResultFileError, ex.Message),
					this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			remainingFilesLabel.Text = string.Format(CultureInfo.CurrentCulture,
				Properties.Resources.FilesRemainingCount, m_SelectedVideoFiles.Length);

			this.UseWaitCursor = true;
			roiLabel.Enabled = false;
			createMaskButton.Enabled = false;
			selectVideoFilesLabel.Enabled = false;
			selectVideoFilesButton.Enabled = false;
			maxDeviationLabel.Enabled = false;
			maxDeviationUpDown.Enabled = false;
			sensitivityLabel.Enabled = false;
			sensitivityUpDown.Enabled = false;
			continuationLabel.Enabled = false;
			continuationUpDown.Enabled = false;
			parallelismLabel.Enabled = false;
			parallelismNumericUpDown.Enabled = false;
			verboseCheckBox.Enabled = false;
			startButton.Enabled = false;

			NativeMethods.SetThreadExecutionState
			(
				NativeMethods.EXECUTION_STATE.ES_CONTINUOUS |
				NativeMethods.EXECUTION_STATE.ES_SYSTEM_REQUIRED
			);

			backgroundWorker.RunWorkerAsync(sw);
		}

		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.UseWaitCursor = false;
			roiLabel.Enabled = true;
			createMaskButton.Enabled = true;
			selectVideoFilesLabel.Enabled = true;
			selectVideoFilesButton.Enabled = true;
			maxDeviationLabel.Enabled = true;
			maxDeviationUpDown.Enabled = true;
			sensitivityLabel.Enabled = true;
			sensitivityUpDown.Enabled = true;
			continuationLabel.Enabled = true;
			continuationUpDown.Enabled = true;
			parallelismLabel.Enabled = true;
			parallelismNumericUpDown.Enabled = true;
			verboseCheckBox.Enabled = true;
			startButton.Enabled = true;

			NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS);

			if (e.Error != null)
				MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
					Properties.Resources.BackgroundWorkerError, e.Error.ToString()),
					this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

			MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
				Properties.Resources.Finished, DateTime.Now.Subtract((DateTime)e.Result)),
				Properties.Resources.FinishedTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
	}
}