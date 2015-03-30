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

namespace CHLb_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
                openFileDialog1.ShowDialog() ;
                string fileName = openFileDialog1.FileName;

                FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
			    if(stream != null)
			    {
				    StreamReader reader = new StreamReader(stream);
				    textBox.Text = reader.ReadToEnd ();
				    stream.Close();
			    }
        }

        private void save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
			string fileName = saveFileDialog1.FileName;
			FileStream stream = File.Open(fileName, FileMode.Create, FileAccess.Write);
			if(stream != null)
			{
				StreamWriter writer = new StreamWriter(stream);

				writer.Write("Слова: {0}\n", textBox.Text);
                writer.Write("Количесвто цифер: {0}\n", countBox.Text);
                writer.Write("Минимальное: {0}\n", minBox.Text);
                writer.Write("Максимальное: {0}\n", maxBox.Text);
				writer.Flush();
				stream.Close();
	        }

        }

        private void count_Click(object sender, EventArgs e)
        {
            List<decimal> list_num = new List<decimal>();
            List<string> list_words = new List<string>();
            //Подсчитать количество чисел в тестовом файле и записать это значение в файл.
            string data = textBox.Text;
            string[] nums = data.Split(new char[] { ' ', ',', '.', ':', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            
            for(int i = 0; i < nums.Length; ++i)
            {
                decimal number;
                if (decimal.TryParse(nums[i], out number)) list_num.Add(number);
                else list_words.Add(nums[i]);
            }
            countBox.Text = list_num.Count.ToString();
            minBox.Text = list_num.Min().ToString();
            maxBox.Text = list_num.Max().ToString();

            textBox.Text = string.Join(", ", list_words.ToArray().Distinct());
        }
    }
}
