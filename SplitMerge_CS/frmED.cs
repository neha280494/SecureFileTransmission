using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SplitMerge_CS
{
    public partial class frmED : Form
    {

        private AES aes = new AES();

        public frmED()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("File Saved Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox1.Text = aes.Encrypt(richTextBox1.Text, "Password", 128);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox1.Text = aes.Decrypt(richTextBox1.Text, "Password", 128);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Do you wish to Clear Text ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                richTextBox1.Text = "";
                richTextBox1.Focus();
            }
        }

        private void frmED_Load(object sender, EventArgs e)
        {

        }
    }
}
