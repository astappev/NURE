namespace Lab_4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutLogBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CreateWidthBox = new System.Windows.Forms.TextBox();
            this.CreateHeightBox = new System.Windows.Forms.TextBox();
            this.CalcPerimeterButton = new System.Windows.Forms.Button();
            this.CalcAreaButton = new System.Windows.Forms.Button();
            this.isSquareButton = new System.Windows.Forms.Button();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.ChengeWidthButton = new System.Windows.Forms.Button();
            this.ChengeHeightButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PrintLengthButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutLogBox
            // 
            this.OutLogBox.Location = new System.Drawing.Point(343, 41);
            this.OutLogBox.Multiline = true;
            this.OutLogBox.Name = "OutLogBox";
            this.OutLogBox.Size = new System.Drawing.Size(282, 173);
            this.OutLogBox.TabIndex = 0;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(252, 12);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 35);
            this.CreateButton.TabIndex = 1;
            this.CreateButton.Text = "Создать";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateWidthBox
            // 
            this.CreateWidthBox.Location = new System.Drawing.Point(12, 27);
            this.CreateWidthBox.Name = "CreateWidthBox";
            this.CreateWidthBox.Size = new System.Drawing.Size(116, 20);
            this.CreateWidthBox.TabIndex = 2;
            // 
            // CreateHeightBox
            // 
            this.CreateHeightBox.Location = new System.Drawing.Point(135, 27);
            this.CreateHeightBox.Name = "CreateHeightBox";
            this.CreateHeightBox.Size = new System.Drawing.Size(111, 20);
            this.CreateHeightBox.TabIndex = 3;
            // 
            // CalcPerimeterButton
            // 
            this.CalcPerimeterButton.Enabled = false;
            this.CalcPerimeterButton.Location = new System.Drawing.Point(12, 120);
            this.CalcPerimeterButton.Name = "CalcPerimeterButton";
            this.CalcPerimeterButton.Size = new System.Drawing.Size(161, 43);
            this.CalcPerimeterButton.TabIndex = 4;
            this.CalcPerimeterButton.Text = "Посчитать периметр";
            this.CalcPerimeterButton.UseVisualStyleBackColor = true;
            this.CalcPerimeterButton.Click += new System.EventHandler(this.CalcPerimeterButton_Click);
            // 
            // CalcAreaButton
            // 
            this.CalcAreaButton.Enabled = false;
            this.CalcAreaButton.Location = new System.Drawing.Point(179, 120);
            this.CalcAreaButton.Name = "CalcAreaButton";
            this.CalcAreaButton.Size = new System.Drawing.Size(148, 43);
            this.CalcAreaButton.TabIndex = 5;
            this.CalcAreaButton.Text = "Посчитать площадь";
            this.CalcAreaButton.UseVisualStyleBackColor = true;
            this.CalcAreaButton.Click += new System.EventHandler(this.CalcAreaButton_Click);
            // 
            // isSquareButton
            // 
            this.isSquareButton.Enabled = false;
            this.isSquareButton.Location = new System.Drawing.Point(13, 170);
            this.isSquareButton.Name = "isSquareButton";
            this.isSquareButton.Size = new System.Drawing.Size(314, 44);
            this.isSquareButton.TabIndex = 6;
            this.isSquareButton.Text = "Проверить квадратность";
            this.isSquareButton.UseVisualStyleBackColor = true;
            this.isSquareButton.Click += new System.EventHandler(this.isSquareButton_Click);
            // 
            // WidthBox
            // 
            this.WidthBox.Enabled = false;
            this.WidthBox.Location = new System.Drawing.Point(13, 68);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(164, 20);
            this.WidthBox.TabIndex = 7;
            // 
            // HeightBox
            // 
            this.HeightBox.Enabled = false;
            this.HeightBox.Location = new System.Drawing.Point(13, 94);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(164, 20);
            this.HeightBox.TabIndex = 8;
            // 
            // ChengeWidthButton
            // 
            this.ChengeWidthButton.Enabled = false;
            this.ChengeWidthButton.Location = new System.Drawing.Point(183, 67);
            this.ChengeWidthButton.Name = "ChengeWidthButton";
            this.ChengeWidthButton.Size = new System.Drawing.Size(144, 21);
            this.ChengeWidthButton.TabIndex = 9;
            this.ChengeWidthButton.Text = "Изменить ширину";
            this.ChengeWidthButton.UseVisualStyleBackColor = true;
            this.ChengeWidthButton.Click += new System.EventHandler(this.ChengeWidthButton_Click);
            // 
            // ChengeHeightButton
            // 
            this.ChengeHeightButton.Enabled = false;
            this.ChengeHeightButton.Location = new System.Drawing.Point(183, 93);
            this.ChengeHeightButton.Name = "ChengeHeightButton";
            this.ChengeHeightButton.Size = new System.Drawing.Size(144, 21);
            this.ChengeHeightButton.TabIndex = 10;
            this.ChengeHeightButton.Text = "Изменить высоту";
            this.ChengeHeightButton.UseVisualStyleBackColor = true;
            this.ChengeHeightButton.Click += new System.EventHandler(this.ChengeHeightButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ширина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Высота";
            // 
            // PrintLengthButton
            // 
            this.PrintLengthButton.Enabled = false;
            this.PrintLengthButton.Location = new System.Drawing.Point(343, 12);
            this.PrintLengthButton.Name = "PrintLengthButton";
            this.PrintLengthButton.Size = new System.Drawing.Size(282, 23);
            this.PrintLengthButton.TabIndex = 13;
            this.PrintLengthButton.Text = "Вывод значений";
            this.PrintLengthButton.UseVisualStyleBackColor = true;
            this.PrintLengthButton.Click += new System.EventHandler(this.PrintLengthButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 226);
            this.Controls.Add(this.PrintLengthButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChengeHeightButton);
            this.Controls.Add(this.ChengeWidthButton);
            this.Controls.Add(this.HeightBox);
            this.Controls.Add(this.WidthBox);
            this.Controls.Add(this.isSquareButton);
            this.Controls.Add(this.CalcAreaButton);
            this.Controls.Add(this.CalcPerimeterButton);
            this.Controls.Add(this.CreateHeightBox);
            this.Controls.Add(this.CreateWidthBox);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.OutLogBox);
            this.Name = "Form1";
            this.Text = "ЛБ 4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutLogBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox CreateWidthBox;
        private System.Windows.Forms.TextBox CreateHeightBox;
        private System.Windows.Forms.Button CalcPerimeterButton;
        private System.Windows.Forms.Button CalcAreaButton;
        private System.Windows.Forms.Button isSquareButton;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.Button ChengeWidthButton;
        private System.Windows.Forms.Button ChengeHeightButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PrintLengthButton;
    }
}