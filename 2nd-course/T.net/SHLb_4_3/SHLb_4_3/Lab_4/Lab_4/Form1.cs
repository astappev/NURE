using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClass;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        MyClass.Rectangle figure;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (CreateWidthBox.Text != String.Empty && CreateHeightBox.Text != String.Empty)
            {
                figure = new MyClass.Rectangle(int.Parse(CreateWidthBox.Text), int.Parse(CreateHeightBox.Text));
                OutLogBox.AppendText("Создана фигура, с шириной " + CreateWidthBox.Text + ", высотой " + CreateHeightBox.Text + ".\n");
            }

            PrintLengthButton.Enabled = true;
            ChengeWidthButton.Enabled = true;
            ChengeHeightButton.Enabled = true;
            CalcPerimeterButton.Enabled = true;
            CalcAreaButton.Enabled = true;
            isSquareButton.Enabled = true;
            WidthBox.Enabled = true;
            HeightBox.Enabled = true;

            CreateButton.Enabled = false;
        }

        private void PrintLengthButton_Click(object sender, EventArgs e)
        {
            OutLogBox.AppendText(figure.PrintLength() + "\n");
        }

        private void ChengeWidthButton_Click(object sender, EventArgs e)
        {
            if (WidthBox.Text != String.Empty)
                figure.Width = int.Parse(WidthBox.Text);
        }

        private void ChengeHeightButton_Click(object sender, EventArgs e)
        {
            if (HeightBox.Text != String.Empty)
                figure.Height = int.Parse(HeightBox.Text);
        }

        private void CalcPerimeterButton_Click(object sender, EventArgs e)
        {
            OutLogBox.AppendText("Перимерт фигуры: " + figure.CalcPerimeter() + "\n");
        }

        private void CalcAreaButton_Click(object sender, EventArgs e)
        {
            OutLogBox.AppendText("Площадь фигуры: " + figure.CalcArea() + "\n");
        }

        private void isSquareButton_Click(object sender, EventArgs e)
        {
            if(figure.isSquare)
                OutLogBox.AppendText("Данная фигура - квадрат.\n");
            else
                OutLogBox.AppendText("Данная фигура НЕ квадрат.\n");
        }
    }
}
