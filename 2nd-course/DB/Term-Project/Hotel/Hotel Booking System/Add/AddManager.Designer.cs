namespace Hotel_Booking_System.Add
{
    partial class AddManager
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
            this.FormPasswordLabel = new System.Windows.Forms.Label();
            this.FormLoginLabel = new System.Windows.Forms.Label();
            this.FormPasswordBox = new System.Windows.Forms.TextBox();
            this.FormLoginBox = new System.Windows.Forms.TextBox();
            this.AddManagerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormPasswordLabel
            // 
            this.FormPasswordLabel.AutoSize = true;
            this.FormPasswordLabel.Location = new System.Drawing.Point(12, 41);
            this.FormPasswordLabel.Name = "FormPasswordLabel";
            this.FormPasswordLabel.Size = new System.Drawing.Size(45, 13);
            this.FormPasswordLabel.TabIndex = 12;
            this.FormPasswordLabel.Text = "Пароль";
            // 
            // FormLoginLabel
            // 
            this.FormLoginLabel.AutoSize = true;
            this.FormLoginLabel.Location = new System.Drawing.Point(12, 15);
            this.FormLoginLabel.Name = "FormLoginLabel";
            this.FormLoginLabel.Size = new System.Drawing.Size(38, 13);
            this.FormLoginLabel.TabIndex = 11;
            this.FormLoginLabel.Text = "Логин";
            // 
            // FormPasswordBox
            // 
            this.FormPasswordBox.Location = new System.Drawing.Point(85, 38);
            this.FormPasswordBox.MaxLength = 90;
            this.FormPasswordBox.Name = "FormPasswordBox";
            this.FormPasswordBox.PasswordChar = '*';
            this.FormPasswordBox.Size = new System.Drawing.Size(187, 20);
            this.FormPasswordBox.TabIndex = 10;
            // 
            // FormLoginBox
            // 
            this.FormLoginBox.Location = new System.Drawing.Point(85, 12);
            this.FormLoginBox.MaxLength = 90;
            this.FormLoginBox.Name = "FormLoginBox";
            this.FormLoginBox.Size = new System.Drawing.Size(187, 20);
            this.FormLoginBox.TabIndex = 9;
            // 
            // AddManagerButton
            // 
            this.AddManagerButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddManagerButton.Location = new System.Drawing.Point(85, 83);
            this.AddManagerButton.Name = "AddManagerButton";
            this.AddManagerButton.Size = new System.Drawing.Size(187, 35);
            this.AddManagerButton.TabIndex = 8;
            this.AddManagerButton.Text = "Создать";
            this.AddManagerButton.UseVisualStyleBackColor = false;
            this.AddManagerButton.Click += new System.EventHandler(this.AddManagerButton_Click);
            // 
            // AddManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.FormPasswordLabel);
            this.Controls.Add(this.FormLoginLabel);
            this.Controls.Add(this.FormPasswordBox);
            this.Controls.Add(this.FormLoginBox);
            this.Controls.Add(this.AddManagerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить менеджера";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FormPasswordLabel;
        private System.Windows.Forms.Label FormLoginLabel;
        private System.Windows.Forms.TextBox FormPasswordBox;
        private System.Windows.Forms.TextBox FormLoginBox;
        private System.Windows.Forms.Button AddManagerButton;
    }
}