namespace SHLb_4
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
            this.CreateClass = new System.Windows.Forms.Button();
            this.PrintDistance = new System.Windows.Forms.Button();
            this.MovePoint = new System.Windows.Forms.Button();
            this.SetCord = new System.Windows.Forms.Button();
            this.OutBox = new System.Windows.Forms.TextBox();
            this.PrintCord = new System.Windows.Forms.Button();
            this.create_x = new System.Windows.Forms.TextBox();
            this.create_y = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vector_b = new System.Windows.Forms.TextBox();
            this.vector_a = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.set_y = new System.Windows.Forms.TextBox();
            this.set_x = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CreateClass
            // 
            this.CreateClass.Location = new System.Drawing.Point(12, 12);
            this.CreateClass.Name = "CreateClass";
            this.CreateClass.Size = new System.Drawing.Size(219, 23);
            this.CreateClass.TabIndex = 0;
            this.CreateClass.Text = "Создать класс";
            this.CreateClass.UseVisualStyleBackColor = true;
            this.CreateClass.Click += new System.EventHandler(this.CreateClass_Click);
            // 
            // PrintDistance
            // 
            this.PrintDistance.Enabled = false;
            this.PrintDistance.Location = new System.Drawing.Point(241, 41);
            this.PrintDistance.Name = "PrintDistance";
            this.PrintDistance.Size = new System.Drawing.Size(231, 23);
            this.PrintDistance.TabIndex = 1;
            this.PrintDistance.Text = "Вывести растояние до начала координат";
            this.PrintDistance.UseVisualStyleBackColor = true;
            this.PrintDistance.Click += new System.EventHandler(this.PrintDistance_Click);
            // 
            // MovePoint
            // 
            this.MovePoint.Enabled = false;
            this.MovePoint.Location = new System.Drawing.Point(12, 101);
            this.MovePoint.Name = "MovePoint";
            this.MovePoint.Size = new System.Drawing.Size(219, 25);
            this.MovePoint.TabIndex = 2;
            this.MovePoint.Text = "Переместить точку на вектор";
            this.MovePoint.UseVisualStyleBackColor = true;
            this.MovePoint.Click += new System.EventHandler(this.MovePoint_Click);
            // 
            // SetCord
            // 
            this.SetCord.Enabled = false;
            this.SetCord.Location = new System.Drawing.Point(12, 186);
            this.SetCord.Name = "SetCord";
            this.SetCord.Size = new System.Drawing.Size(219, 25);
            this.SetCord.TabIndex = 3;
            this.SetCord.Text = "Установить координаты точки";
            this.SetCord.UseVisualStyleBackColor = true;
            this.SetCord.Click += new System.EventHandler(this.SetCord_Click);
            // 
            // OutBox
            // 
            this.OutBox.Location = new System.Drawing.Point(241, 70);
            this.OutBox.Multiline = true;
            this.OutBox.Name = "OutBox";
            this.OutBox.Size = new System.Drawing.Size(231, 183);
            this.OutBox.TabIndex = 4;
            // 
            // PrintCord
            // 
            this.PrintCord.Enabled = false;
            this.PrintCord.Location = new System.Drawing.Point(241, 12);
            this.PrintCord.Name = "PrintCord";
            this.PrintCord.Size = new System.Drawing.Size(231, 23);
            this.PrintCord.TabIndex = 5;
            this.PrintCord.Text = "Вывести текущие координаты";
            this.PrintCord.UseVisualStyleBackColor = true;
            this.PrintCord.Click += new System.EventHandler(this.PrintCord_Click);
            // 
            // create_x
            // 
            this.create_x.Location = new System.Drawing.Point(35, 57);
            this.create_x.Name = "create_x";
            this.create_x.Size = new System.Drawing.Size(73, 20);
            this.create_x.TabIndex = 7;
            // 
            // create_y
            // 
            this.create_y.Location = new System.Drawing.Point(137, 57);
            this.create_y.Name = "create_y";
            this.create_y.Size = new System.Drawing.Size(94, 20);
            this.create_y.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "b:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "a:";
            // 
            // vector_b
            // 
            this.vector_b.Location = new System.Drawing.Point(137, 150);
            this.vector_b.Name = "vector_b";
            this.vector_b.Size = new System.Drawing.Size(94, 20);
            this.vector_b.TabIndex = 12;
            // 
            // vector_a
            // 
            this.vector_a.Location = new System.Drawing.Point(35, 150);
            this.vector_a.Name = "vector_a";
            this.vector_a.Size = new System.Drawing.Size(73, 20);
            this.vector_a.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Вектор";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Начальные координаты";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Координаты точки";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Y:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "X:";
            // 
            // set_y
            // 
            this.set_y.Location = new System.Drawing.Point(137, 233);
            this.set_y.Name = "set_y";
            this.set_y.Size = new System.Drawing.Size(94, 20);
            this.set_y.TabIndex = 18;
            // 
            // set_x
            // 
            this.set_x.Location = new System.Drawing.Point(35, 233);
            this.set_x.Name = "set_x";
            this.set_x.Size = new System.Drawing.Size(73, 20);
            this.set_x.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 268);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.set_y);
            this.Controls.Add(this.set_x);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vector_b);
            this.Controls.Add(this.vector_a);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.create_y);
            this.Controls.Add(this.create_x);
            this.Controls.Add(this.PrintCord);
            this.Controls.Add(this.OutBox);
            this.Controls.Add(this.SetCord);
            this.Controls.Add(this.MovePoint);
            this.Controls.Add(this.PrintDistance);
            this.Controls.Add(this.CreateClass);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateClass;
        private System.Windows.Forms.Button PrintDistance;
        private System.Windows.Forms.Button MovePoint;
        private System.Windows.Forms.Button SetCord;
        private System.Windows.Forms.TextBox OutBox;
        private System.Windows.Forms.Button PrintCord;
        private System.Windows.Forms.TextBox create_x;
        private System.Windows.Forms.TextBox create_y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vector_b;
        private System.Windows.Forms.TextBox vector_a;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox set_y;
        private System.Windows.Forms.TextBox set_x;
    }
}