
namespace VideoMotionDetect
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.roiLabel = new System.Windows.Forms.Label();
			this.selectVideoFilesLabel = new System.Windows.Forms.Label();
			this.maxDeviationLabel = new System.Windows.Forms.Label();
			this.sensitivityLabel = new System.Windows.Forms.Label();
			this.continuationLabel = new System.Windows.Forms.Label();
			this.startButton = new System.Windows.Forms.Button();
			this.statusGroupBox = new System.Windows.Forms.GroupBox();
			this.statusListBox = new System.Windows.Forms.ListBox();
			this.createMaskButton = new System.Windows.Forms.Button();
			this.selectVideoFilesButton = new System.Windows.Forms.Button();
			this.sensitivityUpDown = new System.Windows.Forms.NumericUpDown();
			this.continuationUpDown = new System.Windows.Forms.NumericUpDown();
			this.verboseCheckBox = new System.Windows.Forms.CheckBox();
			this.maxDeviationUpDown = new System.Windows.Forms.NumericUpDown();
			this.totalFilesLabel = new System.Windows.Forms.Label();
			this.parallelismLabel = new System.Windows.Forms.Label();
			this.parallelismNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.remainingFilesLabel = new System.Windows.Forms.Label();
			this.thresholdLabel = new System.Windows.Forms.Label();
			this.thresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.mainTableLayoutPanel.SuspendLayout();
			this.statusGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sensitivityUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.continuationUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxDeviationUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.parallelismNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainTableLayoutPanel.ColumnCount = 3;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.Controls.Add(this.roiLabel, 0, 0);
			this.mainTableLayoutPanel.Controls.Add(this.selectVideoFilesLabel, 0, 1);
			this.mainTableLayoutPanel.Controls.Add(this.maxDeviationLabel, 0, 3);
			this.mainTableLayoutPanel.Controls.Add(this.sensitivityLabel, 0, 4);
			this.mainTableLayoutPanel.Controls.Add(this.continuationLabel, 0, 5);
			this.mainTableLayoutPanel.Controls.Add(this.startButton, 1, 7);
			this.mainTableLayoutPanel.Controls.Add(this.statusGroupBox, 0, 8);
			this.mainTableLayoutPanel.Controls.Add(this.createMaskButton, 1, 0);
			this.mainTableLayoutPanel.Controls.Add(this.selectVideoFilesButton, 1, 1);
			this.mainTableLayoutPanel.Controls.Add(this.sensitivityUpDown, 1, 4);
			this.mainTableLayoutPanel.Controls.Add(this.continuationUpDown, 1, 5);
			this.mainTableLayoutPanel.Controls.Add(this.verboseCheckBox, 2, 7);
			this.mainTableLayoutPanel.Controls.Add(this.maxDeviationUpDown, 1, 3);
			this.mainTableLayoutPanel.Controls.Add(this.totalFilesLabel, 2, 1);
			this.mainTableLayoutPanel.Controls.Add(this.parallelismLabel, 0, 6);
			this.mainTableLayoutPanel.Controls.Add(this.parallelismNumericUpDown, 1, 6);
			this.mainTableLayoutPanel.Controls.Add(this.remainingFilesLabel, 2, 2);
			this.mainTableLayoutPanel.Controls.Add(this.thresholdLabel, 0, 2);
			this.mainTableLayoutPanel.Controls.Add(this.thresholdNumericUpDown, 1, 2);
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 9;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(428, 351);
			this.mainTableLayoutPanel.TabIndex = 0;
			// 
			// roiLabel
			// 
			this.roiLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.roiLabel.AutoSize = true;
			this.roiLabel.Location = new System.Drawing.Point(3, 8);
			this.roiLabel.Name = "roiLabel";
			this.roiLabel.Size = new System.Drawing.Size(107, 13);
			this.roiLabel.TabIndex = 0;
			this.roiLabel.Text = "Set &region of interest:";
			// 
			// selectVideoFilesLabel
			// 
			this.selectVideoFilesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.selectVideoFilesLabel.AutoSize = true;
			this.selectVideoFilesLabel.Location = new System.Drawing.Point(3, 37);
			this.selectVideoFilesLabel.Name = "selectVideoFilesLabel";
			this.selectVideoFilesLabel.Size = new System.Drawing.Size(96, 13);
			this.selectVideoFilesLabel.TabIndex = 2;
			this.selectVideoFilesLabel.Text = "Select video &file(s):";
			// 
			// maxDeviationLabel
			// 
			this.maxDeviationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.maxDeviationLabel.AutoSize = true;
			this.maxDeviationLabel.Location = new System.Drawing.Point(3, 90);
			this.maxDeviationLabel.Name = "maxDeviationLabel";
			this.maxDeviationLabel.Size = new System.Drawing.Size(55, 13);
			this.maxDeviationLabel.TabIndex = 5;
			this.maxDeviationLabel.Text = "&Deviation:";
			// 
			// sensitivityLabel
			// 
			this.sensitivityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.sensitivityLabel.AutoSize = true;
			this.sensitivityLabel.Location = new System.Drawing.Point(3, 116);
			this.sensitivityLabel.Name = "sensitivityLabel";
			this.sensitivityLabel.Size = new System.Drawing.Size(57, 13);
			this.sensitivityLabel.TabIndex = 7;
			this.sensitivityLabel.Text = "&Sensitivity:";
			// 
			// continuationLabel
			// 
			this.continuationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.continuationLabel.AutoSize = true;
			this.continuationLabel.Location = new System.Drawing.Point(3, 142);
			this.continuationLabel.Name = "continuationLabel";
			this.continuationLabel.Size = new System.Drawing.Size(69, 13);
			this.continuationLabel.TabIndex = 9;
			this.continuationLabel.Text = "&Continuation:";
			// 
			// startButton
			// 
			this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.startButton.AutoSize = true;
			this.startButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.startButton.Location = new System.Drawing.Point(116, 191);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(120, 23);
			this.startButton.TabIndex = 13;
			this.startButton.Text = "Start motion detection";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// statusGroupBox
			// 
			this.mainTableLayoutPanel.SetColumnSpan(this.statusGroupBox, 3);
			this.statusGroupBox.Controls.Add(this.statusListBox);
			this.statusGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusGroupBox.Location = new System.Drawing.Point(3, 220);
			this.statusGroupBox.Name = "statusGroupBox";
			this.statusGroupBox.Size = new System.Drawing.Size(422, 128);
			this.statusGroupBox.TabIndex = 15;
			this.statusGroupBox.TabStop = false;
			this.statusGroupBox.Text = "Status";
			// 
			// statusListBox
			// 
			this.statusListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusListBox.FormattingEnabled = true;
			this.statusListBox.Location = new System.Drawing.Point(3, 16);
			this.statusListBox.Name = "statusListBox";
			this.statusListBox.ScrollAlwaysVisible = true;
			this.statusListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.statusListBox.Size = new System.Drawing.Size(416, 109);
			this.statusListBox.TabIndex = 0;
			// 
			// createMaskButton
			// 
			this.createMaskButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.createMaskButton.AutoSize = true;
			this.createMaskButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.createMaskButton.Location = new System.Drawing.Point(116, 3);
			this.createMaskButton.Name = "createMaskButton";
			this.createMaskButton.Size = new System.Drawing.Size(116, 23);
			this.createMaskButton.TabIndex = 1;
			this.createMaskButton.Text = "Create from video file";
			this.toolTip.SetToolTip(this.createMaskButton, resources.GetString("createMaskButton.ToolTip"));
			this.createMaskButton.UseVisualStyleBackColor = true;
			this.createMaskButton.Click += new System.EventHandler(this.createMaskButton_Click);
			// 
			// selectVideoFilesButton
			// 
			this.selectVideoFilesButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.selectVideoFilesButton.AutoSize = true;
			this.selectVideoFilesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.selectVideoFilesButton.Location = new System.Drawing.Point(116, 32);
			this.selectVideoFilesButton.Name = "selectVideoFilesButton";
			this.selectVideoFilesButton.Size = new System.Drawing.Size(52, 23);
			this.selectVideoFilesButton.TabIndex = 3;
			this.selectVideoFilesButton.Text = "Browse";
			this.toolTip.SetToolTip(this.selectVideoFilesButton, "Opens a file open dialog box for selecting one or more video files to process\r\nfo" +
        "r motion detection.");
			this.selectVideoFilesButton.UseVisualStyleBackColor = true;
			this.selectVideoFilesButton.Click += new System.EventHandler(this.selectVideoFilesButton_Click);
			// 
			// sensitivityUpDown
			// 
			this.sensitivityUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.sensitivityUpDown.Location = new System.Drawing.Point(116, 113);
			this.sensitivityUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
			this.sensitivityUpDown.Name = "sensitivityUpDown";
			this.sensitivityUpDown.Size = new System.Drawing.Size(74, 20);
			this.sensitivityUpDown.TabIndex = 8;
			this.toolTip.SetToolTip(this.sensitivityUpDown, resources.GetString("sensitivityUpDown.ToolTip"));
			this.sensitivityUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// continuationUpDown
			// 
			this.continuationUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.continuationUpDown.Location = new System.Drawing.Point(116, 139);
			this.continuationUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
			this.continuationUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.continuationUpDown.Name = "continuationUpDown";
			this.continuationUpDown.Size = new System.Drawing.Size(74, 20);
			this.continuationUpDown.TabIndex = 10;
			this.toolTip.SetToolTip(this.continuationUpDown, resources.GetString("continuationUpDown.ToolTip"));
			this.continuationUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// verboseCheckBox
			// 
			this.verboseCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.verboseCheckBox.AutoSize = true;
			this.verboseCheckBox.Location = new System.Drawing.Point(242, 194);
			this.verboseCheckBox.Name = "verboseCheckBox";
			this.verboseCheckBox.Size = new System.Drawing.Size(129, 17);
			this.verboseCheckBox.TabIndex = 14;
			this.verboseCheckBox.Text = "&Verbose status output";
			this.toolTip.SetToolTip(this.verboseCheckBox, "The verbose output allows you to tweak deviation, sensitivity, and continuation.\r" +
        "\nHowever, it will slow down the motion detection process. It is best to use verb" +
        "ose\r\noutput with only one video file.");
			this.verboseCheckBox.UseVisualStyleBackColor = true;
			// 
			// maxDeviationUpDown
			// 
			this.maxDeviationUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.maxDeviationUpDown.Location = new System.Drawing.Point(116, 87);
			this.maxDeviationUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
			this.maxDeviationUpDown.Name = "maxDeviationUpDown";
			this.maxDeviationUpDown.Size = new System.Drawing.Size(74, 20);
			this.maxDeviationUpDown.TabIndex = 6;
			this.toolTip.SetToolTip(this.maxDeviationUpDown, resources.GetString("maxDeviationUpDown.ToolTip"));
			this.maxDeviationUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// totalFilesLabel
			// 
			this.totalFilesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.totalFilesLabel.AutoSize = true;
			this.totalFilesLabel.Location = new System.Drawing.Point(242, 37);
			this.totalFilesLabel.Name = "totalFilesLabel";
			this.totalFilesLabel.Size = new System.Drawing.Size(22, 13);
			this.totalFilesLabel.TabIndex = 4;
			this.totalFilesLabel.Text = "xxx";
			// 
			// parallelismLabel
			// 
			this.parallelismLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.parallelismLabel.AutoSize = true;
			this.parallelismLabel.Location = new System.Drawing.Point(3, 168);
			this.parallelismLabel.Name = "parallelismLabel";
			this.parallelismLabel.Size = new System.Drawing.Size(98, 13);
			this.parallelismLabel.TabIndex = 11;
			this.parallelismLabel.Text = "&Parallel processing:";
			// 
			// parallelismNumericUpDown
			// 
			this.parallelismNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.parallelismNumericUpDown.Location = new System.Drawing.Point(116, 165);
			this.parallelismNumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.parallelismNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.parallelismNumericUpDown.Name = "parallelismNumericUpDown";
			this.parallelismNumericUpDown.Size = new System.Drawing.Size(74, 20);
			this.parallelismNumericUpDown.TabIndex = 12;
			this.toolTip.SetToolTip(this.parallelismNumericUpDown, "Controls how many videos are processed at the same time.\r\nKeep an eye out for CPU" +
        " and memory usage.");
			this.parallelismNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// remainingFilesLabel
			// 
			this.remainingFilesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.remainingFilesLabel.AutoSize = true;
			this.remainingFilesLabel.Location = new System.Drawing.Point(242, 64);
			this.remainingFilesLabel.Name = "remainingFilesLabel";
			this.remainingFilesLabel.Size = new System.Drawing.Size(22, 13);
			this.remainingFilesLabel.TabIndex = 17;
			this.remainingFilesLabel.Text = "xxx";
			// 
			// thresholdLabel
			// 
			this.thresholdLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.thresholdLabel.AutoSize = true;
			this.thresholdLabel.Location = new System.Drawing.Point(3, 64);
			this.thresholdLabel.Name = "thresholdLabel";
			this.thresholdLabel.Size = new System.Drawing.Size(57, 13);
			this.thresholdLabel.TabIndex = 18;
			this.thresholdLabel.Text = "&Threshold:";
			// 
			// thresholdNumericUpDown
			// 
			this.thresholdNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.thresholdNumericUpDown.Location = new System.Drawing.Point(116, 61);
			this.thresholdNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.thresholdNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.thresholdNumericUpDown.Name = "thresholdNumericUpDown";
			this.thresholdNumericUpDown.Size = new System.Drawing.Size(74, 20);
			this.thresholdNumericUpDown.TabIndex = 19;
			this.toolTip.SetToolTip(this.thresholdNumericUpDown, resources.GetString("thresholdNumericUpDown.ToolTip"));
			this.thresholdNumericUpDown.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "AVI and MPEG4 containers|*.avi;*.mp4|All files|*.*";
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 361);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(460, 400);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Video Motion Detection";
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.mainTableLayoutPanel.PerformLayout();
			this.statusGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sensitivityUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.continuationUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maxDeviationUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.parallelismNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
		private System.Windows.Forms.Label roiLabel;
		private System.Windows.Forms.Label selectVideoFilesLabel;
		private System.Windows.Forms.Label maxDeviationLabel;
		private System.Windows.Forms.Label sensitivityLabel;
		private System.Windows.Forms.Label continuationLabel;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.GroupBox statusGroupBox;
		private System.Windows.Forms.ListBox statusListBox;
		private System.Windows.Forms.Button createMaskButton;
		private System.Windows.Forms.Button selectVideoFilesButton;
		private System.Windows.Forms.NumericUpDown maxDeviationUpDown;
		private System.Windows.Forms.NumericUpDown sensitivityUpDown;
		private System.Windows.Forms.NumericUpDown continuationUpDown;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Label parallelismLabel;
		private System.Windows.Forms.NumericUpDown parallelismNumericUpDown;
		private System.Windows.Forms.CheckBox verboseCheckBox;
		private System.Windows.Forms.Label totalFilesLabel;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label remainingFilesLabel;
		private System.Windows.Forms.Label thresholdLabel;
		private System.Windows.Forms.NumericUpDown thresholdNumericUpDown;
	}
}

