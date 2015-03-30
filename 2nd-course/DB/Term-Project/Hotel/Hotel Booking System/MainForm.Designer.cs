namespace Hotel_Booking_System
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.BillingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddResidentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddResidentBronMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReservationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewReservationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddReservationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewClientsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddClientMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoomsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewRoomsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddRoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindByClientMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindByRoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewManagersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainDataGrid = new System.Windows.Forms.DataGridView();
            this.LabelNow = new System.Windows.Forms.Label();
            this.Label1Init = new System.Windows.Forms.Label();
            this.Labe5Init = new System.Windows.Forms.Label();
            this.Label6Init = new System.Windows.Forms.Label();
            this.ButtonMoveOut = new System.Windows.Forms.Button();
            this.EditPayment = new System.Windows.Forms.Button();
            this.Label2Init = new System.Windows.Forms.Label();
            this.Label4Init = new System.Windows.Forms.Label();
            this.Label3Init = new System.Windows.Forms.Label();
            this.UpdateButtons = new System.Windows.Forms.Button();
            this.Label1Out = new System.Windows.Forms.Label();
            this.Label2Out = new System.Windows.Forms.Label();
            this.Label3Out = new System.Windows.Forms.Label();
            this.Label4Out = new System.Windows.Forms.Label();
            this.Label5Out = new System.Windows.Forms.Label();
            this.Label6Out = new System.Windows.Forms.Label();
            this.UpdateMainWindow = new System.Windows.Forms.Timer(this.components);
            this.CurrentTime = new System.Windows.Forms.Label();
            this.Label7Out = new System.Windows.Forms.Label();
            this.AddService = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Peru;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BillingMenuItem,
            this.ReservationsMenuItem,
            this.ClientsMenuItem,
            this.RoomsMenuItem,
            this.ArchiveMenuItem,
            this.InfoMenuItem,
            this.ViewManagersMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(704, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // BillingMenuItem
            // 
            this.BillingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddResidentMenuItem,
            this.AddResidentBronMenuItem});
            this.BillingMenuItem.Name = "BillingMenuItem";
            this.BillingMenuItem.Size = new System.Drawing.Size(90, 20);
            this.BillingMenuItem.Text = "Проживание";
            // 
            // AddResidentMenuItem
            // 
            this.AddResidentMenuItem.Name = "AddResidentMenuItem";
            this.AddResidentMenuItem.Size = new System.Drawing.Size(194, 22);
            this.AddResidentMenuItem.Text = "Поселить (без брони)";
            this.AddResidentMenuItem.Click += new System.EventHandler(this.AddResidentMenuItem_Click);
            // 
            // AddResidentBronMenuItem
            // 
            this.AddResidentBronMenuItem.Name = "AddResidentBronMenuItem";
            this.AddResidentBronMenuItem.Size = new System.Drawing.Size(194, 22);
            this.AddResidentBronMenuItem.Text = "Поселить (по брони)";
            this.AddResidentBronMenuItem.Click += new System.EventHandler(this.AddResidentBronMenuItem_Click);
            // 
            // ReservationsMenuItem
            // 
            this.ReservationsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddReservationsMenuItem,
            this.ViewReservationsMenuItem});
            this.ReservationsMenuItem.Name = "ReservationsMenuItem";
            this.ReservationsMenuItem.Size = new System.Drawing.Size(100, 20);
            this.ReservationsMenuItem.Text = "Бронирование";
            // 
            // ViewReservationsMenuItem
            // 
            this.ViewReservationsMenuItem.Name = "ViewReservationsMenuItem";
            this.ViewReservationsMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ViewReservationsMenuItem.Text = "Просмотр забронированого";
            this.ViewReservationsMenuItem.Click += new System.EventHandler(this.ViewReservationsMenuItem_Click);
            // 
            // AddReservationsMenuItem
            // 
            this.AddReservationsMenuItem.Name = "AddReservationsMenuItem";
            this.AddReservationsMenuItem.Size = new System.Drawing.Size(232, 22);
            this.AddReservationsMenuItem.Text = "Забронировать период";
            this.AddReservationsMenuItem.Click += new System.EventHandler(this.AddReservationsMenuItem_Click);
            // 
            // ClientsMenuItem
            // 
            this.ClientsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewClientsMenuItem,
            this.AddClientMenuItem});
            this.ClientsMenuItem.Name = "ClientsMenuItem";
            this.ClientsMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ClientsMenuItem.Text = "Клиенты";
            // 
            // ViewClientsMenuItem
            // 
            this.ViewClientsMenuItem.Name = "ViewClientsMenuItem";
            this.ViewClientsMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ViewClientsMenuItem.Text = "Просмотр клиентов";
            this.ViewClientsMenuItem.Click += new System.EventHandler(this.ViewClientsMenuItem_Click);
            // 
            // AddClientMenuItem
            // 
            this.AddClientMenuItem.Name = "AddClientMenuItem";
            this.AddClientMenuItem.Size = new System.Drawing.Size(185, 22);
            this.AddClientMenuItem.Text = "Добавить клиента";
            this.AddClientMenuItem.Click += new System.EventHandler(this.AddClientMenuItem_Click);
            // 
            // RoomsMenuItem
            // 
            this.RoomsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewRoomsMenuItem,
            this.AddRoomMenuItem});
            this.RoomsMenuItem.Name = "RoomsMenuItem";
            this.RoomsMenuItem.Size = new System.Drawing.Size(69, 20);
            this.RoomsMenuItem.Text = "Комнаты";
            // 
            // ViewRoomsMenuItem
            // 
            this.ViewRoomsMenuItem.Name = "ViewRoomsMenuItem";
            this.ViewRoomsMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ViewRoomsMenuItem.Text = "Просмотр комнат";
            this.ViewRoomsMenuItem.Click += new System.EventHandler(this.ViewRoomsMenuItem_Click);
            // 
            // AddRoomMenuItem
            // 
            this.AddRoomMenuItem.Name = "AddRoomMenuItem";
            this.AddRoomMenuItem.Size = new System.Drawing.Size(175, 22);
            this.AddRoomMenuItem.Text = "Добавить комнату";
            this.AddRoomMenuItem.Visible = false;
            this.AddRoomMenuItem.Click += new System.EventHandler(this.AddRoomMenuItem_Click);
            // 
            // ArchiveMenuItem
            // 
            this.ArchiveMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindByClientMenuItem,
            this.FindByRoomMenuItem});
            this.ArchiveMenuItem.Name = "ArchiveMenuItem";
            this.ArchiveMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ArchiveMenuItem.Text = "Архив";
            this.ArchiveMenuItem.Visible = false;
            // 
            // FindByClientMenuItem
            // 
            this.FindByClientMenuItem.Name = "FindByClientMenuItem";
            this.FindByClientMenuItem.Size = new System.Drawing.Size(176, 22);
            this.FindByClientMenuItem.Text = "Поиск: по клиенту";
            // 
            // FindByRoomMenuItem
            // 
            this.FindByRoomMenuItem.Name = "FindByRoomMenuItem";
            this.FindByRoomMenuItem.Size = new System.Drawing.Size(176, 22);
            this.FindByRoomMenuItem.Text = "Поиск: по номеру";
            // 
            // InfoMenuItem
            // 
            this.InfoMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.InfoMenuItem.Name = "InfoMenuItem";
            this.InfoMenuItem.Size = new System.Drawing.Size(65, 20);
            this.InfoMenuItem.Text = "Справка";
            this.InfoMenuItem.Click += new System.EventHandler(this.InfoMenuItem_Click);
            // 
            // ViewManagersMenuItem
            // 
            this.ViewManagersMenuItem.Name = "ViewManagersMenuItem";
            this.ViewManagersMenuItem.Size = new System.Drawing.Size(86, 20);
            this.ViewManagersMenuItem.Text = "Менеджеры";
            this.ViewManagersMenuItem.Visible = false;
            this.ViewManagersMenuItem.Click += new System.EventHandler(this.ViewManagersMenuItem_Click);
            // 
            // MainDataGrid
            // 
            this.MainDataGrid.AllowUserToAddRows = false;
            this.MainDataGrid.AllowUserToDeleteRows = false;
            this.MainDataGrid.AllowUserToOrderColumns = true;
            this.MainDataGrid.AllowUserToResizeRows = false;
            this.MainDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataGrid.BackgroundColor = System.Drawing.Color.Wheat;
            this.MainDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.MainDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainDataGrid.GridColor = System.Drawing.Color.SaddleBrown;
            this.MainDataGrid.Location = new System.Drawing.Point(12, 135);
            this.MainDataGrid.Name = "MainDataGrid";
            this.MainDataGrid.ReadOnly = true;
            this.MainDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = "—";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MainDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = "—";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.MainDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.MainDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGrid.Size = new System.Drawing.Size(680, 235);
            this.MainDataGrid.TabIndex = 0;
            this.MainDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDataGrid_CellDoubleClick);
            this.MainDataGrid.Sorted += new System.EventHandler(this.MainDataGrid_Sorted);
            // 
            // LabelNow
            // 
            this.LabelNow.AutoSize = true;
            this.LabelNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelNow.Location = new System.Drawing.Point(9, 117);
            this.LabelNow.Name = "LabelNow";
            this.LabelNow.Size = new System.Drawing.Size(121, 15);
            this.LabelNow.TabIndex = 2;
            this.LabelNow.Text = "Сейчас проживают:";
            // 
            // Label1Init
            // 
            this.Label1Init.AutoSize = true;
            this.Label1Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label1Init.Location = new System.Drawing.Point(9, 36);
            this.Label1Init.Name = "Label1Init";
            this.Label1Init.Size = new System.Drawing.Size(132, 15);
            this.Label1Init.TabIndex = 3;
            this.Label1Init.Text = "Клиентов зарегистр.:";
            this.Label1Init.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Labe5Init
            // 
            this.Labe5Init.AutoSize = true;
            this.Labe5Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Labe5Init.Location = new System.Drawing.Point(449, 36);
            this.Labe5Init.Name = "Labe5Init";
            this.Labe5Init.Size = new System.Drawing.Size(121, 15);
            this.Labe5Init.TabIndex = 5;
            this.Labe5Init.Text = "Свободно номеров:";
            // 
            // Label6Init
            // 
            this.Label6Init.AutoSize = true;
            this.Label6Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label6Init.Location = new System.Drawing.Point(449, 62);
            this.Label6Init.Name = "Label6Init";
            this.Label6Init.Size = new System.Drawing.Size(99, 15);
            this.Label6Init.TabIndex = 7;
            this.Label6Init.Text = "Свободно мест:";
            // 
            // ButtonMoveOut
            // 
            this.ButtonMoveOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonMoveOut.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ButtonMoveOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonMoveOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMoveOut.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ButtonMoveOut.Location = new System.Drawing.Point(287, 376);
            this.ButtonMoveOut.Name = "ButtonMoveOut";
            this.ButtonMoveOut.Size = new System.Drawing.Size(130, 23);
            this.ButtonMoveOut.TabIndex = 9;
            this.ButtonMoveOut.Text = "Выселить";
            this.ButtonMoveOut.UseVisualStyleBackColor = false;
            this.ButtonMoveOut.Click += new System.EventHandler(this.ButtonMoveOut_Click);
            // 
            // EditPayment
            // 
            this.EditPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditPayment.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditPayment.ForeColor = System.Drawing.Color.SaddleBrown;
            this.EditPayment.Location = new System.Drawing.Point(151, 376);
            this.EditPayment.Name = "EditPayment";
            this.EditPayment.Size = new System.Drawing.Size(130, 23);
            this.EditPayment.TabIndex = 10;
            this.EditPayment.Text = "Изменить оплату";
            this.EditPayment.UseVisualStyleBackColor = false;
            this.EditPayment.Click += new System.EventHandler(this.EditPayment_Click);
            // 
            // Label2Init
            // 
            this.Label2Init.AutoSize = true;
            this.Label2Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label2Init.Location = new System.Drawing.Point(9, 62);
            this.Label2Init.Name = "Label2Init";
            this.Label2Init.Size = new System.Drawing.Size(142, 15);
            this.Label2Init.TabIndex = 11;
            this.Label2Init.Text = "Всего проживали (раз):";
            // 
            // Label4Init
            // 
            this.Label4Init.AutoSize = true;
            this.Label4Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label4Init.Location = new System.Drawing.Point(228, 62);
            this.Label4Init.Name = "Label4Init";
            this.Label4Init.Size = new System.Drawing.Size(141, 15);
            this.Label4Init.TabIndex = 15;
            this.Label4Init.Text = "Забронировано (дней):";
            // 
            // Label3Init
            // 
            this.Label3Init.AutoSize = true;
            this.Label3Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label3Init.Location = new System.Drawing.Point(229, 36);
            this.Label3Init.Name = "Label3Init";
            this.Label3Init.Size = new System.Drawing.Size(172, 15);
            this.Label3Init.TabIndex = 13;
            this.Label3Init.Text = "Сумарно арендовано (дней):";
            // 
            // UpdateButtons
            // 
            this.UpdateButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButtons.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.UpdateButtons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpdateButtons.BackgroundImage")));
            this.UpdateButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UpdateButtons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButtons.ForeColor = System.Drawing.Color.SaddleBrown;
            this.UpdateButtons.Location = new System.Drawing.Point(667, 376);
            this.UpdateButtons.Name = "UpdateButtons";
            this.UpdateButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UpdateButtons.Size = new System.Drawing.Size(25, 23);
            this.UpdateButtons.TabIndex = 17;
            this.UpdateButtons.UseVisualStyleBackColor = false;
            this.UpdateButtons.Click += new System.EventHandler(this.UpdateWindow_Click);
            // 
            // Label1Out
            // 
            this.Label1Out.AutoSize = true;
            this.Label1Out.Location = new System.Drawing.Point(189, 38);
            this.Label1Out.Name = "Label1Out";
            this.Label1Out.Size = new System.Drawing.Size(23, 13);
            this.Label1Out.TabIndex = 18;
            this.Label1Out.Text = "null";
            // 
            // Label2Out
            // 
            this.Label2Out.AutoSize = true;
            this.Label2Out.Location = new System.Drawing.Point(189, 64);
            this.Label2Out.Name = "Label2Out";
            this.Label2Out.Size = new System.Drawing.Size(23, 13);
            this.Label2Out.TabIndex = 19;
            this.Label2Out.Text = "null";
            // 
            // Label3Out
            // 
            this.Label3Out.AutoSize = true;
            this.Label3Out.Location = new System.Drawing.Point(400, 38);
            this.Label3Out.Name = "Label3Out";
            this.Label3Out.Size = new System.Drawing.Size(23, 13);
            this.Label3Out.TabIndex = 20;
            this.Label3Out.Text = "null";
            // 
            // Label4Out
            // 
            this.Label4Out.AutoSize = true;
            this.Label4Out.Location = new System.Drawing.Point(400, 64);
            this.Label4Out.Name = "Label4Out";
            this.Label4Out.Size = new System.Drawing.Size(23, 13);
            this.Label4Out.TabIndex = 21;
            this.Label4Out.Text = "null";
            // 
            // Label5Out
            // 
            this.Label5Out.AutoSize = true;
            this.Label5Out.Location = new System.Drawing.Point(620, 38);
            this.Label5Out.Name = "Label5Out";
            this.Label5Out.Size = new System.Drawing.Size(23, 13);
            this.Label5Out.TabIndex = 22;
            this.Label5Out.Text = "null";
            // 
            // Label6Out
            // 
            this.Label6Out.AutoSize = true;
            this.Label6Out.Location = new System.Drawing.Point(620, 64);
            this.Label6Out.Name = "Label6Out";
            this.Label6Out.Size = new System.Drawing.Size(23, 13);
            this.Label6Out.TabIndex = 23;
            this.Label6Out.Text = "null";
            // 
            // UpdateMainWindow
            // 
            this.UpdateMainWindow.Enabled = true;
            this.UpdateMainWindow.Interval = 60000;
            this.UpdateMainWindow.Tick += new System.EventHandler(this.UpdateMainWindow_Tick);
            // 
            // CurrentTime
            // 
            this.CurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentTime.Location = new System.Drawing.Point(546, 117);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(146, 15);
            this.CurrentTime.TabIndex = 24;
            this.CurrentTime.Text = "Current Time";
            this.CurrentTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label7Out
            // 
            this.Label7Out.AutoSize = true;
            this.Label7Out.Location = new System.Drawing.Point(128, 119);
            this.Label7Out.Name = "Label7Out";
            this.Label7Out.Size = new System.Drawing.Size(23, 13);
            this.Label7Out.TabIndex = 25;
            this.Label7Out.Text = "null";
            // 
            // AddService
            // 
            this.AddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddService.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.AddService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddService.ForeColor = System.Drawing.Color.SaddleBrown;
            this.AddService.Location = new System.Drawing.Point(12, 376);
            this.AddService.Name = "AddService";
            this.AddService.Size = new System.Drawing.Size(130, 23);
            this.AddService.TabIndex = 26;
            this.AddService.Text = "Добавить услугу";
            this.AddService.UseVisualStyleBackColor = false;
            this.AddService.Click += new System.EventHandler(this.AddService_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(704, 411);
            this.Controls.Add(this.AddService);
            this.Controls.Add(this.Label7Out);
            this.Controls.Add(this.CurrentTime);
            this.Controls.Add(this.Label6Out);
            this.Controls.Add(this.Label5Out);
            this.Controls.Add(this.Label4Out);
            this.Controls.Add(this.Label3Out);
            this.Controls.Add(this.Label2Out);
            this.Controls.Add(this.Label1Out);
            this.Controls.Add(this.UpdateButtons);
            this.Controls.Add(this.Label4Init);
            this.Controls.Add(this.Label3Init);
            this.Controls.Add(this.Label2Init);
            this.Controls.Add(this.EditPayment);
            this.Controls.Add(this.ButtonMoveOut);
            this.Controls.Add(this.Label6Init);
            this.Controls.Add(this.Labe5Init);
            this.Controls.Add(this.Label1Init);
            this.Controls.Add(this.LabelNow);
            this.Controls.Add(this.MainDataGrid);
            this.Controls.Add(this.MainMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(720, 350);
            this.Name = "MainForm";
            this.Text = "Hotel Booking System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ClientsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewClientsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddClientMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RoomsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ArchiveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewRoomsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddRoomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BillingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddResidentMenuItem;
        private System.Windows.Forms.DataGridView MainDataGrid;
        private System.Windows.Forms.ToolStripMenuItem FindByClientMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindByRoomMenuItem;
        private System.Windows.Forms.Label LabelNow;
        private System.Windows.Forms.Label Label1Init;
        private System.Windows.Forms.Label Labe5Init;
        private System.Windows.Forms.Label Label6Init;
        private System.Windows.Forms.Button ButtonMoveOut;
        private System.Windows.Forms.Button EditPayment;
        private System.Windows.Forms.Label Label2Init;
        private System.Windows.Forms.Label Label4Init;
        private System.Windows.Forms.Label Label3Init;
        private System.Windows.Forms.Button UpdateButtons;
        private System.Windows.Forms.Label Label1Out;
        private System.Windows.Forms.Label Label2Out;
        private System.Windows.Forms.Label Label3Out;
        private System.Windows.Forms.Label Label4Out;
        private System.Windows.Forms.Label Label5Out;
        private System.Windows.Forms.Label Label6Out;
        private System.Windows.Forms.Timer UpdateMainWindow;
        private System.Windows.Forms.Label CurrentTime;
        private System.Windows.Forms.Label Label7Out;
        private System.Windows.Forms.Button AddService;
        private System.Windows.Forms.ToolStripMenuItem AddResidentBronMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReservationsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewReservationsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddReservationsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewManagersMenuItem;


    }
}

