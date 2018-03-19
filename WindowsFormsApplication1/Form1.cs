using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorTextBox.Text = "";
        }

        private void EditorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditorForm_Load(object sender, EventArgs e)
        {

        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Text Files(.txt)|*.txt";
            svf.Title = "Save file...";
            if (svf.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(svf.FileName);
                sw.Write(EditorTextBox.Text);
                sw.Close();
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files(.txt)|*.txt";
            ofd.Title = "Open a file...";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                EditorTextBox.Text = sr.ReadToEnd();
                sr.Close();

            }
        }

        private void uploadToCozmoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // String cmr;
            //cmr = EditorTextBox.Text;
            //MessageBox.Show(cmr);
            //System.Diagnostics.Process.Start("CMD.exe", EditorTextBox.Text);

           PROCESS

        }


        // public void RecognizeSpeech()
        // {
        // }
    }
}
