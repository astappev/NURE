namespace Hotel_Booking_System.Add
{
    partial class AddReservations
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddResidentButton = new System.Windows.Forms.Button();
            this.ClientPanel = new System.Windows.Forms.Panel();
            this.ClientsGridView = new System.Windows.Forms.DataGridView();
            this.ButtonClient = new System.Windows.Forms.Button();
            this.BoxClientLastName = new System.Windows.Forms.TextBox();
            this.BoxClientFirstName = new System.Windows.Forms.TextBox();
            this.LabelClients = new System.Windows.Forms.Label();
            this.ResetLink = new System.Windows.Forms.LinkLabel();
            this.StepArrowLabel2 = new System.Windows.Forms.Label();
            this.StepArrowLabel1 = new System.Windows.Forms.Label();
            this.StepThreeLabel = new System.Windows.Forms.Label();
            this.StepTwoLabel = new System.Windows.Forms.Label();
            this.StepOneLabel = new System.Windows.Forms.Label();
            this.RoomTypePanel = new System.Windows.Forms.Panel();
            this.LabelRooms = new System.Windows.Forms.Label();
            this.BoxRoomType = new System.Windows.Forms.ComboBox();
            this.DatePanel = new System.Windows.Forms.Panel();
            this.ErrorOut = new System.Windows.Forms.Label();
            this.OutTextDate = new System.Windows.Forms.Label();
            this.TodayDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckCalendar = new System.Windows.Forms.MonthCalendar();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.ClientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGridView)).BeginInit();
            this.RoomTypePanel.SuspendLayout();
            this.DatePanel.SuspendLayout();
            this.AddPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddResidentButton
            // 
            this.AddResidentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddResidentButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.AddResidentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddResidentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddResidentButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.AddResidentButton.Location = new System.Drawing.Point(180, 5);
            this.AddResidentButton.Name = "AddResidentButton";
            this.AddResidentButton.Size = new System.Drawing.Size(196, 35);
            this.AddResidentButton.TabIndex = 5;
            this.AddResidentButton.Text = "Добавить";
            this.AddResidentButton.UseVisualStyleBackColor = false;
            this.AddResidentButton.Click += new System.EventHandler(this.AddReservationsButton_Click);
            // 
            // ClientPanel
            // 
            this.ClientPanel.Controls.Add(this.ClientsGridView);
            this.ClientPanel.Controls.Add(this.ButtonClient);
            this.ClientPanel.Controls.Add(this.BoxClientLastName);
            this.ClientPanel.Controls.Add(this.BoxClientFirstName);
            this.ClientPanel.Controls.Add(this.LabelClients);
            this.ClientPanel.Location = new System.Drawing.Point(6, 6);
            this.ClientPanel.Name = "ClientPanel";
            this.ClientPanel.Size = new System.Drawing.Size(387, 351);
            this.ClientPanel.TabIndex = 27;
            // 
            // ClientsGridView
            // 
            this.ClientsGridView.AllowUserToAddRows = false;
            this.ClientsGridView.AllowUserToDeleteRows = false;
            this.ClientsGridView.AllowUserToOrderColumns = true;
            this.ClientsGridView.AllowUserToResizeRows = false;
            this.ClientsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClientsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientsGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.ClientsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ClientsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ClientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsGridView.GridColor = System.Drawing.Color.SaddleBrown;
            this.ClientsGridView.Location = new System.Drawing.Point(6, 51);
            this.ClientsGridView.Name = "ClientsGridView";
            this.ClientsGridView.ReadOnly = true;
            this.ClientsGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ClientsGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.ClientsGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ClientsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientsGridView.Size = new System.Drawing.Size(375, 295);
            this.ClientsGridView.TabIndex = 4;
            this.ClientsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientsGridView_CellDoubleClick);
            // 
            // ButtonClient
            // 
            this.ButtonClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonClient.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ButtonClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonClient.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ButtonClient.Location = new System.Drawing.Point(306, 23);
            this.ButtonClient.Name = "ButtonClient";
            this.ButtonClient.Size = new System.Drawing.Size(75, 22);
            this.ButtonClient.TabIndex = 0;
            this.ButtonClient.Text = "Найти";
            this.ButtonClient.UseVisualStyleBackColor = false;
            this.ButtonClient.Click += new System.EventHandler(this.ButtonClient_Click);
            // 
            // BoxClientLastName
            // 
            this.BoxClientLastName.BackColor = System.Drawing.SystemColors.Info;
            this.BoxClientLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxClientLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoxClientLastName.Location = new System.Drawing.Point(142, 23);
            this.BoxClientLastName.Name = "BoxClientLastName";
            this.BoxClientLastName.Size = new System.Drawing.Size(100, 22);
            this.BoxClientLastName.TabIndex = 2;
            this.BoxClientLastName.Text = "Имя";
            this.BoxClientLastName.Enter += new System.EventHandler(this.BoxClientLastName_Enter);
            this.BoxClientLastName.Leave += new System.EventHandler(this.BoxClientLastName_Leave);
            // 
            // BoxClientFirstName
            // 
            this.BoxClientFirstName.BackColor = System.Drawing.SystemColors.Info;
            this.BoxClientFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxClientFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoxClientFirstName.Location = new System.Drawing.Point(6, 23);
            this.BoxClientFirstName.Name = "BoxClientFirstName";
            this.BoxClientFirstName.Size = new System.Drawing.Size(130, 22);
            this.BoxClientFirstName.TabIndex = 1;
            this.BoxClientFirstName.Text = "Фамилия";
            this.BoxClientFirstName.Enter += new System.EventHandler(this.BoxClientFirstName_Enter);
            this.BoxClientFirstName.Leave += new System.EventHandler(this.BoxClientFirstName_Leave);
            // 
            // LabelClients
            // 
            this.LabelClients.AutoSize = true;
            this.LabelClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelClients.Location = new System.Drawing.Point(3, 5);
            this.LabelClients.Name = "LabelClients";
            this.LabelClients.Size = new System.Drawing.Size(99, 15);
            this.LabelClients.TabIndex = 6;
            this.LabelClients.Text = "Выбор клиента:";
            // 
            // ResetLink
            // 
            this.ResetLink.AutoSize = true;
            this.ResetLink.LinkColor = System.Drawing.Color.Maroon;
            this.ResetLink.Location = new System.Drawing.Point(681, 381);
            this.ResetLink.Name = "ResetLink";
            this.ResetLink.Size = new System.Drawing.Size(91, 13);
            this.ResetLink.TabIndex = 43;
            this.ResetLink.TabStop = true;
            this.ResetLink.Text = "Сбросить форму";
            this.ResetLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ResetLink_LinkClicked);
            // 
            // StepArrowLabel2
            // 
            this.StepArrowLabel2.AutoSize = true;
            this.StepArrowLabel2.Location = new System.Drawing.Point(336, 381);
            this.StepArrowLabel2.Name = "StepArrowLabel2";
            this.StepArrowLabel2.Size = new System.Drawing.Size(13, 13);
            this.StepArrowLabel2.TabIndex = 41;
            this.StepArrowLabel2.Text = ">";
            // 
            // StepArrowLabel1
            // 
            this.StepArrowLabel1.AutoSize = true;
            this.StepArrowLabel1.Location = new System.Drawing.Point(151, 381);
            this.StepArrowLabel1.Name = "StepArrowLabel1";
            this.StepArrowLabel1.Size = new System.Drawing.Size(13, 13);
            this.StepArrowLabel1.TabIndex = 40;
            this.StepArrowLabel1.Text = ">";
            // 
            // StepThreeLabel
            // 
            this.StepThreeLabel.AutoSize = true;
            this.StepThreeLabel.ForeColor = System.Drawing.Color.DimGray;
            this.StepThreeLabel.Location = new System.Drawing.Point(355, 381);
            this.StepThreeLabel.Name = "StepThreeLabel";
            this.StepThreeLabel.Size = new System.Drawing.Size(117, 13);
            this.StepThreeLabel.TabIndex = 38;
            this.StepThreeLabel.Text = "Шаг 3. Выберите дату";
            // 
            // StepTwoLabel
            // 
            this.StepTwoLabel.AutoSize = true;
            this.StepTwoLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepTwoLabel.Location = new System.Drawing.Point(170, 381);
            this.StepTwoLabel.Name = "StepTwoLabel";
            this.StepTwoLabel.Size = new System.Drawing.Size(160, 13);
            this.StepTwoLabel.TabIndex = 37;
            this.StepTwoLabel.Text = "Шаг 2. Выберите тип комнаты";
            // 
            // StepOneLabel
            // 
            this.StepOneLabel.AutoSize = true;
            this.StepOneLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepOneLabel.Location = new System.Drawing.Point(9, 381);
            this.StepOneLabel.Name = "StepOneLabel";
            this.StepOneLabel.Size = new System.Drawing.Size(136, 13);
            this.StepOneLabel.TabIndex = 36;
            this.StepOneLabel.Text = "Шаг 1. Выберите клиента";
            // 
            // RoomTypePanel
            // 
            this.RoomTypePanel.Controls.Add(this.LabelRooms);
            this.RoomTypePanel.Controls.Add(this.BoxRoomType);
            this.RoomTypePanel.Enabled = false;
            this.RoomTypePanel.Location = new System.Drawing.Point(399, 6);
            this.RoomTypePanel.Name = "RoomTypePanel";
            this.RoomTypePanel.Size = new System.Drawing.Size(380, 50);
            this.RoomTypePanel.TabIndex = 44;
            // 
            // LabelRooms
            // 
            this.LabelRooms.AutoSize = true;
            this.LabelRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelRooms.Location = new System.Drawing.Point(3, 5);
            this.LabelRooms.Name = "LabelRooms";
            this.LabelRooms.Size = new System.Drawing.Size(134, 15);
            this.LabelRooms.TabIndex = 25;
            this.LabelRooms.Text = "Выбор типа комнаты:";
            // 
            // BoxRoomType
            // 
            this.BoxRoomType.BackColor = System.Drawing.SystemColors.Info;
            this.BoxRoomType.DisplayMember = "ID";
            this.BoxRoomType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoxRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoxRoomType.FormattingEnabled = true;
            this.BoxRoomType.Location = new System.Drawing.Point(6, 23);
            this.BoxRoomType.Name = "BoxRoomType";
            this.BoxRoomType.Size = new System.Drawing.Size(367, 21);
            this.BoxRoomType.TabIndex = 25;
            this.BoxRoomType.ValueMember = "ID";
            this.BoxRoomType.SelectedIndexChanged += new System.EventHandler(this.BoxRoomType_SelectedIndexChanged);
            // 
            // DatePanel
            // 
            this.DatePanel.Controls.Add(this.ErrorOut);
            this.DatePanel.Controls.Add(this.OutTextDate);
            this.DatePanel.Controls.Add(this.TodayDateLabel);
            this.DatePanel.Controls.Add(this.label1);
            this.DatePanel.Controls.Add(this.CheckCalendar);
            this.DatePanel.Enabled = false;
            this.DatePanel.Location = new System.Drawing.Point(399, 62);
            this.DatePanel.Name = "DatePanel";
            this.DatePanel.Size = new System.Drawing.Size(380, 244);
            this.DatePanel.TabIndex = 45;
            // 
            // ErrorOut
            // 
            this.ErrorOut.ForeColor = System.Drawing.Color.Red;
            this.ErrorOut.Location = new System.Drawing.Point(20, 220);
            this.ErrorOut.Name = "ErrorOut";
            this.ErrorOut.Size = new System.Drawing.Size(335, 19);
            this.ErrorOut.TabIndex = 29;
            this.ErrorOut.Text = "Ошибка";
            this.ErrorOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorOut.Visible = false;
            // 
            // OutTextDate
            // 
            this.OutTextDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutTextDate.Location = new System.Drawing.Point(20, 193);
            this.OutTextDate.Name = "OutTextDate";
            this.OutTextDate.Size = new System.Drawing.Size(335, 25);
            this.OutTextDate.TabIndex = 28;
            this.OutTextDate.Text = "Выбраная дата";
            this.OutTextDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OutTextDate.Visible = false;
            // 
            // TodayDateLabel
            // 
            this.TodayDateLabel.AutoSize = true;
            this.TodayDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TodayDateLabel.Location = new System.Drawing.Point(254, 3);
            this.TodayDateLabel.Name = "TodayDateLabel";
            this.TodayDateLabel.Size = new System.Drawing.Size(55, 15);
            this.TodayDateLabel.TabIndex = 27;
            this.TodayDateLabel.Text = "Сегодня";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Выбор даты:";
            // 
            // CheckCalendar
            // 
            this.CheckCalendar.BackColor = System.Drawing.SystemColors.Info;
            this.CheckCalendar.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.CheckCalendar.Location = new System.Drawing.Point(23, 27);
            this.CheckCalendar.Name = "CheckCalendar";
            this.CheckCalendar.ShowToday = false;
            this.CheckCalendar.ShowTodayCircle = false;
            this.CheckCalendar.TabIndex = 0;
            this.CheckCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.CheckCalendar_DateChanged);
            this.CheckCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CheckCalendar_DateSelected);
            // 
            // AddPanel
            // 
            this.AddPanel.Controls.Add(this.AddResidentButton);
            this.AddPanel.Enabled = false;
            this.AddPanel.Location = new System.Drawing.Point(399, 312);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(380, 45);
            this.AddPanel.TabIndex = 46;
            // 
            // AddReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(784, 401);
            this.Controls.Add(this.AddPanel);
            this.Controls.Add(this.DatePanel);
            this.Controls.Add(this.RoomTypePanel);
            this.Controls.Add(this.ResetLink);
            this.Controls.Add(this.StepArrowLabel2);
            this.Controls.Add(this.StepArrowLabel1);
            this.Controls.Add(this.StepThreeLabel);
            this.Controls.Add(this.StepTwoLabel);
            this.Controls.Add(this.StepOneLabel);
            this.Controls.Add(this.ClientPanel);
            this.MinimumSize = new System.Drawing.Size(800, 440);
            this.Name = "AddReservations";
            this.ShowIcon = false;
            this.Text = "Забронировать период";
            this.ClientPanel.ResumeLayout(false);
            this.ClientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGridView)).EndInit();
            this.RoomTypePanel.ResumeLayout(false);
            this.RoomTypePanel.PerformLayout();
            this.DatePanel.ResumeLayout(false);
            this.DatePanel.PerformLayout();
            this.AddPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddResidentButton;
        private System.Windows.Forms.Panel ClientPanel;
        private System.Windows.Forms.DataGridView ClientsGridView;
        private System.Windows.Forms.Button ButtonClient;
        private System.Windows.Forms.TextBox BoxClientLastName;
        private System.Windows.Forms.TextBox BoxClientFirstName;
        private System.Windows.Forms.Label LabelClients;
        private System.Windows.Forms.LinkLabel ResetLink;
        private System.Windows.Forms.Label StepArrowLabel2;
        private System.Windows.Forms.Label StepArrowLabel1;
        private System.Windows.Forms.Label StepThreeLabel;
        private System.Windows.Forms.Label StepTwoLabel;
        private System.Windows.Forms.Label StepOneLabel;
        private System.Windows.Forms.Panel RoomTypePanel;
        private System.Windows.Forms.Label LabelRooms;
        private System.Windows.Forms.ComboBox BoxRoomType;
        private System.Windows.Forms.Panel DatePanel;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.MonthCalendar CheckCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TodayDateLabel;
        private System.Windows.Forms.Label OutTextDate;
        private System.Windows.Forms.Label ErrorOut;
    }
}