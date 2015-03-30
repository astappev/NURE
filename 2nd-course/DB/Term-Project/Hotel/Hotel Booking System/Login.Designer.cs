namespace Hotel_Booking_System
{
    partial class Login
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
            this.LoginForm_login = new System.Windows.Forms.TextBox();
            this.LoginForm_password = new System.Windows.Forms.TextBox();
            this.LoginForm_buttonLogin = new System.Windows.Forms.Button();
            this.LoginForm_LabelLogin = new System.Windows.Forms.Label();
            this.LoginForm_LabelPassword = new System.Windows.Forms.Label();
            this.LoginForm_LabelMain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginForm_login
            // 
            this.LoginForm_login.BackColor = System.Drawing.SystemColors.Info;
            this.LoginForm_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginForm_login.Location = new System.Drawing.Point(87, 90);
            this.LoginForm_login.Name = "LoginForm_login";
            this.LoginForm_login.Size = new System.Drawing.Size(149, 20);
            this.LoginForm_login.TabIndex = 0;
            this.LoginForm_login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // LoginForm_password
            // 
            this.LoginForm_password.BackColor = System.Drawing.SystemColors.Info;
            this.LoginForm_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginForm_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LoginForm_password.Location = new System.Drawing.Point(87, 125);
            this.LoginForm_password.Name = "LoginForm_password";
            this.LoginForm_password.PasswordChar = '*';
            this.LoginForm_password.Size = new System.Drawing.Size(149, 20);
            this.LoginForm_password.TabIndex = 1;
            this.LoginForm_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // LoginForm_buttonLogin
            // 
            this.LoginForm_buttonLogin.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.LoginForm_buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginForm_buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginForm_buttonLogin.ForeColor = System.Drawing.Color.SaddleBrown;
            this.LoginForm_buttonLogin.Location = new System.Drawing.Point(10, 170);
            this.LoginForm_buttonLogin.Name = "LoginForm_buttonLogin";
            this.LoginForm_buttonLogin.Size = new System.Drawing.Size(226, 40);
            this.LoginForm_buttonLogin.TabIndex = 2;
            this.LoginForm_buttonLogin.Text = "Войти";
            this.LoginForm_buttonLogin.UseVisualStyleBackColor = false;
            this.LoginForm_buttonLogin.Click += new System.EventHandler(this.LoginForm_buttonLogin_Click);
            // 
            // LoginForm_LabelLogin
            // 
            this.LoginForm_LabelLogin.AutoSize = true;
            this.LoginForm_LabelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginForm_LabelLogin.Location = new System.Drawing.Point(12, 90);
            this.LoginForm_LabelLogin.Name = "LoginForm_LabelLogin";
            this.LoginForm_LabelLogin.Size = new System.Drawing.Size(44, 15);
            this.LoginForm_LabelLogin.TabIndex = 3;
            this.LoginForm_LabelLogin.Text = "Логин:";
            // 
            // LoginForm_LabelPassword
            // 
            this.LoginForm_LabelPassword.AutoSize = true;
            this.LoginForm_LabelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginForm_LabelPassword.Location = new System.Drawing.Point(12, 125);
            this.LoginForm_LabelPassword.Name = "LoginForm_LabelPassword";
            this.LoginForm_LabelPassword.Size = new System.Drawing.Size(54, 15);
            this.LoginForm_LabelPassword.TabIndex = 4;
            this.LoginForm_LabelPassword.Text = "Пароль:";
            // 
            // LoginForm_LabelMain
            // 
            this.LoginForm_LabelMain.Location = new System.Drawing.Point(10, 10);
            this.LoginForm_LabelMain.Margin = new System.Windows.Forms.Padding(0);
            this.LoginForm_LabelMain.Name = "LoginForm_LabelMain";
            this.LoginForm_LabelMain.Size = new System.Drawing.Size(226, 70);
            this.LoginForm_LabelMain.TabIndex = 5;
            this.LoginForm_LabelMain.Text = "Для использования билинговой системы управления и учета проживающих в гостинице г" +
    "раждан, вам необходимо авторизоваться.";
            this.LoginForm_LabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(244, 221);
            this.Controls.Add(this.LoginForm_LabelMain);
            this.Controls.Add(this.LoginForm_LabelPassword);
            this.Controls.Add(this.LoginForm_LabelLogin);
            this.Controls.Add(this.LoginForm_buttonLogin);
            this.Controls.Add(this.LoginForm_password);
            this.Controls.Add(this.LoginForm_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аутентификация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginForm_login;
        private System.Windows.Forms.TextBox LoginForm_password;
        private System.Windows.Forms.Button LoginForm_buttonLogin;
        private System.Windows.Forms.Label LoginForm_LabelLogin;
        private System.Windows.Forms.Label LoginForm_LabelPassword;
        private System.Windows.Forms.Label LoginForm_LabelMain;
    }
}