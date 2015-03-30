namespace Hotel_Booking_System.Add
{
    partial class AddClient
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
            this.AddClientButton = new System.Windows.Forms.Button();
            this.FormFirstName = new System.Windows.Forms.TextBox();
            this.FormLastName = new System.Windows.Forms.TextBox();
            this.FormPatronymic = new System.Windows.Forms.TextBox();
            this.FormFirstNameLabel = new System.Windows.Forms.Label();
            this.FormLastNameLabel = new System.Windows.Forms.Label();
            this.FormPatronymicLabel = new System.Windows.Forms.Label();
            this.FormDocNumber = new System.Windows.Forms.TextBox();
            this.FormGender = new System.Windows.Forms.ComboBox();
            this.FormBirthday = new System.Windows.Forms.DateTimePicker();
            this.FormDocType = new System.Windows.Forms.ComboBox();
            this.FormAdress = new System.Windows.Forms.TextBox();
            this.FormPhone = new System.Windows.Forms.TextBox();
            this.FormGenderLebel = new System.Windows.Forms.Label();
            this.FormBirthdayLebel = new System.Windows.Forms.Label();
            this.FormDocTypeLabel = new System.Windows.Forms.Label();
            this.FormDocNumberLabel = new System.Windows.Forms.Label();
            this.FormAdressLabel = new System.Windows.Forms.Label();
            this.FormPhoneLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddClientButton
            // 
            this.AddClientButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.AddClientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddClientButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.AddClientButton.Location = new System.Drawing.Point(142, 276);
            this.AddClientButton.Name = "AddClientButton";
            this.AddClientButton.Size = new System.Drawing.Size(187, 35);
            this.AddClientButton.TabIndex = 0;
            this.AddClientButton.Text = "Добавить";
            this.AddClientButton.UseVisualStyleBackColor = false;
            this.AddClientButton.Click += new System.EventHandler(this.AddClientButton_Click);
            // 
            // FormFirstName
            // 
            this.FormFirstName.BackColor = System.Drawing.SystemColors.Info;
            this.FormFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormFirstName.Location = new System.Drawing.Point(142, 12);
            this.FormFirstName.MaxLength = 90;
            this.FormFirstName.Name = "FormFirstName";
            this.FormFirstName.Size = new System.Drawing.Size(187, 20);
            this.FormFirstName.TabIndex = 2;
            // 
            // FormLastName
            // 
            this.FormLastName.BackColor = System.Drawing.SystemColors.Info;
            this.FormLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormLastName.Location = new System.Drawing.Point(142, 38);
            this.FormLastName.MaxLength = 90;
            this.FormLastName.Name = "FormLastName";
            this.FormLastName.Size = new System.Drawing.Size(187, 20);
            this.FormLastName.TabIndex = 3;
            // 
            // FormPatronymic
            // 
            this.FormPatronymic.BackColor = System.Drawing.SystemColors.Info;
            this.FormPatronymic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormPatronymic.Location = new System.Drawing.Point(142, 64);
            this.FormPatronymic.MaxLength = 90;
            this.FormPatronymic.Name = "FormPatronymic";
            this.FormPatronymic.Size = new System.Drawing.Size(187, 20);
            this.FormPatronymic.TabIndex = 4;
            // 
            // FormFirstNameLabel
            // 
            this.FormFirstNameLabel.AutoSize = true;
            this.FormFirstNameLabel.Location = new System.Drawing.Point(13, 15);
            this.FormFirstNameLabel.Name = "FormFirstNameLabel";
            this.FormFirstNameLabel.Size = new System.Drawing.Size(56, 13);
            this.FormFirstNameLabel.TabIndex = 6;
            this.FormFirstNameLabel.Text = "Фамилия";
            // 
            // FormLastNameLabel
            // 
            this.FormLastNameLabel.AutoSize = true;
            this.FormLastNameLabel.Location = new System.Drawing.Point(13, 41);
            this.FormLastNameLabel.Name = "FormLastNameLabel";
            this.FormLastNameLabel.Size = new System.Drawing.Size(29, 13);
            this.FormLastNameLabel.TabIndex = 7;
            this.FormLastNameLabel.Text = "Имя";
            // 
            // FormPatronymicLabel
            // 
            this.FormPatronymicLabel.AutoSize = true;
            this.FormPatronymicLabel.Location = new System.Drawing.Point(13, 67);
            this.FormPatronymicLabel.Name = "FormPatronymicLabel";
            this.FormPatronymicLabel.Size = new System.Drawing.Size(54, 13);
            this.FormPatronymicLabel.TabIndex = 8;
            this.FormPatronymicLabel.Text = "Отчество";
            // 
            // FormDocNumber
            // 
            this.FormDocNumber.BackColor = System.Drawing.SystemColors.Info;
            this.FormDocNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormDocNumber.Location = new System.Drawing.Point(142, 170);
            this.FormDocNumber.MaxLength = 30;
            this.FormDocNumber.Name = "FormDocNumber";
            this.FormDocNumber.Size = new System.Drawing.Size(187, 20);
            this.FormDocNumber.TabIndex = 10;
            // 
            // FormGender
            // 
            this.FormGender.BackColor = System.Drawing.SystemColors.Info;
            this.FormGender.DisplayMember = "Name";
            this.FormGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormGender.FormattingEnabled = true;
            this.FormGender.Location = new System.Drawing.Point(142, 90);
            this.FormGender.Name = "FormGender";
            this.FormGender.Size = new System.Drawing.Size(187, 21);
            this.FormGender.TabIndex = 11;
            this.FormGender.ValueMember = "ID";
            // 
            // FormBirthday
            // 
            this.FormBirthday.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.FormBirthday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBirthday.Location = new System.Drawing.Point(142, 117);
            this.FormBirthday.MaxDate = System.DateTime.Now.AddYears(-18);
            this.FormBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.FormBirthday.Name = "FormBirthday";
            this.FormBirthday.Size = new System.Drawing.Size(187, 20);
            this.FormBirthday.TabIndex = 12;
            //this.FormBirthday.Value = new System.DateTime(2014, 5, 26, 0, 0, 0, 0);
            // 
            // FormDocType
            // 
            this.FormDocType.BackColor = System.Drawing.SystemColors.Info;
            this.FormDocType.DisplayMember = "Name";
            this.FormDocType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormDocType.FormattingEnabled = true;
            this.FormDocType.Location = new System.Drawing.Point(142, 143);
            this.FormDocType.Name = "FormDocType";
            this.FormDocType.Size = new System.Drawing.Size(187, 21);
            this.FormDocType.TabIndex = 13;
            this.FormDocType.ValueMember = "ID";
            // 
            // FormAdress
            // 
            this.FormAdress.BackColor = System.Drawing.SystemColors.Info;
            this.FormAdress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormAdress.Location = new System.Drawing.Point(142, 196);
            this.FormAdress.MaxLength = 128;
            this.FormAdress.Name = "FormAdress";
            this.FormAdress.Size = new System.Drawing.Size(187, 20);
            this.FormAdress.TabIndex = 14;
            // 
            // FormPhone
            // 
            this.FormPhone.BackColor = System.Drawing.SystemColors.Info;
            this.FormPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormPhone.Location = new System.Drawing.Point(142, 222);
            this.FormPhone.MaxLength = 14;
            this.FormPhone.Name = "FormPhone";
            this.FormPhone.Size = new System.Drawing.Size(187, 20);
            this.FormPhone.TabIndex = 15;
            this.FormPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPhone_KeyPress);
            // 
            // FormGenderLebel
            // 
            this.FormGenderLebel.AutoSize = true;
            this.FormGenderLebel.Location = new System.Drawing.Point(13, 93);
            this.FormGenderLebel.Name = "FormGenderLebel";
            this.FormGenderLebel.Size = new System.Drawing.Size(27, 13);
            this.FormGenderLebel.TabIndex = 16;
            this.FormGenderLebel.Text = "Пол";
            // 
            // FormBirthdayLebel
            // 
            this.FormBirthdayLebel.AutoSize = true;
            this.FormBirthdayLebel.Location = new System.Drawing.Point(13, 119);
            this.FormBirthdayLebel.Name = "FormBirthdayLebel";
            this.FormBirthdayLebel.Size = new System.Drawing.Size(86, 13);
            this.FormBirthdayLebel.TabIndex = 17;
            this.FormBirthdayLebel.Text = "Дата рождения";
            // 
            // FormDocTypeLabel
            // 
            this.FormDocTypeLabel.AutoSize = true;
            this.FormDocTypeLabel.Location = new System.Drawing.Point(13, 146);
            this.FormDocTypeLabel.Name = "FormDocTypeLabel";
            this.FormDocTypeLabel.Size = new System.Drawing.Size(83, 13);
            this.FormDocTypeLabel.TabIndex = 18;
            this.FormDocTypeLabel.Text = "Тип документа";
            // 
            // FormDocNumberLabel
            // 
            this.FormDocNumberLabel.AutoSize = true;
            this.FormDocNumberLabel.Location = new System.Drawing.Point(13, 173);
            this.FormDocNumberLabel.Name = "FormDocNumberLabel";
            this.FormDocNumberLabel.Size = new System.Drawing.Size(98, 13);
            this.FormDocNumberLabel.TabIndex = 19;
            this.FormDocNumberLabel.Text = "Номер документа";
            // 
            // FormAdressLabel
            // 
            this.FormAdressLabel.AutoSize = true;
            this.FormAdressLabel.Location = new System.Drawing.Point(13, 199);
            this.FormAdressLabel.Name = "FormAdressLabel";
            this.FormAdressLabel.Size = new System.Drawing.Size(38, 13);
            this.FormAdressLabel.TabIndex = 20;
            this.FormAdressLabel.Text = "Адрес";
            // 
            // FormPhoneLabel
            // 
            this.FormPhoneLabel.AutoSize = true;
            this.FormPhoneLabel.Location = new System.Drawing.Point(13, 225);
            this.FormPhoneLabel.Name = "FormPhoneLabel";
            this.FormPhoneLabel.Size = new System.Drawing.Size(52, 13);
            this.FormPhoneLabel.TabIndex = 21;
            this.FormPhoneLabel.Text = "Телефон";
            // 
            // AddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(341, 323);
            this.Controls.Add(this.FormPhoneLabel);
            this.Controls.Add(this.FormAdressLabel);
            this.Controls.Add(this.FormDocNumberLabel);
            this.Controls.Add(this.FormDocTypeLabel);
            this.Controls.Add(this.FormBirthdayLebel);
            this.Controls.Add(this.FormGenderLebel);
            this.Controls.Add(this.FormPhone);
            this.Controls.Add(this.FormAdress);
            this.Controls.Add(this.FormDocType);
            this.Controls.Add(this.FormBirthday);
            this.Controls.Add(this.FormGender);
            this.Controls.Add(this.FormDocNumber);
            this.Controls.Add(this.FormPatronymicLabel);
            this.Controls.Add(this.FormLastNameLabel);
            this.Controls.Add(this.FormFirstNameLabel);
            this.Controls.Add(this.FormPatronymic);
            this.Controls.Add(this.FormLastName);
            this.Controls.Add(this.FormFirstName);
            this.Controls.Add(this.AddClientButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление клиента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddClientButton;
        private System.Windows.Forms.TextBox FormFirstName;
        private System.Windows.Forms.TextBox FormLastName;
        private System.Windows.Forms.TextBox FormPatronymic;
        private System.Windows.Forms.Label FormFirstNameLabel;
        private System.Windows.Forms.Label FormLastNameLabel;
        private System.Windows.Forms.Label FormPatronymicLabel;
        private System.Windows.Forms.TextBox FormDocNumber;
        private System.Windows.Forms.ComboBox FormGender;
        private System.Windows.Forms.DateTimePicker FormBirthday;
        private System.Windows.Forms.ComboBox FormDocType;
        private System.Windows.Forms.TextBox FormAdress;
        private System.Windows.Forms.TextBox FormPhone;
        private System.Windows.Forms.Label FormGenderLebel;
        private System.Windows.Forms.Label FormBirthdayLebel;
        private System.Windows.Forms.Label FormDocTypeLabel;
        private System.Windows.Forms.Label FormDocNumberLabel;
        private System.Windows.Forms.Label FormAdressLabel;
        private System.Windows.Forms.Label FormPhoneLabel;
    }
}