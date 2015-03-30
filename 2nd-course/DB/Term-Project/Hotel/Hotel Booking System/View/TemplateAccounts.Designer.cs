namespace Hotel_Booking_System.View
{
    partial class TemplateAccounts
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
            this.RoomGridView = new System.Windows.Forms.DataGridView();
            this.SaveButtons = new System.Windows.Forms.Button();
            this.EditButtons = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RoomGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // RoomGridView
            // 
            this.RoomGridView.AllowUserToOrderColumns = true;
            this.RoomGridView.AllowUserToResizeRows = false;
            this.RoomGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RoomGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.RoomGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RoomGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RoomGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RoomGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomGridView.GridColor = System.Drawing.Color.SaddleBrown;
            this.RoomGridView.Location = new System.Drawing.Point(13, 42);
            this.RoomGridView.Name = "RoomGridView";
            this.RoomGridView.ReadOnly = true;
            this.RoomGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RoomGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.RoomGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.RoomGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoomGridView.Size = new System.Drawing.Size(634, 307);
            this.RoomGridView.TabIndex = 1;
            this.RoomGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomGridView_CellDoubleClick);
            // 
            // SaveButtons
            // 
            this.SaveButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButtons.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.SaveButtons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButtons.Enabled = false;
            this.SaveButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButtons.ForeColor = System.Drawing.Color.SaddleBrown;
            this.SaveButtons.Location = new System.Drawing.Point(501, 12);
            this.SaveButtons.Name = "SaveButtons";
            this.SaveButtons.Size = new System.Drawing.Size(146, 23);
            this.SaveButtons.TabIndex = 4;
            this.SaveButtons.Text = "Сохранить изменения";
            this.SaveButtons.UseVisualStyleBackColor = false;
            this.SaveButtons.Click += new System.EventHandler(this.SaveButtons_Click);
            // 
            // EditButtons
            // 
            this.EditButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButtons.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditButtons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditButtons.ForeColor = System.Drawing.Color.SaddleBrown;
            this.EditButtons.Location = new System.Drawing.Point(349, 12);
            this.EditButtons.Name = "EditButtons";
            this.EditButtons.Size = new System.Drawing.Size(146, 23);
            this.EditButtons.TabIndex = 5;
            this.EditButtons.Text = "Редактировать";
            this.EditButtons.UseVisualStyleBackColor = false;
            this.EditButtons.Click += new System.EventHandler(this.EditButtons_Click);
            // 
            // TemplateAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(659, 361);
            this.Controls.Add(this.EditButtons);
            this.Controls.Add(this.SaveButtons);
            this.Controls.Add(this.RoomGridView);
            this.MinimumSize = new System.Drawing.Size(660, 200);
            this.Name = "TemplateAccounts";
            this.ShowIcon = false;
            this.Text = "Шаблоны услуг";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewRooms_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.RoomGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RoomGridView;
        private System.Windows.Forms.Button SaveButtons;
        private System.Windows.Forms.Button EditButtons;
    }
}