namespace Hotel_Booking_System.View
{
    partial class ViewReservations
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
            this.ReservationsGridView = new System.Windows.Forms.DataGridView();
            this.FilterButton = new System.Windows.Forms.Button();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.DeleteButtons = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ReservationsGridView
            // 
            this.ReservationsGridView.AllowUserToAddRows = false;
            this.ReservationsGridView.AllowUserToDeleteRows = false;
            this.ReservationsGridView.AllowUserToOrderColumns = true;
            this.ReservationsGridView.AllowUserToResizeRows = false;
            this.ReservationsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReservationsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReservationsGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.ReservationsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReservationsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ReservationsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ReservationsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReservationsGridView.GridColor = System.Drawing.Color.SaddleBrown;
            this.ReservationsGridView.Location = new System.Drawing.Point(12, 42);
            this.ReservationsGridView.Name = "ReservationsGridView";
            this.ReservationsGridView.ReadOnly = true;
            this.ReservationsGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReservationsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ReservationsGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.ReservationsGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ReservationsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReservationsGridView.Size = new System.Drawing.Size(634, 307);
            this.ReservationsGridView.TabIndex = 0;
            this.ReservationsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientGridView_CellDoubleClick);
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
            this.DeleteButtons.Text = "Удалить бронь";
            this.DeleteButtons.UseVisualStyleBackColor = false;
            this.DeleteButtons.Click += new System.EventHandler(this.DeleteButtons_Click);
            // 
            // ViewReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(659, 361);
            this.Controls.Add(this.DeleteButtons);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.ReservationsGridView);
            this.MinimumSize = new System.Drawing.Size(660, 200);
            this.Name = "ViewReservations";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр брони";
            this.Activated += new System.EventHandler(this.ViewReservations_Activated);
            this.Load += new System.EventHandler(this.ViewReservations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReservationsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReservationsGridView;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Button DeleteButtons;
    }
}