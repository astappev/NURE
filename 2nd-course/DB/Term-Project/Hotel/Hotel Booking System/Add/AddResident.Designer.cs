namespace Hotel_Booking_System.Add
{
    partial class AddResident
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ButtonClient = new System.Windows.Forms.Button();
            this.BoxClientFirstName = new System.Windows.Forms.TextBox();
            this.BoxClientLastName = new System.Windows.Forms.TextBox();
            this.ClientsGridView = new System.Windows.Forms.DataGridView();
            this.AddResidentButton = new System.Windows.Forms.Button();
            this.LabelClients = new System.Windows.Forms.Label();
            this.LabelCost = new System.Windows.Forms.Label();
            this.BoxCost = new System.Windows.Forms.TextBox();
            this.BoxAmount = new System.Windows.Forms.TextBox();
            this.LabelAmount = new System.Windows.Forms.Label();
            this.LabelRent = new System.Windows.Forms.Label();
            this.BoxRent = new System.Windows.Forms.TextBox();
            this.RoomPanel = new System.Windows.Forms.Panel();
            this.AvailableValue = new System.Windows.Forms.Label();
            this.AvailableLabel = new System.Windows.Forms.Label();
            this.FreeValue = new System.Windows.Forms.Label();
            this.FreeLabel = new System.Windows.Forms.Label();
            this.ReservationValue = new System.Windows.Forms.Label();
            this.ReservationLabel = new System.Windows.Forms.Label();
            this.RoomsGridView = new System.Windows.Forms.DataGridView();
            this.ButtonRoom = new System.Windows.Forms.Button();
            this.LabelRooms = new System.Windows.Forms.Label();
            this.BoxRoomType = new System.Windows.Forms.ComboBox();
            this.BoxRoomName = new System.Windows.Forms.TextBox();
            this.DatePanel = new System.Windows.Forms.Panel();
            this.TextDateLabel = new System.Windows.Forms.Label();
            this.DaysBox = new System.Windows.Forms.TextBox();
            this.NumDays = new System.Windows.Forms.Label();
            this.ClientPanel = new System.Windows.Forms.Panel();
            this.CalcPanel = new System.Windows.Forms.Panel();
            this.StepOneLabel = new System.Windows.Forms.Label();
            this.StepTwoLabel = new System.Windows.Forms.Label();
            this.StepThreeLabel = new System.Windows.Forms.Label();
            this.StepFourLabel = new System.Windows.Forms.Label();
            this.StepArrowLabel1 = new System.Windows.Forms.Label();
            this.StepArrowLabel2 = new System.Windows.Forms.Label();
            this.StepArrowLabel3 = new System.Windows.Forms.Label();
            this.ResetLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGridView)).BeginInit();
            this.RoomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsGridView)).BeginInit();
            this.DatePanel.SuspendLayout();
            this.ClientPanel.SuspendLayout();
            this.CalcPanel.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ClientsGridView.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.ClientsGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ClientsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientsGridView.Size = new System.Drawing.Size(375, 295);
            this.ClientsGridView.TabIndex = 4;
            this.ClientsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientsGridView_CellDoubleClick);
            // 
            // AddResidentButton
            // 
            this.AddResidentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddResidentButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.AddResidentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddResidentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddResidentButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.AddResidentButton.Location = new System.Drawing.Point(257, 3);
            this.AddResidentButton.Name = "AddResidentButton";
            this.AddResidentButton.Size = new System.Drawing.Size(120, 75);
            this.AddResidentButton.TabIndex = 5;
            this.AddResidentButton.Text = "Добавить";
            this.AddResidentButton.UseVisualStyleBackColor = false;
            this.AddResidentButton.Click += new System.EventHandler(this.AddResidentButton_Click);
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
            // LabelCost
            // 
            this.LabelCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelCost.AutoSize = true;
            this.LabelCost.Location = new System.Drawing.Point(3, 3);
            this.LabelCost.Name = "LabelCost";
            this.LabelCost.Size = new System.Drawing.Size(83, 13);
            this.LabelCost.TabIndex = 14;
            this.LabelCost.Text = "Сума к оплате:";
            // 
            // BoxCost
            // 
            this.BoxCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoxCost.BackColor = System.Drawing.SystemColors.Info;
            this.BoxCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxCost.Enabled = false;
            this.BoxCost.Location = new System.Drawing.Point(6, 19);
            this.BoxCost.Name = "BoxCost";
            this.BoxCost.Size = new System.Drawing.Size(120, 20);
            this.BoxCost.TabIndex = 15;
            // 
            // BoxAmount
            // 
            this.BoxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoxAmount.BackColor = System.Drawing.SystemColors.Info;
            this.BoxAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxAmount.Location = new System.Drawing.Point(6, 58);
            this.BoxAmount.Name = "BoxAmount";
            this.BoxAmount.Size = new System.Drawing.Size(120, 20);
            this.BoxAmount.TabIndex = 17;
            this.BoxAmount.TextChanged += new System.EventHandler(this.BoxAmount_TextChanged);
            this.BoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxAmount_KeyPress);
            // 
            // LabelAmount
            // 
            this.LabelAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelAmount.AutoSize = true;
            this.LabelAmount.Location = new System.Drawing.Point(3, 42);
            this.LabelAmount.Name = "LabelAmount";
            this.LabelAmount.Size = new System.Drawing.Size(93, 13);
            this.LabelAmount.TabIndex = 16;
            this.LabelAmount.Text = "Внесенная сума:";
            // 
            // LabelRent
            // 
            this.LabelRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelRent.AutoSize = true;
            this.LabelRent.Location = new System.Drawing.Point(129, 3);
            this.LabelRent.Name = "LabelRent";
            this.LabelRent.Size = new System.Drawing.Size(65, 13);
            this.LabelRent.TabIndex = 21;
            this.LabelRent.Text = "Переплата:";
            this.LabelRent.Visible = false;
            // 
            // BoxRent
            // 
            this.BoxRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoxRent.BackColor = System.Drawing.SystemColors.Info;
            this.BoxRent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxRent.Enabled = false;
            this.BoxRent.Location = new System.Drawing.Point(132, 19);
            this.BoxRent.Name = "BoxRent";
            this.BoxRent.Size = new System.Drawing.Size(120, 20);
            this.BoxRent.TabIndex = 23;
            this.BoxRent.Visible = false;
            // 
            // RoomPanel
            // 
            this.RoomPanel.Controls.Add(this.AvailableValue);
            this.RoomPanel.Controls.Add(this.AvailableLabel);
            this.RoomPanel.Controls.Add(this.FreeValue);
            this.RoomPanel.Controls.Add(this.FreeLabel);
            this.RoomPanel.Controls.Add(this.ReservationValue);
            this.RoomPanel.Controls.Add(this.ReservationLabel);
            this.RoomPanel.Controls.Add(this.RoomsGridView);
            this.RoomPanel.Controls.Add(this.ButtonRoom);
            this.RoomPanel.Controls.Add(this.LabelRooms);
            this.RoomPanel.Controls.Add(this.BoxRoomType);
            this.RoomPanel.Controls.Add(this.BoxRoomName);
            this.RoomPanel.Enabled = false;
            this.RoomPanel.Location = new System.Drawing.Point(399, 63);
            this.RoomPanel.Name = "RoomPanel";
            this.RoomPanel.Size = new System.Drawing.Size(380, 205);
            this.RoomPanel.TabIndex = 24;
            // 
            // AvailableValue
            // 
            this.AvailableValue.AutoSize = true;
            this.AvailableValue.Location = new System.Drawing.Point(357, 47);
            this.AvailableValue.Name = "AvailableValue";
            this.AvailableValue.Size = new System.Drawing.Size(13, 13);
            this.AvailableValue.TabIndex = 31;
            this.AvailableValue.Text = "0";
            // 
            // AvailableLabel
            // 
            this.AvailableLabel.AutoSize = true;
            this.AvailableLabel.Location = new System.Drawing.Point(292, 48);
            this.AvailableLabel.Name = "AvailableLabel";
            this.AvailableLabel.Size = new System.Drawing.Size(59, 13);
            this.AvailableLabel.TabIndex = 30;
            this.AvailableLabel.Text = "Доступно:";
            // 
            // FreeValue
            // 
            this.FreeValue.AutoSize = true;
            this.FreeValue.Location = new System.Drawing.Point(68, 47);
            this.FreeValue.Name = "FreeValue";
            this.FreeValue.Size = new System.Drawing.Size(13, 13);
            this.FreeValue.TabIndex = 29;
            this.FreeValue.Text = "0";
            // 
            // FreeLabel
            // 
            this.FreeLabel.AutoSize = true;
            this.FreeLabel.Location = new System.Drawing.Point(2, 47);
            this.FreeLabel.Name = "FreeLabel";
            this.FreeLabel.Size = new System.Drawing.Size(59, 13);
            this.FreeLabel.TabIndex = 28;
            this.FreeLabel.Text = "Свободно:";
            // 
            // ReservationValue
            // 
            this.ReservationValue.AutoSize = true;
            this.ReservationValue.Location = new System.Drawing.Point(192, 47);
            this.ReservationValue.Name = "ReservationValue";
            this.ReservationValue.Size = new System.Drawing.Size(13, 13);
            this.ReservationValue.TabIndex = 27;
            this.ReservationValue.Text = "0";
            // 
            // ReservationLabel
            // 
            this.ReservationLabel.AutoSize = true;
            this.ReservationLabel.Location = new System.Drawing.Point(97, 47);
            this.ReservationLabel.Name = "ReservationLabel";
            this.ReservationLabel.Size = new System.Drawing.Size(89, 13);
            this.ReservationLabel.TabIndex = 26;
            this.ReservationLabel.Text = "Забронировано:";
            // 
            // RoomsGridView
            // 
            this.RoomsGridView.AllowUserToAddRows = false;
            this.RoomsGridView.AllowUserToDeleteRows = false;
            this.RoomsGridView.AllowUserToOrderColumns = true;
            this.RoomsGridView.AllowUserToResizeRows = false;
            this.RoomsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RoomsGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.RoomsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RoomsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RoomsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RoomsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomsGridView.GridColor = System.Drawing.Color.SaddleBrown;
            this.RoomsGridView.Location = new System.Drawing.Point(5, 63);
            this.RoomsGridView.Name = "RoomsGridView";
            this.RoomsGridView.ReadOnly = true;
            this.RoomsGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RoomsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.RoomsGridView.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.RoomsGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.RoomsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoomsGridView.Size = new System.Drawing.Size(372, 138);
            this.RoomsGridView.TabIndex = 25;
            this.RoomsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomsGridView_CellDoubleClick);
            this.RoomsGridView.SelectionChanged += new System.EventHandler(this.RoomsGridView_SelectionChanged);
            // 
            // ButtonRoom
            // 
            this.ButtonRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRoom.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ButtonRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRoom.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ButtonRoom.Location = new System.Drawing.Point(302, 23);
            this.ButtonRoom.Name = "ButtonRoom";
            this.ButtonRoom.Size = new System.Drawing.Size(75, 22);
            this.ButtonRoom.TabIndex = 25;
            this.ButtonRoom.Text = "Найти";
            this.ButtonRoom.UseVisualStyleBackColor = false;
            this.ButtonRoom.Click += new System.EventHandler(this.ButtonRoom_Click);
            // 
            // LabelRooms
            // 
            this.LabelRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelRooms.AutoSize = true;
            this.LabelRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelRooms.Location = new System.Drawing.Point(2, 5);
            this.LabelRooms.Name = "LabelRooms";
            this.LabelRooms.Size = new System.Drawing.Size(103, 15);
            this.LabelRooms.TabIndex = 25;
            this.LabelRooms.Text = "Выбор комнаты:";
            // 
            // BoxRoomType
            // 
            this.BoxRoomType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoxRoomType.BackColor = System.Drawing.SystemColors.Info;
            this.BoxRoomType.DisplayMember = "ID";
            this.BoxRoomType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoxRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoxRoomType.FormattingEnabled = true;
            this.BoxRoomType.Location = new System.Drawing.Point(3, 23);
            this.BoxRoomType.Name = "BoxRoomType";
            this.BoxRoomType.Size = new System.Drawing.Size(124, 21);
            this.BoxRoomType.TabIndex = 25;
            this.BoxRoomType.ValueMember = "ID";
            // 
            // BoxRoomName
            // 
            this.BoxRoomName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoxRoomName.BackColor = System.Drawing.SystemColors.Info;
            this.BoxRoomName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoxRoomName.Location = new System.Drawing.Point(133, 23);
            this.BoxRoomName.Name = "BoxRoomName";
            this.BoxRoomName.Size = new System.Drawing.Size(133, 22);
            this.BoxRoomName.TabIndex = 11;
            this.BoxRoomName.Text = "Название";
            this.BoxRoomName.Enter += new System.EventHandler(this.BoxRoomName_Enter);
            this.BoxRoomName.Leave += new System.EventHandler(this.BoxRoomName_Leave);
            // 
            // DatePanel
            // 
            this.DatePanel.Controls.Add(this.TextDateLabel);
            this.DatePanel.Controls.Add(this.DaysBox);
            this.DatePanel.Controls.Add(this.NumDays);
            this.DatePanel.Enabled = false;
            this.DatePanel.Location = new System.Drawing.Point(399, 6);
            this.DatePanel.Name = "DatePanel";
            this.DatePanel.Size = new System.Drawing.Size(380, 51);
            this.DatePanel.TabIndex = 25;
            // 
            // TextDateLabel
            // 
            this.TextDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextDateLabel.Location = new System.Drawing.Point(180, 23);
            this.TextDateLabel.Name = "TextDateLabel";
            this.TextDateLabel.Size = new System.Drawing.Size(197, 22);
            this.TextDateLabel.TabIndex = 28;
            this.TextDateLabel.Text = "Диапазон дат";
            this.TextDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DaysBox
            // 
            this.DaysBox.BackColor = System.Drawing.SystemColors.Info;
            this.DaysBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DaysBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DaysBox.Location = new System.Drawing.Point(119, 23);
            this.DaysBox.MaxLength = 2;
            this.DaysBox.Name = "DaysBox";
            this.DaysBox.Size = new System.Drawing.Size(48, 22);
            this.DaysBox.TabIndex = 26;
            this.DaysBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DaysBox.TextChanged += new System.EventHandler(this.DaysBox_TextChanged);
            this.DaysBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DaysBox_KeyPress);
            // 
            // NumDays
            // 
            this.NumDays.AutoSize = true;
            this.NumDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumDays.Location = new System.Drawing.Point(3, 25);
            this.NumDays.Name = "NumDays";
            this.NumDays.Size = new System.Drawing.Size(110, 15);
            this.NumDays.TabIndex = 27;
            this.NumDays.Text = "Количество дней:";
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
            this.ClientPanel.TabIndex = 26;
            // 
            // CalcPanel
            // 
            this.CalcPanel.Controls.Add(this.BoxCost);
            this.CalcPanel.Controls.Add(this.AddResidentButton);
            this.CalcPanel.Controls.Add(this.LabelCost);
            this.CalcPanel.Controls.Add(this.BoxRent);
            this.CalcPanel.Controls.Add(this.LabelAmount);
            this.CalcPanel.Controls.Add(this.BoxAmount);
            this.CalcPanel.Controls.Add(this.LabelRent);
            this.CalcPanel.Enabled = false;
            this.CalcPanel.Location = new System.Drawing.Point(399, 274);
            this.CalcPanel.Name = "CalcPanel";
            this.CalcPanel.Size = new System.Drawing.Size(380, 83);
            this.CalcPanel.TabIndex = 27;
            // 
            // StepOneLabel
            // 
            this.StepOneLabel.AutoSize = true;
            this.StepOneLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepOneLabel.Location = new System.Drawing.Point(9, 381);
            this.StepOneLabel.Name = "StepOneLabel";
            this.StepOneLabel.Size = new System.Drawing.Size(136, 13);
            this.StepOneLabel.TabIndex = 28;
            this.StepOneLabel.Text = "Шаг 1. Выберите клиента";
            // 
            // StepTwoLabel
            // 
            this.StepTwoLabel.AutoSize = true;
            this.StepTwoLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepTwoLabel.Location = new System.Drawing.Point(170, 381);
            this.StepTwoLabel.Name = "StepTwoLabel";
            this.StepTwoLabel.Size = new System.Drawing.Size(172, 13);
            this.StepTwoLabel.TabIndex = 29;
            this.StepTwoLabel.Text = "Шаг 2. Введите количество дней";
            // 
            // StepThreeLabel
            // 
            this.StepThreeLabel.AutoSize = true;
            this.StepThreeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepThreeLabel.Location = new System.Drawing.Point(367, 381);
            this.StepThreeLabel.Name = "StepThreeLabel";
            this.StepThreeLabel.Size = new System.Drawing.Size(127, 13);
            this.StepThreeLabel.TabIndex = 30;
            this.StepThreeLabel.Text = "Шаг 3. Выберите номер";
            // 
            // StepFourLabel
            // 
            this.StepFourLabel.AutoSize = true;
            this.StepFourLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepFourLabel.Location = new System.Drawing.Point(519, 381);
            this.StepFourLabel.Name = "StepFourLabel";
            this.StepFourLabel.Size = new System.Drawing.Size(119, 13);
            this.StepFourLabel.TabIndex = 31;
            this.StepFourLabel.Text = "Шаг 4. Внесите сумму";
            // 
            // StepArrowLabel1
            // 
            this.StepArrowLabel1.AutoSize = true;
            this.StepArrowLabel1.Location = new System.Drawing.Point(151, 381);
            this.StepArrowLabel1.Name = "StepArrowLabel1";
            this.StepArrowLabel1.Size = new System.Drawing.Size(13, 13);
            this.StepArrowLabel1.TabIndex = 32;
            this.StepArrowLabel1.Text = ">";
            // 
            // StepArrowLabel2
            // 
            this.StepArrowLabel2.AutoSize = true;
            this.StepArrowLabel2.Location = new System.Drawing.Point(348, 381);
            this.StepArrowLabel2.Name = "StepArrowLabel2";
            this.StepArrowLabel2.Size = new System.Drawing.Size(13, 13);
            this.StepArrowLabel2.TabIndex = 33;
            this.StepArrowLabel2.Text = ">";
            // 
            // StepArrowLabel3
            // 
            this.StepArrowLabel3.AutoSize = true;
            this.StepArrowLabel3.Location = new System.Drawing.Point(500, 381);
            this.StepArrowLabel3.Name = "StepArrowLabel3";
            this.StepArrowLabel3.Size = new System.Drawing.Size(13, 13);
            this.StepArrowLabel3.TabIndex = 34;
            this.StepArrowLabel3.Text = ">";
            // 
            // ResetLink
            // 
            this.ResetLink.AutoSize = true;
            this.ResetLink.LinkColor = System.Drawing.Color.Maroon;
            this.ResetLink.Location = new System.Drawing.Point(688, 381);
            this.ResetLink.Name = "ResetLink";
            this.ResetLink.Size = new System.Drawing.Size(91, 13);
            this.ResetLink.TabIndex = 35;
            this.ResetLink.TabStop = true;
            this.ResetLink.Text = "Сбросить форму";
            this.ResetLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ResetLink_LinkClicked);
            // 
            // AddResident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(784, 401);
            this.Controls.Add(this.ResetLink);
            this.Controls.Add(this.StepArrowLabel3);
            this.Controls.Add(this.StepArrowLabel2);
            this.Controls.Add(this.StepArrowLabel1);
            this.Controls.Add(this.StepFourLabel);
            this.Controls.Add(this.StepThreeLabel);
            this.Controls.Add(this.StepTwoLabel);
            this.Controls.Add(this.StepOneLabel);
            this.Controls.Add(this.CalcPanel);
            this.Controls.Add(this.ClientPanel);
            this.Controls.Add(this.DatePanel);
            this.Controls.Add(this.RoomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(800, 440);
            this.Name = "AddResident";
            this.ShowIcon = false;
            this.Text = "Добавление поселенца";
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGridView)).EndInit();
            this.RoomPanel.ResumeLayout(false);
            this.RoomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsGridView)).EndInit();
            this.DatePanel.ResumeLayout(false);
            this.DatePanel.PerformLayout();
            this.ClientPanel.ResumeLayout(false);
            this.ClientPanel.PerformLayout();
            this.CalcPanel.ResumeLayout(false);
            this.CalcPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonClient;
        private System.Windows.Forms.TextBox BoxClientFirstName;
        private System.Windows.Forms.TextBox BoxClientLastName;
        private System.Windows.Forms.DataGridView ClientsGridView;
        private System.Windows.Forms.Button AddResidentButton;
        private System.Windows.Forms.Label LabelClients;
        private System.Windows.Forms.Label LabelCost;
        private System.Windows.Forms.TextBox BoxCost;
        private System.Windows.Forms.TextBox BoxAmount;
        private System.Windows.Forms.Label LabelAmount;
        private System.Windows.Forms.Label LabelRent;
        private System.Windows.Forms.TextBox BoxRent;
        private System.Windows.Forms.Panel RoomPanel;
        private System.Windows.Forms.TextBox BoxRoomName;
        private System.Windows.Forms.Label LabelRooms;
        private System.Windows.Forms.ComboBox BoxRoomType;
        private System.Windows.Forms.Button ButtonRoom;
        private System.Windows.Forms.Panel DatePanel;
        private System.Windows.Forms.Label ReservationLabel;
        private System.Windows.Forms.Label ReservationValue;
        private System.Windows.Forms.Label FreeValue;
        private System.Windows.Forms.Label FreeLabel;
        private System.Windows.Forms.Label AvailableValue;
        private System.Windows.Forms.Label AvailableLabel;
        private System.Windows.Forms.Label NumDays;
        private System.Windows.Forms.TextBox DaysBox;
        private System.Windows.Forms.Label TextDateLabel;
        private System.Windows.Forms.Panel ClientPanel;
        private System.Windows.Forms.Panel CalcPanel;
        private System.Windows.Forms.Label StepOneLabel;
        private System.Windows.Forms.Label StepTwoLabel;
        private System.Windows.Forms.Label StepThreeLabel;
        private System.Windows.Forms.Label StepFourLabel;
        private System.Windows.Forms.Label StepArrowLabel1;
        private System.Windows.Forms.Label StepArrowLabel2;
        private System.Windows.Forms.Label StepArrowLabel3;
        private System.Windows.Forms.LinkLabel ResetLink;
        private System.Windows.Forms.DataGridView RoomsGridView;
    }
}