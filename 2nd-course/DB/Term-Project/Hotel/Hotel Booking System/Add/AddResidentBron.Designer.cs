namespace Hotel_Booking_System.Add
{
    partial class AddResidentBron
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RoomsGridView = new System.Windows.Forms.DataGridView();
            this.ClientPanel = new System.Windows.Forms.Panel();
            this.ClientsGridView = new System.Windows.Forms.DataGridView();
            this.ButtonClient = new System.Windows.Forms.Button();
            this.BoxClientLastName = new System.Windows.Forms.TextBox();
            this.BoxClientFirstName = new System.Windows.Forms.TextBox();
            this.LabelClients = new System.Windows.Forms.Label();
            this.RoomPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CalcPanel = new System.Windows.Forms.Panel();
            this.BoxCost = new System.Windows.Forms.TextBox();
            this.AddResidentButton = new System.Windows.Forms.Button();
            this.LabelCost = new System.Windows.Forms.Label();
            this.BoxRent = new System.Windows.Forms.TextBox();
            this.LabelAmount = new System.Windows.Forms.Label();
            this.BoxAmount = new System.Windows.Forms.TextBox();
            this.LabelRent = new System.Windows.Forms.Label();
            this.DatePanel = new System.Windows.Forms.Panel();
            this.NumDaysBroned = new System.Windows.Forms.Label();
            this.TextDateLabel = new System.Windows.Forms.Label();
            this.NumDays = new System.Windows.Forms.Label();
            this.ResetLink = new System.Windows.Forms.LinkLabel();
            this.StepArrowLabel2 = new System.Windows.Forms.Label();
            this.StepThreeLabel = new System.Windows.Forms.Label();
            this.StepTwoLabel = new System.Windows.Forms.Label();
            this.StepOneLabel = new System.Windows.Forms.Label();
            this.StepArrowLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsGridView)).BeginInit();
            this.ClientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGridView)).BeginInit();
            this.RoomPanel.SuspendLayout();
            this.CalcPanel.SuspendLayout();
            this.DatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoomsGridView
            // 
            this.RoomsGridView.AllowUserToAddRows = false;
            this.RoomsGridView.AllowUserToDeleteRows = false;
            this.RoomsGridView.AllowUserToOrderColumns = true;
            this.RoomsGridView.AllowUserToResizeRows = false;
            this.RoomsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RoomsGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.RoomsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RoomsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RoomsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RoomsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomsGridView.GridColor = System.Drawing.Color.SaddleBrown;
            this.RoomsGridView.Location = new System.Drawing.Point(5, 27);
            this.RoomsGridView.Name = "RoomsGridView";
            this.RoomsGridView.ReadOnly = true;
            this.RoomsGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RoomsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RoomsGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.RoomsGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.RoomsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoomsGridView.Size = new System.Drawing.Size(372, 150);
            this.RoomsGridView.TabIndex = 25;
            this.RoomsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomsGridView_CellDoubleClick);
            this.RoomsGridView.SelectionChanged += new System.EventHandler(this.RoomsGridView_SelectionChanged);
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
            // RoomPanel
            // 
            this.RoomPanel.Controls.Add(this.label1);
            this.RoomPanel.Controls.Add(this.RoomsGridView);
            this.RoomPanel.Enabled = false;
            this.RoomPanel.Location = new System.Drawing.Point(399, 87);
            this.RoomPanel.Name = "RoomPanel";
            this.RoomPanel.Size = new System.Drawing.Size(380, 181);
            this.RoomPanel.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Доступные номера забронированного типа:";
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
            this.CalcPanel.TabIndex = 28;
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
            // DatePanel
            // 
            this.DatePanel.Controls.Add(this.NumDaysBroned);
            this.DatePanel.Controls.Add(this.TextDateLabel);
            this.DatePanel.Controls.Add(this.NumDays);
            this.DatePanel.Location = new System.Drawing.Point(399, 6);
            this.DatePanel.Name = "DatePanel";
            this.DatePanel.Size = new System.Drawing.Size(380, 75);
            this.DatePanel.TabIndex = 29;
            // 
            // NumDaysBroned
            // 
            this.NumDaysBroned.AutoSize = true;
            this.NumDaysBroned.Location = new System.Drawing.Point(119, 53);
            this.NumDaysBroned.Name = "NumDaysBroned";
            this.NumDaysBroned.Size = new System.Drawing.Size(23, 13);
            this.NumDaysBroned.TabIndex = 29;
            this.NumDaysBroned.Text = "null";
            // 
            // TextDateLabel
            // 
            this.TextDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextDateLabel.Location = new System.Drawing.Point(3, 23);
            this.TextDateLabel.Name = "TextDateLabel";
            this.TextDateLabel.Size = new System.Drawing.Size(197, 22);
            this.TextDateLabel.TabIndex = 28;
            this.TextDateLabel.Text = "Диапазон дат";
            // 
            // NumDays
            // 
            this.NumDays.AutoSize = true;
            this.NumDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumDays.Location = new System.Drawing.Point(3, 51);
            this.NumDays.Name = "NumDays";
            this.NumDays.Size = new System.Drawing.Size(110, 15);
            this.NumDays.TabIndex = 27;
            this.NumDays.Text = "Количество дней:";
            // 
            // ResetLink
            // 
            this.ResetLink.AutoSize = true;
            this.ResetLink.LinkColor = System.Drawing.Color.Maroon;
            this.ResetLink.Location = new System.Drawing.Point(685, 381);
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
            this.StepArrowLabel2.Location = new System.Drawing.Point(303, 381);
            this.StepArrowLabel2.Name = "StepArrowLabel2";
            this.StepArrowLabel2.Size = new System.Drawing.Size(13, 13);
            this.StepArrowLabel2.TabIndex = 41;
            this.StepArrowLabel2.Text = ">";
            // 
            // StepThreeLabel
            // 
            this.StepThreeLabel.AutoSize = true;
            this.StepThreeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepThreeLabel.Location = new System.Drawing.Point(322, 381);
            this.StepThreeLabel.Name = "StepThreeLabel";
            this.StepThreeLabel.Size = new System.Drawing.Size(119, 13);
            this.StepThreeLabel.TabIndex = 39;
            this.StepThreeLabel.Text = "Шаг 3. Внесите сумму";
            // 
            // StepTwoLabel
            // 
            this.StepTwoLabel.AutoSize = true;
            this.StepTwoLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StepTwoLabel.Location = new System.Drawing.Point(170, 381);
            this.StepTwoLabel.Name = "StepTwoLabel";
            this.StepTwoLabel.Size = new System.Drawing.Size(127, 13);
            this.StepTwoLabel.TabIndex = 38;
            this.StepTwoLabel.Text = "Шаг 2. Выберите номер";
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
            // StepArrowLabel1
            // 
            this.StepArrowLabel1.AutoSize = true;
            this.StepArrowLabel1.Location = new System.Drawing.Point(151, 381);
            this.StepArrowLabel1.Name = "StepArrowLabel1";
            this.StepArrowLabel1.Size = new System.Drawing.Size(13, 13);
            this.StepArrowLabel1.TabIndex = 40;
            this.StepArrowLabel1.Text = ">";
            // 
            // AddResidentBron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(784, 401);
            this.Controls.Add(this.ResetLink);
            this.Controls.Add(this.DatePanel);
            this.Controls.Add(this.CalcPanel);
            this.Controls.Add(this.StepArrowLabel2);
            this.Controls.Add(this.RoomPanel);
            this.Controls.Add(this.StepArrowLabel1);
            this.Controls.Add(this.ClientPanel);
            this.Controls.Add(this.StepThreeLabel);
            this.Controls.Add(this.StepTwoLabel);
            this.Controls.Add(this.StepOneLabel);
            this.MinimumSize = new System.Drawing.Size(800, 440);
            this.Name = "AddResidentBron";
            this.ShowIcon = false;
            this.Text = "Добавление поселенца";
            ((System.ComponentModel.ISupportInitialize)(this.RoomsGridView)).EndInit();
            this.ClientPanel.ResumeLayout(false);
            this.ClientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGridView)).EndInit();
            this.RoomPanel.ResumeLayout(false);
            this.RoomPanel.PerformLayout();
            this.CalcPanel.ResumeLayout(false);
            this.CalcPanel.PerformLayout();
            this.DatePanel.ResumeLayout(false);
            this.DatePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RoomsGridView;
        private System.Windows.Forms.Panel ClientPanel;
        private System.Windows.Forms.DataGridView ClientsGridView;
        private System.Windows.Forms.Button ButtonClient;
        private System.Windows.Forms.TextBox BoxClientLastName;
        private System.Windows.Forms.TextBox BoxClientFirstName;
        private System.Windows.Forms.Label LabelClients;
        private System.Windows.Forms.Panel RoomPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel CalcPanel;
        private System.Windows.Forms.TextBox BoxCost;
        private System.Windows.Forms.Button AddResidentButton;
        private System.Windows.Forms.Label LabelCost;
        private System.Windows.Forms.TextBox BoxRent;
        private System.Windows.Forms.Label LabelAmount;
        private System.Windows.Forms.TextBox BoxAmount;
        private System.Windows.Forms.Label LabelRent;
        private System.Windows.Forms.Panel DatePanel;
        private System.Windows.Forms.Label NumDaysBroned;
        private System.Windows.Forms.Label TextDateLabel;
        private System.Windows.Forms.Label NumDays;
        private System.Windows.Forms.LinkLabel ResetLink;
        private System.Windows.Forms.Label StepArrowLabel2;
        private System.Windows.Forms.Label StepThreeLabel;
        private System.Windows.Forms.Label StepTwoLabel;
        private System.Windows.Forms.Label StepOneLabel;
        private System.Windows.Forms.Label StepArrowLabel1;
    }
}