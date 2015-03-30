using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        bool FirstFile = false;
        bool SecondFile = false;
        bool ThirdFile = false;
        string dataFirst = String.Empty;
        string dataSecond = String.Empty;
        string dataThird = String.Empty;

        bool FirstOutFile = false;
        bool SecondOutFile = false;
        bool ThirdOutFile = false;
        string FirstOutPathFile = String.Empty;
        string SecondOutPathFile = String.Empty;
        string ThirdOutPathFile = String.Empty;

        static object OneLocker = new object();
        static object TwoLocker = new object();
        static object ThreeLocker = new object();

        public Form1()
        {
            InitializeComponent();
        }

        string ReadFile(ref string to)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                FileStream fstream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                if (fstream != null)
                {
                    StreamReader reader = new StreamReader(fstream);
                    to = reader.ReadToEnd();
                    fstream.Close();
                    return Path.GetFileName(fileName);
                }
            }
            return String.Empty;
        }

        private void From1Button_Click(object sender, EventArgs e)
        {
            string name = ReadFile(ref dataFirst);
            if(!String.IsNullOrEmpty(name))
            {
                FirstFile = true;
                From1Label.Text = name;
            }
            InitCalc();
        }

        private void From2Button_Click(object sender, EventArgs e)
        {
            string name = ReadFile(ref dataSecond);
            if (!String.IsNullOrEmpty(name))
            {
                SecondFile = true;
                From2Label.Text = name;
            }
            InitCalc();
        }

        private void From3Button_Click(object sender, EventArgs e)
        {
            string name = ReadFile(ref dataThird);
            if (!String.IsNullOrEmpty(name))
            {
                ThirdFile = true;
                From3Label.Text = name;
            }
            InitCalc();
        }

        void InitCalc()
        {
            if (FirstOutFile && SecondOutFile && ThirdOutFile && FirstFile && SecondFile && ThirdFile && !String.IsNullOrEmpty(DigitBox.Text))
                CalcButton.Enabled = true;
            else
                CalcButton.Enabled = false;
        }

        private void DigitBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void To1Button_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name  = saveFileDialog.FileName;
                if (name != SecondOutPathFile && name != ThirdOutPathFile)
                {
                    FileStream stream = File.Open(name, FileMode.Truncate);
                    stream.Close();
                    FirstOutPathFile = name;
                    To1Label.Text = Path.GetFileName(name);
                    FirstOutFile = true;
                }
                else MessageBox.Show("Нельзя записывать в один файл!", "Ошибка");
            }
            InitCalc();
        }

        private void To2Button_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;
                if (name != FirstOutPathFile && name != ThirdOutPathFile)
                {
                    FileStream stream = File.Open(name, FileMode.Truncate);
                    stream.Close();
                    SecondOutPathFile = name;
                    To2Label.Text = Path.GetFileName(name);
                    SecondOutFile = true;
                }
                else MessageBox.Show("Нельзя записывать в один файл!", "Ошибка");
            }
            InitCalc();
        }

        private void To3Button_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;
                if (name != SecondOutPathFile && name != FirstOutPathFile)
                {
                    FileStream stream = File.Open(name, FileMode.Truncate);
                    stream.Close();
                    ThirdOutPathFile = name;
                    To3Label.Text = Path.GetFileName(name);
                    ThirdOutFile = true;
                }
                else MessageBox.Show("Нельзя записывать в один файл!", "Ошибка");
            }
            InitCalc();
        }

        private void DigitBox_TextChanged(object sender, EventArgs e)
        {
            InitCalc();
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            Thread OneFile = new Thread(new ThreadStart(() =>
            {
                processFunction(dataFirst, Convert.ToInt32(DigitBox.Text));
            }));

            Thread TwoFile = new Thread(new ThreadStart(() =>
            {
                processFunction(dataSecond, Convert.ToInt32(DigitBox.Text));
            }));

            Thread ThreeFile = new Thread(new ThreadStart(() =>
            {
                processFunction(dataThird, Convert.ToInt32(DigitBox.Text));
            }));

            OneFile.Start();
            TwoFile.Start();
            ThreeFile.Start();
            OneFile.Join();
            TwoFile.Join();
            ThreeFile.Join();
        }

        private void processFunction(string str, int control)
        {
            List<decimal> list_num_b = new List<decimal>();
            List<decimal> list_num_m = new List<decimal>();
            List<string> list_words = new List<string>();
            string[] words = str.Split(new char[] { ' ', ',', '.', ':', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; ++i)
            {
                decimal number;
                if (decimal.TryParse(words[i], out number))
                {
                    if (number > control) list_num_b.Add(number);
                    else if (number < control) list_num_m.Add(number);
                }
                else list_words.Add(words[i]);
            }

            lock (OneLocker)
            {
                FileStream stream = File.Open(FirstOutPathFile, FileMode.Append);
                if (stream != null)
                {
                    StreamWriter writer = new StreamWriter(stream);

                    writer.WriteLine(string.Join(", ", list_words.ToArray().Distinct()));
                    writer.Flush();
                    stream.Close();
                }
            }

            lock (TwoLocker)
            {
                FileStream stream = File.Open(SecondOutPathFile, FileMode.Append);
                if (stream != null)
                {
                    StreamWriter writer = new StreamWriter(stream);

                    writer.WriteLine(string.Join(", ", list_num_b.ToArray().Distinct()));
                    writer.Flush();
                    stream.Close();
                }
            }

            lock (ThreeLocker)
            {
                FileStream stream = File.Open(ThirdOutPathFile, FileMode.Append);
                if (stream != null)
                {
                    StreamWriter writer = new StreamWriter(stream);

                    writer.WriteLine(string.Join(", ", list_num_m.ToArray().Distinct()));
                    writer.Flush();
                    stream.Close();
                }
            }
        }
    }
}
