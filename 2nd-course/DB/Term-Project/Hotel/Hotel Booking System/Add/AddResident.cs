using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hotel_Booking_System.Add
{
    public partial class AddResident : Form
    {
        OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString);

        DateTime CheckIn  = DateTime.Now;
        DateTime CheckOut;

        bool isDiscount = false;
        bool isReady = false;

        int days;
        int cost;
        int paid;

        public AddResident()
        {
            InitializeComponent();
            UpdateDateText(1);

            String query = "SELECT ID, Name FROM RoomTypes";
            DataSet RoomTypeDS = new DataSet();

            OleDbDataAdapter RoomTypeAdapter = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder RoomTypeBuilder = new OleDbCommandBuilder(RoomTypeAdapter);
            RoomTypeAdapter.Fill(RoomTypeDS, "Cards");

            BoxRoomType.DataSource = RoomTypeDS.Tables[0];
            BoxRoomType.DisplayMember = "Name";
            BoxRoomType.ValueMember = "ID";
        }

        void UpdateDateText(int days)
        {
            if (days > 0 && days < 31)
            {
                CheckOut = CheckIn.AddDays(days);
                TextDateLabel.Text = CheckIn.ToShortDateString() + " - " + CheckOut.ToShortDateString();
            }
            else MessageBox.Show("Ошибка в дате!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BoxClientFirstName_Enter(object sender, EventArgs e)
        {
            if (BoxClientFirstName.Text.Equals("Фамилия", StringComparison.OrdinalIgnoreCase))
            {
                BoxClientFirstName.Text = string.Empty;
            }
        }
        private void BoxClientFirstName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoxClientFirstName.Text))
            {
                BoxClientFirstName.Text = "Фамилия";
            }
        }
        private void BoxClientLastName_Enter(object sender, EventArgs e)
        {
            if (BoxClientLastName.Text.Equals("Имя", StringComparison.OrdinalIgnoreCase))
            {
                BoxClientLastName.Text = string.Empty;
            }
        }
        private void BoxClientLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoxClientLastName.Text))
            {
                BoxClientLastName.Text = "Имя";
            }
        }
        private void BoxRoomName_Enter(object sender, EventArgs e)
        {
            if (BoxRoomName.Text.Equals("Название", StringComparison.OrdinalIgnoreCase))
            {
                BoxRoomName.Text = string.Empty;
            }
        }
        private void BoxRoomName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoxRoomName.Text))
            {
                BoxRoomName.Text = "Название";
            }
        }
        private void BoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        private void DaysBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void ButtonClient_Click(object sender, EventArgs e)
        {
            String query = "SELECT Clients.ID, FirstName AS Фамилия, LastName AS Имя, Patronymic AS Отчество, Birthday AS \"День рождения\", Phone AS Телефон FROM Clients WHERE NOT EXISTS(SELECT * FROM RegisterCards WHERE Clients.ID = RegisterCards.Client_ID)";

            if (!string.IsNullOrEmpty(BoxClientFirstName.Text) && !BoxClientFirstName.Text.Equals("Фамилия", StringComparison.OrdinalIgnoreCase))
            {
                query += " AND FirstName LIKE '%" + BoxClientFirstName.Text + "%'";
            }

            if (!string.IsNullOrEmpty(BoxClientLastName.Text) && !BoxClientLastName.Text.Equals("Имя", StringComparison.OrdinalIgnoreCase))
            {
                query += " AND LastName LIKE '%" + BoxClientLastName.Text + "%'";
            }

            DataSet roomDS = new DataSet();
            OleDbDataAdapter roomAdapter = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder roomBuilder = new OleDbCommandBuilder(roomAdapter);
            roomAdapter.Fill(roomDS, "Clients");

            ClientsGridView.DataSource = roomDS;
            ClientsGridView.DataMember = "Clients";
            ClientsGridView.Columns["ID"].Visible = false;
        }

        private void ButtonRoom_Click(object sender, EventArgs e)
        {
            int type = (int) BoxRoomType.SelectedValue;

            String queryGrid, queryFree, queryReservations;
            if (type == 1 || type == 2)
            {
                queryGrid = "SELECT ID, Name AS [Название], Cost AS [Стоимость], NumBed AS [Кол-во мест] FROM Rooms WHERE Rooms.RoomType_ID = " + type + " AND NOT EXISTS(SELECT Room_ID FROM RegisterCards WHERE RegisterCards.Room_ID = Rooms.ID AND ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction-1 OR '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling+1 AND DateEviction OR ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction AND '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction) OR (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' AND DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "')))";
                queryFree = "SELECT COUNT(*) AS [Свободно] FROM Rooms WHERE Rooms.RoomType_ID = " + type + " AND NOT EXISTS(SELECT Room_ID FROM RegisterCards WHERE RegisterCards.Room_ID = Rooms.ID AND ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction-1 OR '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling+1 AND DateEviction OR ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction AND '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction) OR (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' AND DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "')))";
                queryReservations = "SELECT COUNT(*) AS [Забронировано] FROM Reservations WHERE RoomType_ID = " + type + " AND (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.AddDays(-1).ToString("yyyy-MM-dd") + "' OR DateEviction BETWEEN '" + CheckIn.AddDays(1).ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' OR (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' AND DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "') OR ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction AND '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction))";
            }
            else
            {
                queryGrid = "SELECT ID, Name AS [Название], Cost AS [Стоимость], NumBed AS [Кол-во мест], NumBed-ISNULL(Busy, 0) AS [Свободно мест] FROM Rooms LEFT JOIN (SELECT Room_ID, COUNT(*) AS [Busy] FROM RegisterCards WHERE '" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction-1 OR '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling+1 AND DateEviction OR ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction AND '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction) OR (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' AND DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "') GROUP BY Room_ID) AS AlredyExists ON AlredyExists.Room_ID = Rooms.ID WHERE Rooms.RoomType_ID = " + type + " AND (Busy IS NULL OR Busy < NumBed)";
                queryFree = "SELECT IsNull(SUM(NumBed-ISNULL(Busy, 0)), 0) AS [Свободно] FROM Rooms LEFT JOIN (SELECT Room_ID, COUNT(*) AS [Busy] FROM RegisterCards WHERE '" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction-1 OR '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling+1 AND DateEviction OR ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction AND '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction) OR (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' AND DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "') GROUP BY Room_ID) AS AlredyExists ON AlredyExists.Room_ID = Rooms.ID WHERE Rooms.RoomType_ID = " + type + " AND (Busy IS NULL OR Busy < NumBed)";
                queryReservations = "SELECT COUNT(*) AS [Забронировано] FROM Reservations WHERE RoomType_ID = " + type + " AND (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.AddDays(-1).ToString("yyyy-MM-dd") + "' OR DateEviction BETWEEN '" + CheckIn.AddDays(1).ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' OR (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' AND DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "') OR ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction AND '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction))";
            }

            if (!string.IsNullOrEmpty(BoxRoomName.Text) && !BoxRoomName.Text.Equals("Название", StringComparison.OrdinalIgnoreCase))
            {
                queryGrid += " AND Name LIKE '%" + BoxRoomName.Text + "%'";
            }

            int free = 0, reserv = 0, available;
            using (OleDbConnection conLabel = new OleDbConnection(MainForm.ConnectionString))
            {
                conLabel.Open();
                OleDbCommand cmd = new OleDbCommand(queryFree, conLabel);
                OleDbDataReader line = cmd.ExecuteReader();

                if (line.Read()) free = line.GetInt32(0);
                cmd = new OleDbCommand(queryReservations, conLabel);
                line = cmd.ExecuteReader();

                if (line.Read()) reserv = line.GetInt32(0);
                conLabel.Close();
            }

            available = free - reserv;
            if (available > 0)
            {
                connection.Open();
                DataSet roomDS = new DataSet();
                OleDbDataAdapter roomAdapter = new OleDbDataAdapter(queryGrid, connection);
                OleDbCommandBuilder roomBuilder = new OleDbCommandBuilder(roomAdapter);
                roomAdapter.Fill(roomDS, "Rooms");
                connection.Close();

                RoomsGridView.DataSource = roomDS;
                RoomsGridView.DataMember = "Rooms";
                RoomsGridView.Columns["ID"].Visible = false;

                FreeValue.Text = free.ToString();
                ReservationValue.Text = reserv.ToString();
                AvailableValue.Text = available.ToString();
            }
            else MessageBox.Show("Все номера данного типа заняты", "Валидация", MessageBoxButtons.OK ,MessageBoxIcon.Information);
        }

        private void ClientsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String query = "SELECT COUNT(*) FROM Archives WHERE Client_ID = " + ClientsGridView.CurrentRow.Cells[0].Value + " AND DateEviction > '" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd") + "'";

            connection.Open();
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader line = cmd.ExecuteReader();
            if (line.Read()) if (line.GetInt32(0) > 0) isDiscount = true;
            connection.Close();

            ClientPanel.Enabled = false;
            DatePanel.Enabled = true;
            StepOneLabel.ForeColor = Color.Black;
        }

        private void DaysBox_TextChanged(object sender, EventArgs e)
        {
            if (DaysBox.TextLength < 1 || Convert.ToInt32(DaysBox.Text) < 1) DaysBox.Text = "1";
            else if (Convert.ToInt32(DaysBox.Text) > 30) DaysBox.Text = "30";
            UpdateDateText(Convert.ToInt32(DaysBox.Text));

            RoomPanel.Enabled = true;
            StepTwoLabel.ForeColor = Color.Black;

            Calc_Sum();
        }

        private void RoomsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DatePanel.Enabled = false;
            RoomPanel.Enabled = false;
            CalcPanel.Enabled = true;
            StepThreeLabel.ForeColor = Color.Black;
        }

        private void Calc_Sum()
        {
            if (RoomsGridView.CurrentRow != null)
            {
                days = (CheckOut - CheckIn).Days;
                int costRoom = (int)RoomsGridView.CurrentRow.Cells[2].Value;
                int costDays = (isDiscount) ? (int)(costRoom * 0.9) : costRoom;
                cost = days * costDays;
                BoxCost.Text = cost.ToString();
            }
        }

        private void RoomsGridView_SelectionChanged(object sender, EventArgs e)
        {
            Calc_Sum();
        }

        private void BoxAmount_TextChanged(object sender, EventArgs e)
        {
            if (days != null && cost != null)
            {
                if (Convert.ToInt32((BoxAmount.Text == String.Empty) ? "0" : BoxAmount.Text) == 0)
                {
                    this.paid = 0;
                }
                else
                {
                    this.paid = Convert.ToInt32(BoxAmount.Text);
                }

                if (cost <= paid)
                {
                    isReady = true;
                    LabelRent.Text = "Свыше стоимости:";
                    LabelRent.ForeColor = Color.Green;
                    BoxRent.Text = (paid - cost).ToString();
                    AddResidentButton.Enabled = true;
                    StepFourLabel.ForeColor = Color.Black;
                        
                }
                else if (cost / days <= paid)
                {
                    isReady = true;
                    LabelRent.Text = "Остаток стоимости:";
                    LabelRent.ForeColor = Color.Blue;
                    BoxRent.Text = (cost - paid).ToString();
                    AddResidentButton.Enabled = true;
                    StepFourLabel.ForeColor = Color.Black;
                }
                else
                {
                    isReady = false;
                    LabelRent.Text = "Недостаточно:";
                    LabelRent.ForeColor = Color.Red;
                    BoxRent.Text = (cost/days - paid).ToString();
                    AddResidentButton.Enabled = false;
                    StepFourLabel.ForeColor = Color.DimGray;
                }

                BoxRent.Visible = true;
                LabelRent.Visible = true;
            }
        }

        private void AddResidentButton_Click(object sender, EventArgs e)
        {
            if (!isReady) MessageBox.Show("Проверьте оплату.", "Ошибка заполнения", MessageBoxButtons.OK);
            else
            {
                String Select = "SELECT COUNT(*) FROM Reservations WHERE " + ClientsGridView.CurrentRow.Cells[0].Value + " = Client_ID AND ('" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction OR DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "')";
                
                connection.Open();
                OleDbCommand cmdC = new OleDbCommand(Select, connection);
                int recordCount = (int) cmdC.ExecuteScalar();
                connection.Close();

                if (recordCount > 0)
                {
                    MessageBox.Show("В эти дни, клиент имеет уже забронированные номера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    String Insert = "INSERT INTO RegisterCards (Client_ID, Room_ID, DateSettling, DateEviction, NumDaysPaid, SumPaid, FinalyCost) VALUES('" + ClientsGridView.CurrentRow.Cells[0].Value + "','" + RoomsGridView.CurrentRow.Cells[0].Value + "','" + CheckIn.ToString("yyyy-MM-dd") + "','" + CheckOut.ToString("yyyy-MM-dd") + "', " + (int)(cost / paid) + ", " + paid + ", " + cost + ")";

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(Insert, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Информация о поселенце добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    return;
                }
            }
        }

        private void ResetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientPanel.Enabled = true;
            BoxClientFirstName.Text = "Фамилия";
            BoxClientLastName.Text = "Имя";
            ClientsGridView.DataSource = new DataSet();
            StepOneLabel.ForeColor = Color.DimGray;

            DatePanel.Enabled = false;
            DaysBox.Text = String.Empty;
            UpdateDateText(1);
            StepTwoLabel.ForeColor = Color.DimGray;

            RoomPanel.Enabled = false;
            BoxRoomName.Text = "Название";
            RoomsGridView.DataSource = new DataSet();
            FreeValue.Text = "";
            ReservationValue.Text = "";
            AvailableValue.Text = "";
            StepThreeLabel.ForeColor = Color.DimGray;

            CalcPanel.Enabled = false;
            BoxCost.Text = String.Empty;
            BoxAmount.Text = String.Empty;
            LabelRent.Visible = false;
            BoxRent.Visible = false;
            BoxRent.Text = String.Empty;
            StepFourLabel.ForeColor = Color.DimGray;
        }
    }
}
