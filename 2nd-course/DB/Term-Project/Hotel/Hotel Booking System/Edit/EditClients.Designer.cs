namespace Hotel_Booking_System.Edit
{
    partial class EditClients
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
            this.FormPhoneLabel = new System.Windows.Forms.Label();
            this.FormAdressLabel = new System.Windows.Forms.Label();
            this.FormDocNumberLabel = new System.Windows.Forms.Label();
            this.FormDocTypeLabel = new System.Windows.Forms.Label();
            this.FormBirthdayLebel = new System.Windows.Forms.Label();
            this.FormGenderLebel = new System.Windows.Forms.Label();
            this.FormPhone = new System.Windows.Forms.TextBox();
            this.FormAdress = new System.Windows.Forms.TextBox();
            this.FormDocType = new System.Windows.Forms.ComboBox();
            this.FormBirthday = new System.Windows.Forms.DateTimePicker();
            this.FormGender = new System.Windows.Forms.ComboBox();
            this.FormDocNumber = new System.Windows.Forms.TextBox();
            this.FormPatronymicLabel = new System.Windows.Forms.Label();
            this.FormLastNameLabel = new System.Windows.Forms.Label();
            this.FormFirstNameLabel = new System.Windows.Forms.Label();
            this.FormPatronymic = new System.Windows.Forms.TextBox();
            this.FormLastName = new System.Windows.Forms.TextBox();
            this.FormFirstName = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormPhoneLabel
            // 
            this.FormPhoneLabel.AutoSize = true;
            this.FormPhoneLabel.Location = new System.Drawing.Point(14, 242);
            this.FormPhoneLabel.Name = "FormPhoneLabel";
            this.FormPhoneLabel.Size = new System.Drawing.Size(52, 13);
            this.FormPhoneLabel.TabIndex = 40;
            this.FormPhoneLabel.Text = "Телефон";
            // 
            // FormAdressLabel
            // 
            this.FormAdressLabel.AutoSize = true;
            this.FormAdressLabel.Location = new System.Drawing.Point(14, 199);
            this.FormAdressLabel.Name = "FormAdressLabel";
            this.FormAdressLabel.Size = new System.Drawing.Size(38, 13);
            this.FormAdressLabel.TabIndex = 39;
            this.FormAdressLabel.Text = "Адрес";
            // 
            // FormDocNumberLabel
            // 
            this.FormDocNumberLabel.AutoSize = true;
            this.FormDocNumberLabel.Location = new System.Drawing.Point(14, 173);
            this.FormDocNumberLabel.Name = "FormDocNumberLabel";
            this.FormDocNumberLabel.Size = new System.Drawing.Size(98, 13);
            this.FormDocNumberLabel.TabIndex = 38;
            this.FormDocNumberLabel.Text = "Номер документа";
            // 
            // FormDocTypeLabel
            // 
            this.FormDocTypeLabel.AutoSize = true;
            this.FormDocTypeLabel.Location = new System.Drawing.Point(14, 146);
            this.FormDocTypeLabel.Name = "FormDocTypeLabel";
            this.FormDocTypeLabel.Size = new System.Drawing.Size(83, 13);
            this.FormDocTypeLabel.TabIndex = 37;
            this.FormDocTypeLabel.Text = "Тип документа";
            // 
            // FormBirthdayLebel
            // 
            this.FormBirthdayLebel.AutoSize = true;
            this.FormBirthdayLebel.Location = new System.Drawing.Point(14, 119);
            this.FormBirthdayLebel.Name = "FormBirthdayLebel";
            this.FormBirthdayLebel.Size = new System.Drawing.Size(86, 13);
            this.FormBirthdayLebel.TabIndex = 36;
            this.FormBirthdayLebel.Text = "Дата рождения";
            // 
            // FormGenderLebel
            // 
            this.FormGenderLebel.AutoSize = true;
            this.FormGenderLebel.Location = new System.Drawing.Point(14, 93);
            this.FormGenderLebel.Name = "FormGenderLebel";
            this.FormGenderLebel.Size = new System.Drawing.Size(27, 13);
            this.FormGenderLebel.TabIndex = 35;
            this.FormGenderLebel.Text = "Пол";
            // 
            // FormPhone
            // 
            this.FormPhone.BackColor = System.Drawing.SystemColors.Info;
            this.FormPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormPhone.Location = new System.Drawing.Point(143, 239);
            this.FormPhone.MaxLength = 14;
            this.FormPhone.Name = "FormPhone";
            this.FormPhone.Size = new System.Drawing.Size(187, 20);
            this.FormPhone.TabIndex = 34;
            // 
            // FormAdress
            // 
            this.FormAdress.BackColor = System.Drawing.SystemColors.Info;
            this.FormAdress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormAdress.Location = new System.Drawing.Point(143, 196);
            this.FormAdress.MaxLength = 128;
            this.FormAdress.Multiline = true;
            this.FormAdress.Name = "FormAdress";
            this.FormAdress.Size = new System.Drawing.Size(187, 37);
            this.FormAdress.TabIndex = 33;
            // 
            // FormDocType
            // 
            this.FormDocType.BackColor = System.Drawing.SystemColors.Info;
            this.FormDocType.DisplayMember = "Name";
            this.FormDocType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormDocType.FormattingEnabled = true;
            this.FormDocType.Location = new System.Drawing.Point(143, 143);
            this.FormDocType.Name = "FormDocType";
            this.FormDocType.Size = new System.Drawing.Size(187, 21);
            this.FormDocType.TabIndex = 32;
            this.FormDocType.ValueMember = "ID";
            this.FormDocType.SelectedIndexChanged += new System.EventHandler(this.FormDocType_SelectedIndexChanged);
            // 
            // FormBirthday
            // 
            this.FormBirthday.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.FormBirthday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBirthday.Enabled = false;
            this.FormBirthday.Location = new System.Drawing.Point(143, 117);
            this.FormBirthday.MaxDate = new System.DateTime(2014, 5, 26, 0, 0, 0, 0);
            this.FormBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.FormBirthday.Name = "FormBirthday";
            this.FormBirthday.Size = new System.Drawing.Size(187, 20);
            this.FormBirthday.TabIndex = 31;
            this.FormBirthday.Value = new System.DateTime(2014, 5, 26, 0, 0, 0, 0);
            // 
            // FormGender
            // 
            this.FormGender.BackColor = System.Drawing.SystemColors.Info;
            this.FormGender.DisplayMember = "Name";
            this.FormGender.Enabled = false;
            this.FormGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormGender.FormattingEnabled = true;
            this.FormGender.Location = new System.Drawing.Point(143, 90);
            this.FormGender.Name = "FormGender";
            this.FormGender.Size = new System.Drawing.Size(187, 21);
            this.FormGender.TabIndex = 30;
            this.FormGender.ValueMember = "ID";
            // 
            // FormDocNumber
            // 
            this.FormDocNumber.BackColor = System.Drawing.SystemColors.Info;
            this.FormDocNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormDocNumber.Location = new System.Drawing.Point(143, 170);
            this.FormDocNumber.MaxLength = 30;
            this.FormDocNumber.Name = "FormDocNumber";
            this.FormDocNumber.Size = new System.Drawing.Size(187, 20);
            this.FormDocNumber.TabIndex = 29;
            // 
            // FormPatronymicLabel
            // 
            this.FormPatronymicLabel.AutoSize = true;
            this.FormPatronymicLabel.Location = new System.Drawing.Point(14, 67);
            this.FormPatronymicLabel.Name = "FormPatronymicLabel";
            this.FormPatronymicLabel.Size = new System.Drawing.Size(54, 13);
            this.FormPatronymicLabel.TabIndex = 28;
            this.FormPatronymicLabel.Text = "Отчество";
            // 
            // FormLastNameLabel
            // 
            this.FormLastNameLabel.AutoSize = true;
            this.FormLastNameLabel.Location = new System.Drawing.Point(14, 41);
            this.FormLastNameLabel.Name = "FormLastNameLabel";
            this.FormLastNameLabel.Size = new System.Drawing.Size(29, 13);
            this.FormLastNameLabel.TabIndex = 27;
            this.FormLastNameLabel.Text = "Имя";
            // 
            // FormFirstNameLabel
            // 
            this.FormFirstNameLabel.AutoSize = true;
            this.FormFirstNameLabel.Location = new System.Drawing.Point(14, 15);
            this.FormFirstNameLabel.Name = "FormFirstNameLabel";
            this.FormFirstNameLabel.Size = new System.Drawing.Size(56, 13);
            this.FormFirstNameLabel.TabIndex = 26;
            this.FormFirstNameLabel.Text = "Фамилия";
            // 
            // FormPatronymic
            // 
            this.FormPatronymic.BackColor = System.Drawing.SystemColors.Info;
            this.FormPatronymic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormPatronymic.Location = new System.Drawing.Point(143, 64);
            this.FormPatronymic.MaxLength = 90;
            this.FormPatronymic.Name = "FormPatronymic";
            this.FormPatronymic.Size = new System.Drawing.Size(187, 20);
            this.FormPatronymic.TabIndex = 25;
            // 
            // FormLastName
            // 
            this.FormLastName.BackColor = System.Drawing.SystemColors.Info;
            this.FormLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormLastName.Location = new System.Drawing.Point(143, 38);
            this.FormLastName.MaxLength = 90;
            this.FormLastName.Name = "FormLastName";
            this.FormLastName.Size = new System.Drawing.Size(187, 20);
            this.FormLastName.TabIndex = 24;
            // 
            // FormFirstName
            // 
            this.FormFirstName.BackColor = System.Drawing.SystemColors.Info;
            this.FormFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormFirstName.Location = new System.Drawing.Point(143, 12);
            this.FormFirstName.MaxLength = 90;
            this.FormFirstName.Name = "FormFirstName";
            this.FormFirstName.Size = new System.Drawing.Size(187, 20);
            this.FormFirstName.TabIndex = 23;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.UpdateButton.Location = new System.Drawing.Point(143, 276);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(187, 35);
            this.UpdateButton.TabIndex = 22;
            this.UpdateButton.Text = "Обновить";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // EditClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(343, 323);
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
            this.Controls.Add(this.UpdateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование клиента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FormPhoneLabel;
        private System.Windows.Forms.Label FormAdressLabel;
        private System.Windows.Forms.Label FormDocNumberLabel;
        private System.Windows.Forms.Label FormDocTypeLabel;
        private System.Windows.Forms.Label FormBirthdayLebel;
        private System.Windows.Forms.Label FormGenderLebel;
        private System.Windows.Forms.TextBox FormPhone;
        private System.Windows.Forms.TextBox FormAdress;
        private System.Windows.Forms.ComboBox FormDocType;
        private System.Windows.Forms.DateTimePicker FormBirthday;
        private System.Windows.Forms.ComboBox FormGender;
        private System.Windows.Forms.TextBox FormDocNumber;
        private System.Windows.Forms.Label FormPatronymicLabel;
        private System.Windows.Forms.Label FormLastNameLabel;
        private System.Windows.Forms.Label FormFirstNameLabel;
        private System.Windows.Forms.TextBox FormPatronymic;
        private System.Windows.Forms.TextBox FormLastName;
        private System.Windows.Forms.TextBox FormFirstName;
        private System.Windows.Forms.Button UpdateButton;
    }
}