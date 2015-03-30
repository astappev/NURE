using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SHLb_1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void replace_Click(object sender, EventArgs e)
        {
            string str = this.input.Text;
            Regex r = new Regex(@"\b(країна)\b", RegexOptions.IgnoreCase);
            str = r.Replace(str, "Україна");
            this.output.Text = str;
        }
    }
}
