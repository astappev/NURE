namespace Hotel_Booking_System.Add
{
    partial class AddAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccounts));
            this.FioLabel = new System.Windows.Forms.Label();
            this.NumLabel = new System.Windows.Forms.Label();
            this.OutNumLabel = new System.Windows.Forms.Label();
            this.OutFioLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.CostBox = new System.Windows.Forms.TextBox();
            this.CostLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.GrnLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.TemplateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FioLabel
            // 
            this.FioLabel.AutoSize = true;
            this.FioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FioLabel.Location = new System.Drawing.Point(12, 40);
            this.FioLabel.Name = "FioLabel";
            this.FioLabel.Size = new System.Drawing.Size(92, 15);
            this.FioLabel.TabIndex = 0;
            this.FioLabel.Text = "ФИО Клиента:";
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumLabel.Location = new System.Drawing.Point(12, 10);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(97, 15);
            this.NumLabel.TabIndex = 1;
            this.NumLabel.Text = "Номер в отеле:";
            // 
            // OutNumLabel
            // 
            this.OutNumLabel.AutoSize = true;
            this.OutNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutNumLabel.Location = new System.Drawing.Point(115, 10);
            this.OutNumLabel.Name = "OutNumLabel";
            this.OutNumLabel.Size = new System.Drawing.Size(27, 15);
            this.OutNumLabel.TabIndex = 2;
            this.OutNumLabel.Text = "null";
            // 
            // OutFioLabel
            // 
            this.OutFioLabel.AutoSize = true;
            this.OutFioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutFioLabel.Location = new System.Drawing.Point(115, 40);
            this.OutFioLabel.Name = "OutFioLabel";
            this.OutFioLabel.Size = new System.Drawing.Size(27, 15);
            this.OutFioLabel.TabIndex = 3;
            this.OutFioLabel.Text = "null";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeLabel.Location = new System.Drawing.Point(12, 70);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(48, 15);
            this.TypeLabel.TabIndex = 5;
            this.TypeLabel.Text = "Услуга:";
            // 
            // CostBox
            // 
            this.CostBox.BackColor = System.Drawing.SystemColors.Info;
            this.CostBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CostBox.Location = new System.Drawing.Point(118, 98);
            this.CostBox.Name = "CostBox";
            this.CostBox.Size = new System.Drawing.Size(174, 20);
            this.CostBox.TabIndex = 6;
            this.CostBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CostBox_KeyPress);
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Location = new System.Drawing.Point(12, 100);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(65, 13);
            this.CostLabel.TabIndex = 7;
            this.CostLabel.Text = "Стоимость:";
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.AddButton.Location = new System.Drawing.Point(118, 126);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(215, 30);
            this.AddButton.TabIndex = 8;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // GrnLabel
            // 
            this.GrnLabel.AutoSize = true;
            this.GrnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GrnLabel.Location = new System.Drawing.Point(298, 98);
            this.GrnLabel.Name = "GrnLabel";
            this.GrnLabel.Size = new System.Drawing.Size(29, 15);
            this.GrnLabel.TabIndex = 9;
            this.GrnLabel.Text = "грн.";
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.Info;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameBox.Location = new System.Drawing.Point(118, 70);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(192, 20);
            this.NameBox.TabIndex = 10;
            // 
            // TemplateButton
            // 
            this.TemplateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TemplateButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.TemplateButton.Image = ((System.Drawing.Image)(resources.GetObject("TemplateButton.Image")));
            this.TemplateButton.Location = new System.Drawing.Point(316, 70);
            this.TemplateButton.Name = "TemplateButton";
            this.TemplateButton.Size = new System.Drawing.Size(17, 20);
            this.TemplateButton.TabIndex = 11;
            this.TemplateButton.UseVisualStyleBackColor = false;
            this.TemplateButton.Click += new System.EventHandler(this.TemplateButton_Click);
            // 
            // AddAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(346, 168);
            this.Controls.Add(this.TemplateButton);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.GrnLabel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CostLabel);
            this.Controls.Add(this.CostBox);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.OutFioLabel);
            this.Controls.Add(this.OutNumLabel);
            this.Controls.Add(this.NumLabel);
            this.Controls.Add(this.FioLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить услугу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FioLabel;
        private System.Windows.Forms.Label NumLabel;
        private System.Windows.Forms.Label OutNumLabel;
        private System.Windows.Forms.Label OutFioLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.TextBox CostBox;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label GrnLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button TemplateButton;
    }
}