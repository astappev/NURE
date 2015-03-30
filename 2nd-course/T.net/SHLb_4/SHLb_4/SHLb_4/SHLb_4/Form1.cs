using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointSpace;

namespace SHLb_4
{
    public partial class Form1 : Form
    {
        PointClass point;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateClass_Click(object sender, EventArgs e)
        {
            if (create_x.Text != String.Empty && create_y.Text != String.Empty && System.Text.RegularExpressions.Regex.IsMatch("[^0-9]", create_x.Text) && System.Text.RegularExpressions.Regex.IsMatch("[^0-9]", create_y.Text))
            {
                point = new PointClass(int.Parse(create_x.Text), int.Parse(create_y.Text));
                OutBox.AppendText("Точка создана.\n");
            } else {
                point = new PointClass();
                OutBox.AppendText("Точка создана, с нулевыми координатами.\n");
            }

            PrintCord.Enabled = true;
            SetCord.Enabled = true;
            MovePoint.Enabled = true;
            PrintDistance.Enabled = true;

            CreateClass.Enabled = false;
        }

        private void PrintCord_Click(object sender, EventArgs e)
        {
            OutBox.AppendText(point.PrintCord() + "\n");
        }

        private void SetCord_Click(object sender, EventArgs e)
        {
            if (set_x.Text != String.Empty && set_y.Text != String.Empty)
            {
                point.x = int.Parse(set_x.Text);
                point.y = int.Parse(set_y.Text);
                OutBox.AppendText("Установлены новые координаты точки.\n");
            }
        }

        private void MovePoint_Click(object sender, EventArgs e)
        {
            if (vector_a.Text != String.Empty && vector_a.Text != String.Empty)
            {
                point.MultiplyX = int.Parse(vector_a.Text);
                point.MultiplyY = int.Parse(vector_b.Text);
                OutBox.AppendText("Точка перемещена на вектор (a,b).\n");
            }
        }

        private void PrintDistance_Click(object sender, EventArgs e)
        {
            OutBox.AppendText("Растояние до начала координат: " + point.CalcDistance() + "\n");
        }
    }
}
