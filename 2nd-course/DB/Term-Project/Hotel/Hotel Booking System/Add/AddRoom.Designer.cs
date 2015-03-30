namespace Hotel_Booking_System.Add
{
    partial class AddRoom
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
            this.FormTypeLabel = new System.Windows.Forms.Label();
            this.FormType = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.FormFloor = new System.Windows.Forms.TextBox();
            this.FormFloorLabel = new System.Windows.Forms.Label();
            this.FormPhoneLabel = new System.Windows.Forms.Label();
            this.FormPhone = new System.Windows.Forms.TextBox();
            this.FormCostLabel = new System.Windows.Forms.Label();
            this.FormCost = new System.Windows.Forms.TextBox();
            this.FormNum = new System.Windows.Forms.TextBox();
            this.FormNumLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FormName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FormTypeLabel
            // 
            this.FormTypeLabel.AutoSize = true;
            this.FormTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormTypeLabel.Location = new System.Drawing.Point(12, 13);
            this.FormTypeLabel.Name = "FormTypeLabel";
            this.FormTypeLabel.Size = new System.Drawing.Size(78, 15);
            this.FormTypeLabel.TabIndex = 0;
            this.FormTypeLabel.Text = "Тип номера:";
            // 
            // FormType
            // 
            this.FormType.BackColor = System.Drawing.SystemColors.Info;
            this.FormType.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormType.FormattingEnabled = true;
            this.FormType.Location = new System.Drawing.Point(145, 12);
            this.FormType.Name = "FormType";
            this.FormType.Size = new System.Drawing.Size(202, 21);
            this.FormType.TabIndex = 1;
            this.FormType.SelectedIndexChanged += new System.EventHandler(this.FormType_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.AddButton.Location = new System.Drawing.Point(145, 169);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(202, 35);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // FormFloor
            // 
            this.FormFloor.BackColor = System.Drawing.SystemColors.Info;
            this.FormFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormFloor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FormFloor.Location = new System.Drawing.Point(145, 65);
            this.FormFloor.Name = "FormFloor";
            this.FormFloor.Size = new System.Drawing.Size(202, 20);
            this.FormFloor.TabIndex = 3;
            this.FormFloor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormFloor_KeyPress);
            // 
            // FormFloorLabel
            // 
            this.FormFloorLabel.AutoSize = true;
            this.FormFloorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormFloorLabel.Location = new System.Drawing.Point(12, 66);
            this.FormFloorLabel.Name = "FormFloorLabel";
            this.FormFloorLabel.Size = new System.Drawing.Size(41, 15);
            this.FormFloorLabel.TabIndex = 4;
            this.FormFloorLabel.Text = "Этаж:";
            // 
            // FormPhoneLabel
            // 
            this.FormPhoneLabel.AutoSize = true;
            this.FormPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormPhoneLabel.Location = new System.Drawing.Point(12, 92);
            this.FormPhoneLabel.Name = "FormPhoneLabel";
            this.FormPhoneLabel.Size = new System.Drawing.Size(63, 15);
            this.FormPhoneLabel.TabIndex = 5;
            this.FormPhoneLabel.Text = "Телефон:";
            // 
            // FormPhone
            // 
            this.FormPhone.BackColor = System.Drawing.SystemColors.Info;
            this.FormPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormPhone.Location = new System.Drawing.Point(145, 91);
            this.FormPhone.MaxLength = 14;
            this.FormPhone.Name = "FormPhone";
            this.FormPhone.Size = new System.Drawing.Size(202, 20);
            this.FormPhone.TabIndex = 6;
            this.FormPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPhone_KeyPress);
            // 
            // FormCostLabel
            // 
            this.FormCostLabel.AutoSize = true;
            this.FormCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormCostLabel.Location = new System.Drawing.Point(12, 144);
            this.FormCostLabel.Name = "FormCostLabel";
            this.FormCostLabel.Size = new System.Drawing.Size(131, 15);
            this.FormCostLabel.TabIndex = 7;
            this.FormCostLabel.Text = "Стоимость за номер:";
            // 
            // FormCost
            // 
            this.FormCost.BackColor = System.Drawing.SystemColors.Info;
            this.FormCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormCost.Location = new System.Drawing.Point(145, 143);
            this.FormCost.Name = "FormCost";
            this.FormCost.Size = new System.Drawing.Size(202, 20);
            this.FormCost.TabIndex = 8;
            // 
            // FormNum
            // 
            this.FormNum.BackColor = System.Drawing.SystemColors.Info;
            this.FormNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormNum.Location = new System.Drawing.Point(145, 117);
            this.FormNum.Name = "FormNum";
            this.FormNum.Size = new System.Drawing.Size(202, 20);
            this.FormNum.TabIndex = 10;
            // 
            // FormNumLabel
            // 
            this.FormNumLabel.AutoSize = true;
            this.FormNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormNumLabel.Location = new System.Drawing.Point(12, 117);
            this.FormNumLabel.Name = "FormNumLabel";
            this.FormNumLabel.Size = new System.Drawing.Size(111, 15);
            this.FormNumLabel.TabIndex = 9;
            this.FormNumLabel.Text = "Количество мест:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Название:";
            // 
            // FormName
            // 
            this.FormName.BackColor = System.Drawing.SystemColors.Info;
            this.FormName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormName.Location = new System.Drawing.Point(145, 39);
            this.FormName.MaxLength = 50;
            this.FormName.Name = "FormName";
            this.FormName.Size = new System.Drawing.Size(202, 20);
            this.FormName.TabIndex = 11;
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(359, 216);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FormName);
            this.Controls.Add(this.FormNum);
            this.Controls.Add(this.FormNumLabel);
            this.Controls.Add(this.FormCost);
            this.Controls.Add(this.FormCostLabel);
            this.Controls.Add(this.FormPhone);
            this.Controls.Add(this.FormPhoneLabel);
            this.Controls.Add(this.FormFloorLabel);
            this.Controls.Add(this.FormFloor);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FormType);
            this.Controls.Add(this.FormTypeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить комнату";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FormTypeLabel;
        private System.Windows.Forms.ComboBox FormType;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox FormFloor;
        private System.Windows.Forms.Label FormFloorLabel;
        private System.Windows.Forms.Label FormPhoneLabel;
        private System.Windows.Forms.TextBox FormPhone;
        private System.Windows.Forms.Label FormCostLabel;
        private System.Windows.Forms.TextBox FormCost;
        private System.Windows.Forms.TextBox FormNum;
        private System.Windows.Forms.Label FormNumLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FormName;
    }
}