namespace Hotel_Booking_System.View
{
    partial class ViewClients
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
            this.ClientGridView = new System.Windows.Forms.DataGridView();
            this.FilterButton = new System.Windows.Forms.Button();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.DeleteButtons = new System.Windows.Forms.Button();
            this.EditButtons = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientGridView
            // 
            this.ClientGridView.AllowUserToAddRows = false;
            this.ClientGridView.AllowUserToDeleteRows = false;
            this.ClientGridView.AllowUserToOrderColumns = true;
            this.ClientGridView.AllowUserToResizeRows = false;
            this.ClientGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.ClientGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ClientGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ClientGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientGridView.GridColor = System.Drawing.Color.SaddleBrown;
            this.ClientGridView.Location = new System.Drawing.Point(12, 42);
            this.ClientGridView.Name = "ClientGridView";
            this.ClientGridView.ReadOnly = true;
            this.ClientGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ClientGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.ClientGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ClientGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientGridView.Size = new System.Drawing.Size(634, 307);
            this.ClientGridView.TabIndex = 0;
            this.ClientGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientGridView_CellDoubleClick);
            // 
            // FilterButton
            // 
            this.FilterButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.FilterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilterButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.FilterButton.Location = new System.Drawing.Point(291, 11);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(93, 22);
            this.FilterButton.TabIndex = 9;
            this.FilterButton.Text = "Фильтровать";
            this.FilterButton.UseVisualStyleBackColor = false;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.BackColor = System.Drawing.SystemColors.Info;
            this.FirstNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FirstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNameBox.Location = new System.Drawing.Point(12, 11);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(143, 22);
            this.FirstNameBox.TabIndex = 10;
            this.FirstNameBox.Text = "Фамилия";
            this.FirstNameBox.Enter += new System.EventHandler(this.FirstNameBox_Enter);
            this.FirstNameBox.Leave += new System.EventHandler(this.FirstNameBox_Leave);
            // 
            // LastNameBox
            // 
            this.LastNameBox.BackColor = System.Drawing.SystemColors.Info;
            this.LastNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastNameBox.Location = new System.Drawing.Point(161, 11);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(124, 22);
            this.LastNameBox.TabIndex = 11;
            this.LastNameBox.Text = "Имя";
            this.LastNameBox.Enter += new System.EventHandler(this.LastNameBox_Enter);
            this.LastNameBox.Leave += new System.EventHandler(this.LastNameBox_Leave);
            // 
            // DeleteButtons
            // 
            this.DeleteButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButtons.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.DeleteButtons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButtons.ForeColor = System.Drawing.Color.SaddleBrown;
            this.DeleteButtons.Location = new System.Drawing.Point(549, 10);
            this.DeleteButtons.Name = "DeleteButtons";
            this.DeleteButtons.Size = new System.Drawing.Size(97, 22);
            this.DeleteButtons.TabIndex = 12;
            this.DeleteButtons.Text = "Удалить строку";
            this.DeleteButtons.UseVisualStyleBackColor = false;
            this.DeleteButtons.Click += new System.EventHandler(this.DeleteButtons_Click);
            // 
            // EditButtons
            // 
            this.EditButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButtons.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditButtons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditButtons.ForeColor = System.Drawing.Color.SaddleBrown;
            this.EditButtons.Location = new System.Drawing.Point(447, 10);
            this.EditButtons.Name = "EditButtons";
            this.EditButtons.Size = new System.Drawing.Size(96, 22);
            this.EditButtons.TabIndex = 7;
            this.EditButtons.Text = "Редактировать";
            this.EditButtons.UseVisualStyleBackColor = false;
            this.EditButtons.Click += new System.EventHandler(this.EditButtons_Click);
            // 
            // ViewClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(659, 361);
            this.Controls.Add(this.DeleteButtons);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.EditButtons);
            this.Controls.Add(this.ClientGridView);
            this.MinimumSize = new System.Drawing.Size(660, 200);
            this.Name = "ViewClients";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр клиентов";
            this.Activated += new System.EventHandler(this.ViewClients_Activated);
            this.Load += new System.EventHandler(this.ViewClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ClientGridView;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Button DeleteButtons;
        private System.Windows.Forms.Button EditButtons;
    }
}