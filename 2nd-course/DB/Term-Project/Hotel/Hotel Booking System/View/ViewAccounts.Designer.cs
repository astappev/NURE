namespace Hotel_Booking_System.View
{
    partial class ViewAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OutFioLabel = new System.Windows.Forms.Label();
            this.OutNumLabel = new System.Windows.Forms.Label();
            this.NumLabel = new System.Windows.Forms.Label();
            this.FioLabel = new System.Windows.Forms.Label();
            this.AccountsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OutFioLabel
            // 
            this.OutFioLabel.AutoSize = true;
            this.OutFioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutFioLabel.Location = new System.Drawing.Point(115, 39);
            this.OutFioLabel.Name = "OutFioLabel";
            this.OutFioLabel.Size = new System.Drawing.Size(27, 15);
            this.OutFioLabel.TabIndex = 7;
            this.OutFioLabel.Text = "null";
            // 
            // OutNumLabel
            // 
            this.OutNumLabel.AutoSize = true;
            this.OutNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutNumLabel.Location = new System.Drawing.Point(115, 9);
            this.OutNumLabel.Name = "OutNumLabel";
            this.OutNumLabel.Size = new System.Drawing.Size(27, 15);
            this.OutNumLabel.TabIndex = 6;
            this.OutNumLabel.Text = "null";
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumLabel.Location = new System.Drawing.Point(12, 9);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(97, 15);
            this.NumLabel.TabIndex = 5;
            this.NumLabel.Text = "Номер в отеле:";
            // 
            // FioLabel
            // 
            this.FioLabel.AutoSize = true;
            this.FioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FioLabel.Location = new System.Drawing.Point(12, 39);
            this.FioLabel.Name = "FioLabel";
            this.FioLabel.Size = new System.Drawing.Size(92, 15);
            this.FioLabel.TabIndex = 4;
            this.FioLabel.Text = "ФИО Клиента:";
            // 
            // AccountsGridView
            // 
            this.AccountsGridView.AllowUserToAddRows = false;
            this.AccountsGridView.AllowUserToDeleteRows = false;
            this.AccountsGridView.AllowUserToOrderColumns = true;
            this.AccountsGridView.AllowUserToResizeRows = false;
            this.AccountsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AccountsGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.AccountsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccountsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AccountsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AccountsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountsGridView.GridColor = System.Drawing.Color.SaddleBrown;
            this.AccountsGridView.Location = new System.Drawing.Point(15, 69);
            this.AccountsGridView.Name = "AccountsGridView";
            this.AccountsGridView.ReadOnly = true;
            this.AccountsGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AccountsGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.AccountsGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.AccountsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AccountsGridView.Size = new System.Drawing.Size(343, 177);
            this.AccountsGridView.TabIndex = 8;
            // 
            // ViewAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(370, 258);
            this.Controls.Add(this.AccountsGridView);
            this.Controls.Add(this.OutFioLabel);
            this.Controls.Add(this.OutNumLabel);
            this.Controls.Add(this.NumLabel);
            this.Controls.Add(this.FioLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAccounts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дополнительные услуги";
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OutFioLabel;
        private System.Windows.Forms.Label OutNumLabel;
        private System.Windows.Forms.Label NumLabel;
        private System.Windows.Forms.Label FioLabel;
        private System.Windows.Forms.DataGridView AccountsGridView;
    }
}