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

/* 1. Используя текстовый файл из 2 лб создать 2 потока в первый записывая числа из файла,
 * а во второй слова без повторений. После считывания данных вывести данные на форму с
 * формированием новых полей вывода. */

namespace SHLb_5
{
    public partial class MainForm : Form
    {
        private string dataFromFile;
        public string words;
        public string digits;

        public MainForm()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                FileStream fstream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                if (fstream != null)
                {
                    StreamReader reader = new StreamReader(fstream);
                    dataFromFile = reader.ReadToEnd();
                    fstream.Close();
                }
            }
        }

        private void PrintResult_Click(object sender, EventArgs e)
        {
            Thread word = new Thread(new ThreadStart(() =>
            {
                words = processFunctionWord(dataFromFile);
            }));
            Thread num = new Thread(new ThreadStart(() =>
            {
                digits = processFunctionNum(dataFromFile);
            }));
            num.Start();
            word.Start();
            num.Join();
            word.Join();
            
            TextBox outWords = new TextBox();
            outWords.Text = words;
            outWords.Multiline = true;
            outWords.Location = new Point(105, 12);
            outWords.Size = new Size(256, 115);
            this.Controls.Add(outWords);

            TextBox outNumbers = new TextBox();
            outNumbers.Text = digits;
            outNumbers.Multiline = true;
            outNumbers.Location = new Point(105, 133);
            outNumbers.Size = new Size(256, 116);
            this.Controls.Add(outNumbers);
        }

        private string processFunctionWord(string str)
        {
            List<string> list_words = new List<string>();

            string[] nums = str.Split(new char[] { ' ' });

            for (int i = 0; i < nums.Length; ++i)
            {
                int number;
                if (!int.TryParse(nums[i], out number)) list_words.Add(nums[i]);
            }
            string line = string.Join(" ", list_words.ToArray().Distinct());
            return line;
        }

        private string processFunctionNum(string str)
        {
            List<int> list_num = new List<int>();

            string[] nums = str.Split(new char[] { ' ' });

            for (int i = 0; i < nums.Length; ++i)
            {
                int number;
                if (int.TryParse(nums[i], out number)) list_num.Add(number);
            }
            string line = string.Join(" ", list_num.ToArray().Distinct());
            return line;
        }
    }
}
