using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Expat.Bayesian;

namespace SpamFilterSample
{
    public partial class FormSF : Form
    {
        private SpamFilter _filter;

        public FormSF()
        {
            InitializeComponent();
        }

        private void TestFile(string file)
        {
            if (_filter == null)
            {
                MessageBox.Show("Load Data first!", "Error",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string body = new StreamReader(file).ReadToEnd();
            txtOut.Text = file + Environment.NewLine + "score: " + _filter.Test(body).ToString();
            txtOut.AppendText(Environment.NewLine + Environment.NewLine + body);
            if (_filter.Test(body) > 0.53)
            {
                // Marked as spam
                txtOut.SelectionFont = new Font(txtOut.Font, FontStyle.Bold);
                txtOut.AppendText("\nMarked as spam.\n");
            }
            
        }

        #region clicks
        private void btnLoad_Click(object sender, EventArgs e)
        {
            Corpus bad = new Corpus();
            Corpus good = new Corpus();
            bad.LoadFromFile("../../TestData/spam.txt");
            good.LoadFromFile("../../TestData/good.txt");

            _filter = new SpamFilter();
            _filter.Load(good, bad);

            txtOut.Text = String.Format("Good Count: {0} \nBad Count: {1} ",
                 _filter.Good.Tokens.Count,
                 _filter.Bad.Tokens.Count,
                 _filter.Prob.Count,
                 Environment.NewLine);
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            TestFile("../../TestData/msg1.txt");
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            TestFile("../../TestData/msg2.txt");
        }

        private void btnTest3_Click(object sender, EventArgs e)
        {
            TestFile("../../TestData/msg3.txt");
        }

        private void btnTestBox_Click(object sender, EventArgs e)
        {
            if (_filter == null)
            {
                MessageBox.Show("Load Data  first!", "Error",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string body = txtOut.Text;
            txtOut.Text = _filter.Test(body).ToString();
            txtOut.AppendText(Environment.NewLine + body);
        }

        private void btnToFile_Click(object sender, EventArgs e)
        {
            if (_filter == null)
            {
                MessageBox.Show("Load Data  first!", "Error",
         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _filter.ToFile("../../TestData/out.txt");
        }

        //private void btnFromFile_Click(object sender, EventArgs e)
        //{
        //    _filter = new SpamFilter();

        //    _filter.FromFile("../../TestData/out.txt");
        //}

        #endregion

        public object MB_ICONERROR { get; set; }

        public object MB_OK { get; set; }

        

        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout FormAbout = new FormAbout();
            FormAbout.Show();
        }

        private void txtOut_TextChanged(object sender, EventArgs e)
        {

        }
    }
}