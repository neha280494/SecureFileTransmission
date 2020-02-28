using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SplitMerge_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void splitMergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSM sm = new frmSM();
            sm.MdiParent = this;
            sm.Show();
        }

        private void encryptDecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmED ed = new frmED();
            ed.MdiParent = this;
            ed.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compressionDecompressionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
