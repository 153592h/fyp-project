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
using System.Speech.Recognition;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class EditorForm : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        

        public EditorForm()
        {
            InitializeComponent();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEditor.Text = "";
        }

<<<<<<< HEAD
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
=======
        private void EditorForm_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "say hello", "print text", "clear file", "open file", "run app" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            
        }

        string name = "";
        public void openfile()
        {           
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "C:\\";
            op.FilterIndex = 2;
            op.RestoreDirectory = true;

            if (op.ShowDialog() == DialogResult.OK)
            {
                name = op.FileName;
                string path = op.FileName;
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        sb.AppendLine(sr.ReadLine());
                    }
                    tbEditor.Text = sb.ToString();
                }
            }
        }

        public void runapplication()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("python 01_hello_world.py");
            process.StandardInput.Flush();
            process.StandardInput.Close();
           // process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
        }

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "say hello":
                    MessageBox.Show("Hello Jerome. How are you?");
                    break;
                case "print text":
                    tbEditor.Text += "hello my name is 123";
                    break;
                case "clear file":
                    tbEditor.Text = "";
                    break;
                case "open file":
                    openfile();
                    break;
                case "run app":
                    runapplication();
                    break;
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnDisable.Enabled = true;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfile();
        }

        private void uploadToCozmoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runapplication();
        }
>>>>>>> 6b1ff21f0b37fa3dbc87021b221212f724e73034
    }
}
