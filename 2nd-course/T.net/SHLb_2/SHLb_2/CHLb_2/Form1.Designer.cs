namespace CHLb_2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox = new System.Windows.Forms.TextBox();
            this.count = new System.Windows.Forms.Button();
            this.countBox = new System.Windows.Forms.TextBox();
            this.count_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minBox = new System.Windows.Forms.TextBox();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(12, 12);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(87, 33);
            this.open.TabIndex = 0;
            this.open.Text = "Открыть";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(187, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(85, 33);
            this.save.TabIndex = 1;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 51);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(260, 172);
            this.textBox.TabIndex = 2;
            // 
            // count
            // 
            this.count.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.count.Location = new System.Drawing.Point(105, 12);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(76, 33);
            this.count.TabIndex = 3;
            this.count.Text = "Посчитать";
            this.count.UseVisualStyleBackColor = false;
            this.count.Click += new System.EventHandler(this.count_Click);
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(120, 229);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(152, 20);
            this.countBox.TabIndex = 4;
            // 
            // count_label
            // 
            this.count_label.AutoSize = true;
            this.count_label.Location = new System.Drawing.Point(13, 232);
            this.count_label.Name = "count_label";
            this.count_label.Size = new System.Drawing.Size(101, 13);
            this.count_label.TabIndex = 5;
            this.count_label.Text = "Количество чисел:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Мин.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Макс.:";
            // 
            // minBox
            // 
            this.minBox.Location = new System.Drawing.Point(54, 256);
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(86, 20);
            this.minBox.TabIndex = 8;
            // 
            // maxBox
            // 
            this.maxBox.Location = new System.Drawing.Point(192, 255);
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(80, 20);
            this.maxBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 283);
            this.Controls.Add(this.maxBox);
            this.Controls.Add(this.minBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.count_label);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.count);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Name = "Form1";
            this.Text = "Лабораторная #2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button count;
        private System.Windows.Forms.TextBox countBox;
        private System.Windows.Forms.Label count_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox minBox;
        private System.Windows.Forms.TextBox maxBox;
    }
}

