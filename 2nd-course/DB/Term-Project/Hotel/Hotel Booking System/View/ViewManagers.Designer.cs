namespace Hotel_Booking_System.View
{
    partial class ViewManagers
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
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.DeleteButtons = new System.Windows.Forms.Button();
            this.ManagerGridView = new System.Windows.Forms.DataGridView();
            this.AddButtons = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            this.LoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginBox.Location = new System.Drawing.Point(12, 12);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(140, 21);
            this.LoginBox.TabIndex = 14;
            this.LoginBox.Text = "Логин";
            this.LoginBox.Enter += new System.EventHandler(this.LoginBox_Enter);
            this.LoginBox.Leave += new System.EventHandler(this.LoginBox_Leave);
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(158, 11);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(111, 24);
            this.FilterButton.TabIndex = 13;
            this.FilterButton.Text = "Фильтровать";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // DeleteButtons
            // 
            this.DeleteButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButtons.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DeleteButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButtons.Location = new System.Drawing.Point(440, 11);
            this.DeleteButtons.Name = "DeleteButtons";
            this.DeleteButtons.Size = new System.Drawing.Size(70, 24);
            this.DeleteButtons.TabIndex = 12;
            this.DeleteButtons.Text = "Удалить";
            this.DeleteButtons.UseVisualStyleBackColor = false;
            this.DeleteButtons.Click += new System.EventHandler(this.DeleteButtons_Click);
            // 
            // ManagerGridView
            // 
            this.ManagerGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManagerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManagerGridView.Location = new System.Drawing.Point(12, 42);
            this.ManagerGridView.Name = "ManagerGridView";
            this.ManagerGridView.Size = new System.Drawing.Size(498, 307);
            this.ManagerGridView.TabIndex = 11;
            // 
            // AddButtons
            // 
            this.AddButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButtons.Location = new System.Drawing.Point(364, 11);
            this.AddButtons.Name = "AddButtons";
            this.AddButtons.Size = new System.Drawing.Size(70, 24);
            this.AddButtons.TabIndex = 15;
            this.AddButtons.Text = "Добавить";
            this.AddButtons.UseVisualStyleBackColor = false;
            this.AddButtons.Click += new System.EventHandler(this.AddButtons_Click);
            // 
            // ViewManagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 361);
            this.Controls.Add(this.AddButtons);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.DeleteButtons);
            this.Controls.Add(this.ManagerGridView);
            this.Name = "ViewManagers";
            this.Text = "Просмотр менеджеров";
            ((System.ComponentModel.ISupportInitialize)(this.ManagerGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Button DeleteButtons;
        private System.Windows.Forms.DataGridView ManagerGridView;
        private System.Windows.Forms.Button AddButtons;
    }
}