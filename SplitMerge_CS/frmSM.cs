using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;

namespace SplitMerge_CS
{
    public partial class frmSM : Form
    {
        public frmSM()
        {
            InitializeComponent();
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            trd = new System.Threading.Thread(DoSplit);
            trd.IsBackground = true;
            trd.Start();
            
        }

        clFileSplitter SpliterClass = new clFileSplitter();

	System.Threading.Thread trd;
	private decimal getSelectedBytes()
	{
		if (this.cmbBDomination.InvokeRequired) {
			return Convert.ToDecimal(this.cmbBDomination.Invoke(new getSelectedBytesD(getSelectedBytes)));
		}
		if (this.cmbBDomination.SelectedIndex == -1) {
			this.cmbBDomination.SelectedIndex = 0;
		}
		switch (this.cmbBDomination.SelectedIndex) {
			case 0:
				return this.numUDSplitSize.Value;
			case 1:
				return this.numUDSplitSize.Value * 1024;
			case 2:
				return this.numUDSplitSize.Value * 1048576;
			case 3:
				return this.numUDSplitSize.Value * 1073741824;
            default:
                return 0;
		}
	}

	private string retFileSize(double size)
	{
		string ret = null;
		string dom = null;
		if ((size / 1024 < 1024)) {
			ret = Convert.ToString(size / 1024);
			dom = "KB";
		} else if ((size / 1048576 < 1024)) {
			ret = Convert.ToString(size / 1048576);
			dom = "MB";
		} else {
			ret = Convert.ToString(size / 1073741824);
			dom = "GB";
		}
		if ((ret.IndexOf(".") + 2 < ret.Length)) {
			return ret.Substring(0, ret.IndexOf(".") + 2) + " " + dom;
		} else {
			return ret + " " + dom;
		}
	}

	private void DoSplit()
	{
		SpliterClass.targetFile = this.txtBTargetFile.Text;
		SpliterClass.outputPath = this.txtBOutputDir.Text;
		SpliterClass.MaxiumSplitSize = Convert.ToInt64(getSelectedBytes());
		SpliterClass.deleteAfterSplit = this.chkBDeleteSource.Checked;
		SpliterClass.onProgressStep += this.onProgress;
		toggleControls();
		bool b = SpliterClass.beginSplit();
        if (b == false)
        {
            MessageBox.Show("Cannot Split File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show("Split Done Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
		toggleControls();
		updateStatusLabels(SpliterClass.getStats());
        //ToolStripProgressBar1.Value = 0;
        //tlStrpMainProgressBar.Value = 0;

	}

	private void toggleControls()
	{
		if (this.InvokeRequired) {
			this.Invoke(new ToggleControlsD(toggleControls));
		} else {
			this.chkBDeleteSplits.Enabled = !this.chkBDeleteSplits.Enabled;
			this.chkBDeleteSource.Enabled = !this.chkBDeleteSource.Enabled;
			this.btnBrowseOutPut.Enabled = !this.btnBrowseOutPut.Enabled;
			this.btnBrowseTargFile.Enabled = !this.btnBrowseTargFile.Enabled;
			this.btnSplit.Enabled = !this.btnSplit.Enabled;
			this.btnReassemble.Enabled = !this.btnReassemble.Enabled;
			this.cmbBDomination.Enabled = !this.cmbBDomination.Enabled;
			this.numUDSplitSize.Enabled = !this.numUDSplitSize.Enabled;
		}
	}

	private void DoAssemble()
	{
		SpliterClass.targetFile = this.txtBTargetFile.Text;
		SpliterClass.outputPath = this.txtBOutputDir.Text;
		SpliterClass.deleteAfterReassembly = this.chkBDeleteSplits.Checked;
		SpliterClass.deleteAfterSplit = true;
		SpliterClass.onProgressStep += this.onProgress;
		toggleControls();
        bool b = SpliterClass.beginReassembly();
        if (b == false)
        {
            MessageBox.Show("Cannot Merge File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show("Merge Done Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
		toggleControls();
		updateStatusLabels(SpliterClass.getStats());
	}

	private void updateStatusLabels(clFileSplitter.stats st)
	{
		string Time = null;
		int sec = st.timeTaken();

		if (this.InvokeRequired) {
			this.Invoke(new UpdateStatusLabelsD(updateStatusLabels), st);
		} else {
			if (sec > -1) {
				if ((sec / 60) > 1) {
					Time = (sec / 60).ToString();
					if (Time.IndexOf(".") > -1) {
						Time = Time.Substring(0, Time.IndexOf(".") + 1);
					}
					Time = Time + " min";
				} else {
					Time = sec + " sec";
				}
				this.lblTimeRequired.Text = "Time: " + Time;
			}
			if (st.fSize > 0) {
				this.lblFileSize.Text = "File size: " + retFileSize(st.fSize);
			}
			//default value check, is there another way?
			if (!(st.startTime == new DateTime())) {
				this.lblStartTime.Text = "Start time: " + st.startTime.ToShortTimeString();
			}
			//default value check, is there another way?
			if (!(st.finishTime == new DateTime())) {
				this.lblEndTime.Text = "End time: " + st.finishTime.ToShortTimeString();
			}
			if (st.NumSplits > 0) {
				this.lblSplitNumber.Text = "# Splits: " + st.NumSplits;
			}
		}
	}

	private void onProgress(int curFileProg, int totalProgress)
	{
		if (this.InvokeRequired) {
			this.Invoke(new onProgressD(onProgress), curFileProg, totalProgress);
		} else {
			this.tlStrpMainProgressBar.Value = curFileProg;
			this.ToolStripProgressBar1.Value = totalProgress + 1;
		}
	}

	private void frmSM_Load(System.Object sender, System.EventArgs e)
	{
		this.cmbBDomination.SelectedIndex = 2;
	}




	private void btnBrowse_Click(System.Object sender, System.EventArgs e)
	{
		OpenFileDialog dlg = new OpenFileDialog();

		dlg.CheckFileExists = true;
		dlg.AddExtension = false;
		dlg.Filter = "All files (*.*)|*.*";
		

		if (dlg.ShowDialog() == DialogResult.OK) {
			this.txtBTargetFile.Text = dlg.FileName;
			this.txtBOutputDir.Text = dlg.FileName.Substring(0, dlg.FileName.LastIndexOf("\\"));
			SpliterClass.targetFile = dlg.FileName;
			SpliterClass.outputPath = this.txtBOutputDir.Text;
			updateStatusLabels(SpliterClass.getStats());
		}
	}

	private void btnBrowseOutPut_Click(System.Object sender, System.EventArgs e)
	{
		FolderBrowserDialog dlg = new FolderBrowserDialog();
		dlg.RootFolder = Environment.SpecialFolder.MyComputer;
		dlg.ShowNewFolderButton = true;
		if (dlg.ShowDialog() == DialogResult.OK) {
			this.txtBOutputDir.Text = dlg.SelectedPath;
		}
	}

	private void numUDSplitSize_ValueChanged(System.Object sender, System.EventArgs e)
	{
		if (!this.Visible) {
			return;
		}
		SpliterClass.MaxiumSplitSize = Convert.ToInt64(getSelectedBytes());
		updateStatusLabels(SpliterClass.getStats());
	}

	private void cmbBDomination_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		if (!this.Visible) {
			return;
		}
		SpliterClass.MaxiumSplitSize = Convert.ToInt64(getSelectedBytes());
		updateStatusLabels(SpliterClass.getStats());
	}

	public delegate void ToggleControlsD();
	public delegate decimal getSelectedBytesD();
	public delegate void UpdateStatusLabelsD(clFileSplitter.stats st);
	public delegate void onProgressD(int curFileProg, int totalProgress);


	private void chkBDeleteSource_CheckedChanged(System.Object sender, System.EventArgs e)
	{
	}

    private void btnReassemble_Click(object sender, EventArgs e)
    {
        trd = new System.Threading.Thread(DoAssemble);
        trd.IsBackground = true;
        trd.Start();
    }


    }
}
