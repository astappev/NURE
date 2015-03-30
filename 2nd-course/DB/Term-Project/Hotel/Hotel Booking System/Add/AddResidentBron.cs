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
    public partial class AddResidentBron : Form
    {
        OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString);

        DateTime CheckIn = DateTime.Now;
        DateTime CheckOut;

        bool isDiscount = false;
        bool isReady = false;

        int type;
        int days;
        int cost;
        int paid;

        public AddResidentBron()
        {
            InitializeComponent();
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

        private void ButtonClient_Click(object sender, EventArgs e)
        {
            String query = "SELECT Clients.ID, FirstName AS Фамилия, LastName AS Имя, Patronymic AS Отчество, Birthday AS [День рождения], Phone AS Телефон FROM Clients WHERE EXISTS(SELECT * FROM Reservations WHERE Reservations.Client_ID = Clients.ID AND DateSettling BETWEEN GetDate()-1 AND GETDATE()+1)";

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
                    StepThreeLabel.ForeColor = Color.Black;

                }
                else if (cost / days <= paid)
                {
                    isReady = true;
                    LabelRent.Text = "Остаток стоимости:";
                    LabelRent.ForeColor = Color.Blue;
                    BoxRent.Text = (cost - paid).ToString();
                    AddResidentButton.Enabled = true;
                    StepThreeLabel.ForeColor = Color.Black;
                }
                else
                {
                    isReady = false;
                    LabelRent.Text = "Недостаточно:";
                    LabelRent.ForeColor = Color.Red;
                    BoxRent.Text = (cost / days - paid).ToString();
                    AddResidentButton.Enabled = false;
                    StepThreeLabel.ForeColor = Color.DimGray;
                }

                BoxRent.Visible = true;
                LabelRent.Visible = true;
            }
        }

        private void RoomsGridView_SelectionChanged(object sender, EventArgs e)
        {
            Calc_Sum();
        }

        private void ClientsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String queryArch = "SELECT COUNT(*) FROM Archives WHERE Client_ID = " + ClientsGridView.CurrentRow.Cells[0].Value + " AND DateEviction > '" + DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd") + "'";

            connection.Open();
            OleDbCommand cmd = new OleDbCommand(queryArch, connection);
            OleDbDataReader line = cmd.ExecuteReader();
            if (line.Read()) if (line.GetInt32(0) > 0) isDiscount = true;

            String query = "SELECT * FROM Reservations WHERE Client_ID = " + ClientsGridView.CurrentRow.Cells[0].Value;
            
            cmd = new OleDbCommand(query, connection);
            line = cmd.ExecuteReader();
            if (line.Read())
            {
                this.type = line.GetInt32(2);
                this.CheckIn = line.GetDateTime(3);
                this.CheckOut = line.GetDateTime(4);
            }
            connection.Close();
            TextDateLabel.Text = CheckIn.ToShortDateString() + " - " + CheckOut.ToShortDateString();
            days = (CheckOut - CheckIn).Days;
            NumDaysBroned.Text = days.ToString();

            String queryGrid, queryFree, queryReservations;
            if (type == 1 || type == 2)
            {
                queryGrid = "SELECT ID, Name AS [Название], Cost AS [Стоимость], NumBed AS [Кол-во мест] FROM Rooms WHERE Rooms.RoomType_ID = " + type + " AND NOT EXISTS(SELECT Room_ID FROM RegisterCards WHERE RegisterCards.Room_ID = Rooms.ID AND ('" + DateTime.Now.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction-1))";
            }
            else
            {
                queryGrid = "SELECT ID, Name AS [Название], Cost AS [Стоимость], NumBed AS [Кол-во мест], NumBed-ISNULL(Busy, 0) AS [Свободно мест] FROM Rooms LEFT JOIN (SELECT Room_ID, COUNT(*) AS [Busy] FROM RegisterCards WHERE '" + DateTime.Now.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction-1 GROUP BY Room_ID) AS AlredyExists ON AlredyExists.Room_ID = Rooms.ID WHERE Rooms.RoomType_ID = " + type + " AND (Busy IS NULL OR Busy < NumBed)";
            }

            DataSet roomDS = new DataSet();
            OleDbDataAdapter roomAdapter = new OleDbDataAdapter(queryGrid, connection);
            OleDbCommandBuilder roomBuilder = new OleDbCommandBuilder(roomAdapter);
            roomAdapter.Fill(roomDS, "Rooms");

            RoomsGridView.DataSource = roomDS;
            RoomsGridView.DataMember = "Rooms";
            RoomsGridView.Columns["ID"].Visible = false;

            ClientPanel.Enabled = false;
            RoomPanel.Enabled = true;
            StepOneLabel.ForeColor = Color.Black;
        }

        private void RoomsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RoomPanel.Enabled = false;
            CalcPanel.Enabled = true;
            StepTwoLabel.ForeColor = Color.Black;
        }

        private void ResetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientPanel.Enabled = true;
            BoxClientFirstName.Text = "Фамилия";
            BoxClientLastName.Text = "Имя";
            ClientsGridView.DataSource = new DataSet();
            StepOneLabel.ForeColor = Color.DimGray;

            DatePanel.Enabled = false;
            TextDateLabel.Text = "Диапазон дат";
            NumDaysBroned.Text = "null";
            StepTwoLabel.ForeColor = Color.DimGray;

            RoomPanel.Enabled = false;
            RoomsGridView.DataSource = new DataSet();
            StepTwoLabel.ForeColor = Color.DimGray;

            CalcPanel.Enabled = false;
            BoxCost.Text = String.Empty;
            BoxAmount.Text = String.Empty;
            LabelRent.Visible = false;
            BoxRent.Visible = false;
            BoxRent.Text = String.Empty;
            StepThreeLabel.ForeColor = Color.DimGray;
        }

        private void AddResidentButton_Click(object sender, EventArgs e)
        {
            if (!isReady) MessageBox.Show("Проверьте оплату.", "Ошибка заполнения", MessageBoxButtons.OK);
            else
            {
                String Select = "SELECT COUNT(*) FROM RegisterCards WHERE Client_ID = " + ClientsGridView.CurrentRow.Cells[0].Value;

                connection.Open();
                OleDbCommand cmdC = new OleDbCommand(Select, connection);
                int recordCount = (int)cmdC.ExecuteScalar();
                connection.Close();

                if (recordCount > 0)
                {
                    MessageBox.Show("Клиент уже заселен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
