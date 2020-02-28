namespace SplitMerge_CS
{
    partial class frmSM
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
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtBOutputDir = new System.Windows.Forms.TextBox();
            this.lblSplitNumber = new System.Windows.Forms.Label();
            this.lblOutputDirectory = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.StatStripMain = new System.Windows.Forms.StatusStrip();
            this.tlStrpLblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlStrpMainProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tlStrpTotalProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.cmbBDomination = new System.Windows.Forms.ComboBox();
            this.lblTimeRequired = new System.Windows.Forms.Label();
            this.lblInDom = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnBrowseOutPut = new System.Windows.Forms.Button();
            this.numUDSplitSize = new System.Windows.Forms.NumericUpDown();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblMaxSplitSize = new System.Windows.Forms.Label();
            this.grpBStats = new System.Windows.Forms.GroupBox();
            this.chkBDeleteSplits = new System.Windows.Forms.CheckBox();
            this.chkBDeleteSource = new System.Windows.Forms.CheckBox();
            this.btnBrowseTargFile = new System.Windows.Forms.Button();
            this.lblTargetFile = new System.Windows.Forms.Label();
            this.txtBTargetFile = new System.Windows.Forms.TextBox();
            this.btnReassemble = new System.Windows.Forms.Button();
            this.StatStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSplitSize)).BeginInit();
            this.grpBStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(6, 18);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(83, 13);
            this.lblStartTime.TabIndex = 1;
            this.lblStartTime.Text = "Start time: None";
            // 
            // txtBOutputDir
            // 
            this.txtBOutputDir.Location = new System.Drawing.Point(6, 59);
            this.txtBOutputDir.Name = "txtBOutputDir";
            this.txtBOutputDir.ReadOnly = true;
            this.txtBOutputDir.Size = new System.Drawing.Size(324, 20);
            this.txtBOutputDir.TabIndex = 32;
            this.txtBOutputDir.TabStop = false;
            // 
            // lblSplitNumber
            // 
            this.lblSplitNumber.AutoSize = true;
            this.lblSplitNumber.Location = new System.Drawing.Point(6, 57);
            this.lblSplitNumber.Name = "lblSplitNumber";
            this.lblSplitNumber.Size = new System.Drawing.Size(54, 13);
            this.lblSplitNumber.TabIndex = 0;
            this.lblSplitNumber.Text = "# Splits: 0";
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.AutoSize = true;
            this.lblOutputDirectory.Location = new System.Drawing.Point(3, 43);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(87, 13);
            this.lblOutputDirectory.TabIndex = 31;
            this.lblOutputDirectory.Text = "Output Directory:";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(6, 70);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(84, 13);
            this.lblFileSize.TabIndex = 3;
            this.lblFileSize.Text = "File size: 0 bytes";
            // 
            // StatStripMain
            // 
            this.StatStripMain.BackColor = System.Drawing.Color.Thistle;
            this.StatStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStrpLblProgress,
            this.tlStrpMainProgressBar,
            this.tlStrpTotalProgress,
            this.ToolStripProgressBar1});
            this.StatStripMain.Location = new System.Drawing.Point(0, 306);
            this.StatStripMain.Name = "StatStripMain";
            this.StatStripMain.Size = new System.Drawing.Size(375, 22);
            this.StatStripMain.SizingGrip = false;
            this.StatStripMain.TabIndex = 30;
            this.StatStripMain.Text = "statStripMain";
            // 
            // tlStrpLblProgress
            // 
            this.tlStrpLblProgress.Name = "tlStrpLblProgress";
            this.tlStrpLblProgress.Size = new System.Drawing.Size(96, 17);
            this.tlStrpLblProgress.Text = "Cur file progress:";
            // 
            // tlStrpMainProgressBar
            // 
            this.tlStrpMainProgressBar.Name = "tlStrpMainProgressBar";
            this.tlStrpMainProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tlStrpTotalProgress
            // 
            this.tlStrpTotalProgress.Name = "tlStrpTotalProgress";
            this.tlStrpTotalProgress.Size = new System.Drawing.Size(85, 17);
            this.tlStrpTotalProgress.Text = "Total Progress:";
            this.tlStrpTotalProgress.Visible = false;
            // 
            // ToolStripProgressBar1
            // 
            this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            this.ToolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.ToolStripProgressBar1.Visible = false;
            // 
            // cmbBDomination
            // 
            this.cmbBDomination.FormattingEnabled = true;
            this.cmbBDomination.Items.AddRange(new object[] {
            "Bytes",
            "Kilobytes",
            "Megabytes",
            "Gigabytes"});
            this.cmbBDomination.Location = new System.Drawing.Point(126, 105);
            this.cmbBDomination.Name = "cmbBDomination";
            this.cmbBDomination.Size = new System.Drawing.Size(79, 21);
            this.cmbBDomination.TabIndex = 20;
            this.cmbBDomination.SelectedIndexChanged += new System.EventHandler(this.cmbBDomination_SelectedIndexChanged);
            // 
            // lblTimeRequired
            // 
            this.lblTimeRequired.AutoSize = true;
            this.lblTimeRequired.Location = new System.Drawing.Point(6, 44);
            this.lblTimeRequired.Name = "lblTimeRequired";
            this.lblTimeRequired.Size = new System.Drawing.Size(42, 13);
            this.lblTimeRequired.TabIndex = 4;
            this.lblTimeRequired.Text = "Time: 0";
            // 
            // lblInDom
            // 
            this.lblInDom.AutoSize = true;
            this.lblInDom.Location = new System.Drawing.Point(123, 90);
            this.lblInDom.Name = "lblInDom";
            this.lblInDom.Size = new System.Drawing.Size(19, 13);
            this.lblInDom.TabIndex = 29;
            this.lblInDom.Text = "In:";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(5, 178);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 24;
            this.btnSplit.Text = "&Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnBrowseOutPut
            // 
            this.btnBrowseOutPut.Location = new System.Drawing.Point(344, 57);
            this.btnBrowseOutPut.Name = "btnBrowseOutPut";
            this.btnBrowseOutPut.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseOutPut.TabIndex = 18;
            this.btnBrowseOutPut.Text = "...";
            this.btnBrowseOutPut.UseVisualStyleBackColor = true;
            this.btnBrowseOutPut.Click += new System.EventHandler(this.btnBrowseOutPut_Click);
            // 
            // numUDSplitSize
            // 
            this.numUDSplitSize.Location = new System.Drawing.Point(6, 106);
            this.numUDSplitSize.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.numUDSplitSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDSplitSize.Name = "numUDSplitSize";
            this.numUDSplitSize.Size = new System.Drawing.Size(100, 20);
            this.numUDSplitSize.TabIndex = 19;
            this.numUDSplitSize.ThousandsSeparator = true;
            this.numUDSplitSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUDSplitSize.ValueChanged += new System.EventHandler(this.numUDSplitSize_ValueChanged);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(6, 31);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(80, 13);
            this.lblEndTime.TabIndex = 2;
            this.lblEndTime.Text = "End time: None";
            // 
            // lblMaxSplitSize
            // 
            this.lblMaxSplitSize.AutoSize = true;
            this.lblMaxSplitSize.Location = new System.Drawing.Point(2, 90);
            this.lblMaxSplitSize.Name = "lblMaxSplitSize";
            this.lblMaxSplitSize.Size = new System.Drawing.Size(104, 13);
            this.lblMaxSplitSize.TabIndex = 28;
            this.lblMaxSplitSize.Text = "Maxium split file size:";
            // 
            // grpBStats
            // 
            this.grpBStats.Controls.Add(this.lblTimeRequired);
            this.grpBStats.Controls.Add(this.lblFileSize);
            this.grpBStats.Controls.Add(this.lblStartTime);
            this.grpBStats.Controls.Add(this.lblSplitNumber);
            this.grpBStats.Controls.Add(this.lblEndTime);
            this.grpBStats.Location = new System.Drawing.Point(6, 207);
            this.grpBStats.Name = "grpBStats";
            this.grpBStats.Size = new System.Drawing.Size(362, 90);
            this.grpBStats.TabIndex = 25;
            this.grpBStats.TabStop = false;
            this.grpBStats.Text = "Stats";
            // 
            // chkBDeleteSplits
            // 
            this.chkBDeleteSplits.AutoSize = true;
            this.chkBDeleteSplits.Location = new System.Drawing.Point(6, 153);
            this.chkBDeleteSplits.Name = "chkBDeleteSplits";
            this.chkBDeleteSplits.Size = new System.Drawing.Size(143, 17);
            this.chkBDeleteSplits.TabIndex = 23;
            this.chkBDeleteSplits.Text = "D&elete splits after Merger";
            this.chkBDeleteSplits.UseVisualStyleBackColor = true;
            // 
            // chkBDeleteSource
            // 
            this.chkBDeleteSource.AutoSize = true;
            this.chkBDeleteSource.Location = new System.Drawing.Point(6, 132);
            this.chkBDeleteSource.Name = "chkBDeleteSource";
            this.chkBDeleteSource.Size = new System.Drawing.Size(139, 17);
            this.chkBDeleteSource.TabIndex = 22;
            this.chkBDeleteSource.Text = "&Delete source after Split";
            this.chkBDeleteSource.UseVisualStyleBackColor = true;
            this.chkBDeleteSource.CheckedChanged += new System.EventHandler(this.chkBDeleteSource_CheckedChanged);
            // 
            // btnBrowseTargFile
            // 
            this.btnBrowseTargFile.Location = new System.Drawing.Point(344, 18);
            this.btnBrowseTargFile.Name = "btnBrowseTargFile";
            this.btnBrowseTargFile.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseTargFile.TabIndex = 16;
            this.btnBrowseTargFile.Text = "...";
            this.btnBrowseTargFile.UseVisualStyleBackColor = true;
            this.btnBrowseTargFile.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblTargetFile
            // 
            this.lblTargetFile.AutoSize = true;
            this.lblTargetFile.Location = new System.Drawing.Point(2, 4);
            this.lblTargetFile.Name = "lblTargetFile";
            this.lblTargetFile.Size = new System.Drawing.Size(57, 13);
            this.lblTargetFile.TabIndex = 21;
            this.lblTargetFile.Text = "Target file:";
            // 
            // txtBTargetFile
            // 
            this.txtBTargetFile.Location = new System.Drawing.Point(6, 20);
            this.txtBTargetFile.Name = "txtBTargetFile";
            this.txtBTargetFile.ReadOnly = true;
            this.txtBTargetFile.Size = new System.Drawing.Size(324, 20);
            this.txtBTargetFile.TabIndex = 17;
            this.txtBTargetFile.TabStop = false;
            // 
            // btnReassemble
            // 
            this.btnReassemble.Location = new System.Drawing.Point(83, 178);
            this.btnReassemble.Name = "btnReassemble";
            this.btnReassemble.Size = new System.Drawing.Size(75, 23);
            this.btnReassemble.TabIndex = 26;
            this.btnReassemble.Text = "&Merge";
            this.btnReassemble.UseVisualStyleBackColor = true;
            this.btnReassemble.Click += new System.EventHandler(this.btnReassemble_Click);
            // 
            // frmSM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(375, 328);
            this.Controls.Add(this.txtBOutputDir);
            this.Controls.Add(this.lblOutputDirectory);
            this.Controls.Add(this.StatStripMain);
            this.Controls.Add(this.cmbBDomination);
            this.Controls.Add(this.lblInDom);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnBrowseOutPut);
            this.Controls.Add(this.numUDSplitSize);
            this.Controls.Add(this.lblMaxSplitSize);
            this.Controls.Add(this.grpBStats);
            this.Controls.Add(this.chkBDeleteSplits);
            this.Controls.Add(this.chkBDeleteSource);
            this.Controls.Add(this.btnBrowseTargFile);
            this.Controls.Add(this.lblTargetFile);
            this.Controls.Add(this.txtBTargetFile);
            this.Controls.Add(this.btnReassemble);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSM";
            this.Text = "File Splitter and Merger";
            this.Load += new System.EventHandler(this.frmSM_Load);
            this.StatStripMain.ResumeLayout(false);
            this.StatStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSplitSize)).EndInit();
            this.grpBStats.ResumeLayout(false);
            this.grpBStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblStartTime;
        internal System.Windows.Forms.TextBox txtBOutputDir;
        internal System.Windows.Forms.Label lblSplitNumber;
        internal System.Windows.Forms.Label lblOutputDirectory;
        internal System.Windows.Forms.Label lblFileSize;
        internal System.Windows.Forms.StatusStrip StatStripMain;
        internal System.Windows.Forms.ToolStripStatusLabel tlStrpLblProgress;
        internal System.Windows.Forms.ToolStripStatusLabel tlStrpTotalProgress;
        internal System.Windows.Forms.ComboBox cmbBDomination;
        internal System.Windows.Forms.Label lblTimeRequired;
        internal System.Windows.Forms.Label lblInDom;
        internal System.Windows.Forms.Button btnSplit;
        internal System.Windows.Forms.Button btnBrowseOutPut;
        internal System.Windows.Forms.NumericUpDown numUDSplitSize;
        internal System.Windows.Forms.Label lblEndTime;
        internal System.Windows.Forms.Label lblMaxSplitSize;
        internal System.Windows.Forms.GroupBox grpBStats;
        internal System.Windows.Forms.CheckBox chkBDeleteSplits;
        internal System.Windows.Forms.CheckBox chkBDeleteSource;
        internal System.Windows.Forms.Button btnBrowseTargFile;
        internal System.Windows.Forms.Label lblTargetFile;
        internal System.Windows.Forms.TextBox txtBTargetFile;
        internal System.Windows.Forms.Button btnReassemble;
        public System.Windows.Forms.ToolStripProgressBar tlStrpMainProgressBar;
        public System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar1;
    }
}