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
    public partial class AddReservations : Form
    {
        OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString);

        DateTime Now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public AddReservations()
        {
            InitializeComponent();

            String query = "SELECT ID, Name FROM RoomTypes";
            DataSet RoomTypeDS = new DataSet();

            OleDbDataAdapter RoomTypeAdapter = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder RoomTypeBuilder = new OleDbCommandBuilder(RoomTypeAdapter);
            RoomTypeAdapter.Fill(RoomTypeDS, "Cards");

            BoxRoomType.DataSource = RoomTypeDS.Tables[0];
            BoxRoomType.DisplayMember = "Name";
            BoxRoomType.ValueMember = "ID";

            TodayDateLabel.Text = "Сегодня: " + DateTime.Now.ToShortDateString();

            CheckCalendar.MinDate = Now;
            CheckCalendar.MaxDate = CheckCalendar.MinDate.AddMonths(4);

            ErrorOut.Text = String.Empty;
            OutTextDate.Text = String.Empty;
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
            bool isFilter = false;
            String query = "SELECT Clients.ID, FirstName AS Фамилия, LastName AS Имя, Patronymic AS Отчество, Birthday AS \"День рождения\", Phone AS Телефон FROM Clients";

            if (!string.IsNullOrEmpty(BoxClientFirstName.Text) && !BoxClientFirstName.Text.Equals("Фамилия", StringComparison.OrdinalIgnoreCase))
            {
                if (!isFilter)
                {
                    isFilter = true;
                    query += " WHERE FirstName LIKE '%" + BoxClientFirstName.Text + "%'";
                }
                else query += " AND FirstName LIKE '%" + BoxClientFirstName.Text + "%'";
            }

            if (!string.IsNullOrEmpty(BoxClientLastName.Text) && !BoxClientLastName.Text.Equals("Имя", StringComparison.OrdinalIgnoreCase))
            {
                if (!isFilter)
                {
                    isFilter = true;
                    query += " WHERE LastName LIKE '%" + BoxClientLastName.Text + "%'";
                }
                else query += " AND LastName LIKE '%" + BoxClientLastName.Text + "%'";
            }

            DataSet roomDS = new DataSet();
            OleDbDataAdapter roomAdapter = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder roomBuilder = new OleDbCommandBuilder(roomAdapter);
            roomAdapter.Fill(roomDS, "Clients");

            ClientsGridView.DataSource = roomDS;
            ClientsGridView.DataMember = "Clients";
            ClientsGridView.Columns["ID"].Visible = false;
        }

        private void ClientsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientPanel.Enabled = false;
            RoomTypePanel.Enabled = true;
            StepOneLabel.ForeColor = Color.Black;
            DatePanel.Enabled = true;
            StepTwoLabel.ForeColor = Color.Black;
        }

        private void BoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckCalendar.RemoveAllBoldedDates();
            CheckCalendar.UpdateBoldedDates();

            int typeRoom = (int) BoxRoomType.SelectedValue;
            String queryRoom;
            if(typeRoom == 1 || typeRoom == 2) queryRoom = "SELECT COUNT(*) FROM Rooms WHERE RoomType_ID = " + typeRoom;
            else queryRoom = "SELECT COUNT(NumBed) FROM Rooms WHERE RoomType_ID = " + typeRoom;

            connection.Open();
            OleDbCommand cmd = new OleDbCommand(queryRoom, connection);
            int CountRoom = (int)cmd.ExecuteScalar();
            connection.Close();

            for(DateTime i = Now; i < Now.AddMonths(4); i = i.AddDays(1))
            {
                String query = "SELECT COUNT(*) FROM (SELECT RoomType_ID, DateSettling, DateEviction FROM Reservations WHERE DateSettling > GetDate()-1 UNION SELECT RoomType_ID ,DateSettling, DateEviction FROM RegisterCards INNER JOIN Rooms ON RegisterCards.Room_ID = Rooms.ID) AS UnTbl WHERE RoomType_ID = " + typeRoom + " AND '" + i.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction";
                connection.Open();
                cmd = new OleDbCommand(query, connection);
                int recordCount = (int)cmd.ExecuteScalar();
                connection.Close();

                if (CountRoom <= recordCount)
                {
                    CheckCalendar.AddBoldedDate(i);
                }
            }

            CheckCalendar.UpdateBoldedDates();
        }

        bool CheckBoldDays(DateTime CheckIn, DateTime CheckOut)
        {
            for(; CheckIn < CheckOut; CheckIn = CheckIn.AddDays(1))
            {
                if (CheckCalendar.BoldedDates.Contains(CheckIn)) return true;
            }
            return false;
        }

        bool isCorrectDates()
        {
            DateTime CheckIn = CheckCalendar.SelectionStart;
            DateTime CheckOut = CheckCalendar.SelectionEnd;
            OutTextDate.Text = CheckIn.ToShortDateString() + " - " + CheckOut.ToShortDateString();

            if ((CheckOut - CheckIn).Days < 1)
            {
                ErrorOut.Text = "Должно быть выбрано минимум 2 дня.";
                OutTextDate.ForeColor = Color.Black;
                StepThreeLabel.ForeColor = Color.DimGray;
                return false;
            }
            else if (CheckBoldDays(CheckIn, CheckOut.AddDays(-1)))
            {
                ErrorOut.Text = "Вы выбрали дату, которую мы не можем забронировать.";
                OutTextDate.ForeColor = Color.Black;
                StepThreeLabel.ForeColor = Color.DimGray;
                return false;
            }
            else
            {
                String Select = "SELECT COUNT(*) FROM RegisterCards WHERE Client_ID = " + ClientsGridView.CurrentRow.Cells[0].Value + " AND DateEviction-1 > '" + CheckIn.ToString("yyyy-MM-dd") + "'";

                connection.Open();
                OleDbCommand cmdC = new OleDbCommand(Select, connection);
                int recordCount = (int)cmdC.ExecuteScalar();

                if (recordCount > 0)
                {
                    ErrorOut.Text = "Клиент уже проживает в отеле, в выбраный промежуток.";
                    OutTextDate.ForeColor = Color.Black;
                    StepThreeLabel.ForeColor = Color.DimGray;
                    connection.Close();
                    return false;
                }

                Select = "SELECT COUNT(*) FROM Reservations WHERE Client_ID = " + ClientsGridView.CurrentRow.Cells[0].Value + " AND ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction OR '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction OR ('" + CheckIn.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction AND '" + CheckOut.ToString("yyyy-MM-dd") + "' BETWEEN DateSettling AND DateEviction) OR (DateSettling BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "' AND DateEviction BETWEEN '" + CheckIn.ToString("yyyy-MM-dd") + "' AND '" + CheckOut.ToString("yyyy-MM-dd") + "'))";
                cmdC = new OleDbCommand(Select, connection);
                recordCount = (int)cmdC.ExecuteScalar();

                if (recordCount > 0)
                {
                    ErrorOut.Text = "Клиент уже забронировал номер, в выбраный промежуток.";
                    OutTextDate.ForeColor = Color.Black;
                    StepThreeLabel.ForeColor = Color.DimGray;
                    connection.Close();
                    return false;
                }

                connection.Close();
            }

            StepThreeLabel.ForeColor = Color.Black;
            OutTextDate.ForeColor = Color.Green;
            ErrorOut.Text = String.Empty;
            return true;
        }

        private void AddReservationsButton_Click(object sender, EventArgs e)
        {
            String Insert = "INSERT INTO Reservations(Client_ID, RoomType_ID, DateSettling, DateEviction) VALUES('" + ClientsGridView.CurrentRow.Cells[0].Value + "','" + BoxRoomType.SelectedValue + "','" + CheckCalendar.SelectionStart.ToString("yyyy-MM-dd") + "','" + CheckCalendar.SelectionEnd.ToString("yyyy-MM-dd") + "')";
                
            connection.Open();
            OleDbCommand cmd = new OleDbCommand(Insert, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Информация о брони добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            return;
        }

        private void CheckCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (isCorrectDates()) AddPanel.Enabled = true;
            else AddPanel.Enabled = false;
            
            OutTextDate.Visible = true;
            ErrorOut.Visible = true;
        }

        private void CheckCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (isCorrectDates()) AddPanel.Enabled = true;
            else AddPanel.Enabled = false;
        }

        private void ResetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientPanel.Enabled = true;
            BoxClientFirstName.Text = "Фамилия";
            BoxClientLastName.Text = "Имя";
            ClientsGridView.DataSource = new DataSet();
            StepOneLabel.ForeColor = Color.DimGray;

            RoomTypePanel.Enabled = false;
            StepTwoLabel.ForeColor = Color.DimGray;

            DatePanel.Enabled = false;
            OutTextDate.Text = String.Empty;
            ErrorOut.Text = String.Empty;
            CheckCalendar.Refresh();
            StepThreeLabel.ForeColor = Color.DimGray;

            AddPanel.Enabled = false;
        }
    }
}
