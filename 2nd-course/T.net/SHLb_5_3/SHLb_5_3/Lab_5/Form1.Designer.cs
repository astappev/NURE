namespace Lab_5
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
            this.From1Button = new System.Windows.Forms.Button();
            this.To1Button = new System.Windows.Forms.Button();
            this.From2Button = new System.Windows.Forms.Button();
            this.From3Button = new System.Windows.Forms.Button();
            this.From1Label = new System.Windows.Forms.Label();
            this.From2Label = new System.Windows.Forms.Label();
            this.From3Label = new System.Windows.Forms.Label();
            this.To1Label = new System.Windows.Forms.Label();
            this.CalcButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.To2Label = new System.Windows.Forms.Label();
            this.To2Button = new System.Windows.Forms.Button();
            this.To3Label = new System.Windows.Forms.Label();
            this.To3Button = new System.Windows.Forms.Button();
            this.DigitBox = new System.Windows.Forms.TextBox();
            this.DigitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // From1Button
            // 
            this.From1Button.Location = new System.Drawing.Point(13, 13);
            this.From1Button.Name = "From1Button";
            this.From1Button.Size = new System.Drawing.Size(75, 23);
            this.From1Button.TabIndex = 0;
            this.From1Button.Text = "Источник 1";
            this.From1Button.UseVisualStyleBackColor = true;
            this.From1Button.Click += new System.EventHandler(this.From1Button_Click);
            // 
            // To1Button
            // 
            this.To1Button.Location = new System.Drawing.Point(409, 13);
            this.To1Button.Name = "To1Button";
            this.To1Button.Size = new System.Drawing.Size(87, 23);
            this.To1Button.TabIndex = 1;
            this.To1Button.Text = "Назначение 1";
            this.To1Button.UseVisualStyleBackColor = true;
            this.To1Button.Click += new System.EventHandler(this.To1Button_Click);
            // 
            // From2Button
            // 
            this.From2Button.Location = new System.Drawing.Point(13, 43);
            this.From2Button.Name = "From2Button";
            this.From2Button.Size = new System.Drawing.Size(75, 23);
            this.From2Button.TabIndex = 2;
            this.From2Button.Text = "Источник 2";
            this.From2Button.UseVisualStyleBackColor = true;
            this.From2Button.Click += new System.EventHandler(this.From2Button_Click);
            // 
            // From3Button
            // 
            this.From3Button.Location = new System.Drawing.Point(13, 73);
            this.From3Button.Name = "From3Button";
            this.From3Button.Size = new System.Drawing.Size(75, 23);
            this.From3Button.TabIndex = 3;
            this.From3Button.Text = "Источник 3";
            this.From3Button.UseVisualStyleBackColor = true;
            this.From3Button.Click += new System.EventHandler(this.From3Button_Click);
            // 
            // From1Label
            // 
            this.From1Label.AutoSize = true;
            this.From1Label.Location = new System.Drawing.Point(94, 18);
            this.From1Label.Name = "From1Label";
            this.From1Label.Size = new System.Drawing.Size(60, 13);
            this.From1Label.TabIndex = 4;
            this.From1Label.Text = "не выбран";
            // 
            // From2Label
            // 
            this.From2Label.AutoSize = true;
            this.From2Label.Location = new System.Drawing.Point(94, 48);
            this.From2Label.Name = "From2Label";
            this.From2Label.Size = new System.Drawing.Size(60, 13);
            this.From2Label.TabIndex = 5;
            this.From2Label.Text = "не выбран";
            // 
            // From3Label
            // 
            this.From3Label.AutoSize = true;
            this.From3Label.Location = new System.Drawing.Point(94, 78);
            this.From3Label.Name = "From3Label";
            this.From3Label.Size = new System.Drawing.Size(60, 13);
            this.From3Label.TabIndex = 6;
            this.From3Label.Text = "не выбран";
            // 
            // To1Label
            // 
            this.To1Label.AutoSize = true;
            this.To1Label.Location = new System.Drawing.Point(502, 18);
            this.To1Label.Name = "To1Label";
            this.To1Label.Size = new System.Drawing.Size(60, 13);
            this.To1Label.TabIndex = 7;
            this.To1Label.Text = "не выбран";
            // 
            // CalcButton
            // 
            this.CalcButton.Enabled = false;
            this.CalcButton.Location = new System.Drawing.Point(13, 122);
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.Size = new System.Drawing.Size(586, 34);
            this.CalcButton.TabIndex = 8;
            this.CalcButton.Text = "Подсчитать";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text file (*.txt) | *txt";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "Text file (*.txt) | *txt";
            this.saveFileDialog.Filter = "Text file (*.txt) | *txt";
            // 
            // To2Label
            // 
            this.To2Label.AutoSize = true;
            this.To2Label.Location = new System.Drawing.Point(502, 48);
            this.To2Label.Name = "To2Label";
            this.To2Label.Size = new System.Drawing.Size(60, 13);
            this.To2Label.TabIndex = 10;
            this.To2Label.Text = "не выбран";
            // 
            // To2Button
            // 
            this.To2Button.Location = new System.Drawing.Point(409, 43);
            this.To2Button.Name = "To2Button";
            this.To2Button.Size = new System.Drawing.Size(87, 23);
            this.To2Button.TabIndex = 9;
            this.To2Button.Text = "Назначение 2";
            this.To2Button.UseVisualStyleBackColor = true;
            this.To2Button.Click += new System.EventHandler(this.To2Button_Click);
            // 
            // To3Label
            // 
            this.To3Label.AutoSize = true;
            this.To3Label.Location = new System.Drawing.Point(502, 78);
            this.To3Label.Name = "To3Label";
            this.To3Label.Size = new System.Drawing.Size(60, 13);
            this.To3Label.TabIndex = 12;
            this.To3Label.Text = "не выбран";
            // 
            // To3Button
            // 
            this.To3Button.Location = new System.Drawing.Point(409, 73);
            this.To3Button.Name = "To3Button";
            this.To3Button.Size = new System.Drawing.Size(87, 23);
            this.To3Button.TabIndex = 11;
            this.To3Button.Text = "Назначение 3";
            this.To3Button.UseVisualStyleBackColor = true;
            this.To3Button.Click += new System.EventHandler(this.To3Button_Click);
            // 
            // DigitBox
            // 
            this.DigitBox.Location = new System.Drawing.Point(234, 39);
            this.DigitBox.Name = "DigitBox";
            this.DigitBox.Size = new System.Drawing.Size(100, 20);
            this.DigitBox.TabIndex = 13;
            this.DigitBox.TextChanged += new System.EventHandler(this.DigitBox_TextChanged);
            this.DigitBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitBox_KeyPress);
            // 
            // DigitLabel
            // 
            this.DigitLabel.Location = new System.Drawing.Point(234, 13);
            this.DigitLabel.Name = "DigitLabel";
            this.DigitLabel.Size = new System.Drawing.Size(100, 23);
            this.DigitLabel.TabIndex = 14;
            this.DigitLabel.Text = "Магическое число";
            this.DigitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 169);
            this.Controls.Add(this.DigitLabel);
            this.Controls.Add(this.DigitBox);
            this.Controls.Add(this.To3Label);
            this.Controls.Add(this.To3Button);
            this.Controls.Add(this.To2Label);
            this.Controls.Add(this.To2Button);
            this.Controls.Add(this.CalcButton);
            this.Controls.Add(this.To1Label);
            this.Controls.Add(this.From3Label);
            this.Controls.Add(this.From2Label);
            this.Controls.Add(this.From1Label);
            this.Controls.Add(this.From3Button);
            this.Controls.Add(this.From2Button);
            this.Controls.Add(this.To1Button);
            this.Controls.Add(this.From1Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Лаб 5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button From1Button;
        private System.Windows.Forms.Button To1Button;
        private System.Windows.Forms.Button From2Button;
        private System.Windows.Forms.Button From3Button;
        private System.Windows.Forms.Label From1Label;
        private System.Windows.Forms.Label From2Label;
        private System.Windows.Forms.Label From3Label;
        private System.Windows.Forms.Label To1Label;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label To2Label;
        private System.Windows.Forms.Button To2Button;
        private System.Windows.Forms.Button To3Button;
        private System.Windows.Forms.Label To3Label;
        private System.Windows.Forms.TextBox DigitBox;
        private System.Windows.Forms.Label DigitLabel;
    }
}

