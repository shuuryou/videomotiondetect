
namespace VideoMotionDetect
{
	partial class MaskForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaskForm));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.markToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.brushSizeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.brushSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.displayModeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.displayModeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.finishedToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.pictureBoxPanel = new System.Windows.Forms.Panel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip.SuspendLayout();
			this.pictureBoxPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.markToolStripButton,
            this.clearToolStripButton,
            this.toolStripSeparator2,
            this.brushSizeToolStripLabel,
            this.brushSizeToolStripComboBox,
            this.toolStripSeparator3,
            this.displayModeToolStripLabel,
            this.displayModeToolStripComboBox,
            this.finishedToolStripButton,
            this.toolStripSeparator4});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(800, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(51, 22);
			this.newToolStripButton.Text = "&New";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(56, 22);
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(51, 22);
			this.saveToolStripButton.Text = "&Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// markToolStripButton
			// 
			this.markToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("markToolStripButton.Image")));
			this.markToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.markToolStripButton.Name = "markToolStripButton";
			this.markToolStripButton.Size = new System.Drawing.Size(54, 22);
			this.markToolStripButton.Text = "&Mark";
			this.markToolStripButton.Click += new System.EventHandler(this.markToolStripButton_Click);
			// 
			// clearToolStripButton
			// 
			this.clearToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearToolStripButton.Image")));
			this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearToolStripButton.Name = "clearToolStripButton";
			this.clearToolStripButton.Size = new System.Drawing.Size(54, 22);
			this.clearToolStripButton.Text = "&Clear";
			this.clearToolStripButton.Click += new System.EventHandler(this.clearToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// brushSizeToolStripLabel
			// 
			this.brushSizeToolStripLabel.Name = "brushSizeToolStripLabel";
			this.brushSizeToolStripLabel.Size = new System.Drawing.Size(30, 22);
			this.brushSizeToolStripLabel.Text = "&Size:";
			// 
			// brushSizeToolStripComboBox
			// 
			this.brushSizeToolStripComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72",
            "100",
            "200",
            "400",
            "800",
            "1000"});
			this.brushSizeToolStripComboBox.Name = "brushSizeToolStripComboBox";
			this.brushSizeToolStripComboBox.Size = new System.Drawing.Size(75, 25);
			this.brushSizeToolStripComboBox.TextChanged += new System.EventHandler(this.brushSizeToolStripComboBox_TextChanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// displayModeToolStripLabel
			// 
			this.displayModeToolStripLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.displayModeToolStripLabel.Name = "displayModeToolStripLabel";
			this.displayModeToolStripLabel.Size = new System.Drawing.Size(48, 22);
			this.displayModeToolStripLabel.Text = "&Display:";
			// 
			// displayModeToolStripComboBox
			// 
			this.displayModeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.displayModeToolStripComboBox.Items.AddRange(new object[] {
            "Stretch to window",
            "Actual pixels"});
			this.displayModeToolStripComboBox.Name = "displayModeToolStripComboBox";
			this.displayModeToolStripComboBox.Size = new System.Drawing.Size(121, 25);
			this.displayModeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.displayModeToolStripComboBox_SelectedIndexChanged);
			// 
			// finishedToolStripButton
			// 
			this.finishedToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.finishedToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("finishedToolStripButton.Image")));
			this.finishedToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.finishedToolStripButton.Name = "finishedToolStripButton";
			this.finishedToolStripButton.Size = new System.Drawing.Size(71, 22);
			this.finishedToolStripButton.Text = "&Finished";
			this.finishedToolStripButton.Click += new System.EventHandler(this.finishedToolStripButton_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// pictureBoxPanel
			// 
			this.pictureBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxPanel.AutoScroll = true;
			this.pictureBoxPanel.Controls.Add(this.pictureBox);
			this.pictureBoxPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.pictureBoxPanel.Location = new System.Drawing.Point(0, 24);
			this.pictureBoxPanel.Name = "pictureBoxPanel";
			this.pictureBoxPanel.Size = new System.Drawing.Size(800, 424);
			this.pictureBoxPanel.TabIndex = 1;
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(25, 25);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Region of Interest|*.roi|All files|*.*";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "roi";
			this.saveFileDialog.Filter = "Region of Interest|*.roi|All files|*.*";
			// 
			// MaskForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pictureBoxPanel);
			this.Controls.Add(this.toolStrip);
			this.MinimizeBox = false;
			this.Name = "MaskForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Highlight region of interest";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaskForm_FormClosing);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.pictureBoxPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel brushSizeToolStripLabel;
		private System.Windows.Forms.ToolStripComboBox brushSizeToolStripComboBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel displayModeToolStripLabel;
		private System.Windows.Forms.ToolStripComboBox displayModeToolStripComboBox;
		private System.Windows.Forms.Panel pictureBoxPanel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ToolStripButton markToolStripButton;
		private System.Windows.Forms.ToolStripButton clearToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton finishedToolStripButton;
	}
}