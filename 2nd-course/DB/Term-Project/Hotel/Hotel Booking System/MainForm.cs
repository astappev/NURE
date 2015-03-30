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
using System.Configuration;

namespace Hotel_Booking_System
{
    public partial class MainForm : Form
    {
        static public string ConnectionString = ConfigurationManager.ConnectionStrings["HotelConnection"].ConnectionString;

        public MainForm()
        {
            InitializeComponent();

            if(Login.role == 3)
            {
                AddRoomMenuItem.Visible = true;
                ViewManagersMenuItem.Visible = true;
            }

            UpdateMainInfo();
        }

        private void UpdateMainInfo()
        {
            // Часики
            CurrentTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

            // Основной Grid
            string query = "SELECT RegisterCards.ID AS ID, Clients.FirstName AS Фамилия, Clients.LastName AS Имя, Rooms.Name AS Номер, RegisterCards.DateSettling AS [Дата заселения], RegisterCards.DateEviction AS [Дата выселения], FinalyCost AS [Общая стоимость] FROM RegisterCards INNER JOIN Rooms ON RegisterCards.Room_ID = Rooms.ID INNER JOIN Clients ON RegisterCards.Client_ID = Clients.ID WHERE GetDate() >= DateSettling";
            DataSet CardsDS = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {

                OleDbDataAdapter CardsAdapter = new OleDbDataAdapter(query, connection);
                OleDbCommandBuilder CardsBuilder = new OleDbCommandBuilder(CardsAdapter);
                CardsAdapter.Fill(CardsDS, "Cards");
            }

            MainDataGrid.DataSource = CardsDS;
            MainDataGrid.DataMember = "Cards";
            MainDataGrid.Columns["ID"].Visible = false;
            SelectWarningRows();

            // Label статистики
            string queryInfo = "SELECT (SELECT COUNT(*) FROM Clients) AS [Кол-во клиентов], (SELECT COUNT(*) FROM Archives) AS [Всего проживали], IsNull((SELECT (SELECT SUM(DATEDIFF(day, DateSettling, DateEviction)) FROM Archives) + (SELECT SUM(DATEDIFF(day, DateSettling, DateEviction)) FROM RegisterCards WHERE DateSettling < GETDATE())), 0) AS [Дней прожито], IsNull((SELECT SUM(DATEDIFF(day, DateSettling, DateEviction)) FROM Reservations), 3) AS [Всего забронировано], (SELECT COUNT(*)FROM Rooms WHERE RoomType_ID IN(1,2) AND NOT EXISTS(SELECT Room_ID FROM RegisterCards WHERE Room_ID = Rooms.ID)) AS [Свободно номеров], IsNull((SELECT SUM(NumBed)-(SELECT COUNT(*) FROM RegisterCards WHERE Room_ID IN(SELECT ID FROM Rooms WHERE RoomType_ID NOT IN(1,2))) FROM Rooms), 3) AS [Свободно мест], (SELECT COUNT(*) FROM RegisterCards WHERE DateSettling <= GetDate() AND DateEviction >= GetDate()) AS [Сейчас проживает];";

            using (OleDbConnection conLabel = new OleDbConnection(ConnectionString))
            {
                conLabel.Open();
                OleDbCommand cmd = new OleDbCommand(queryInfo, conLabel);
                OleDbDataReader line = cmd.ExecuteReader();

                if (line.Read())
                {
                    Label1Out.Text = line.GetInt32(0).ToString();
                    Label2Out.Text = line.GetInt32(1).ToString();
                    Label3Out.Text = line.GetInt32(2).ToString();
                    Label4Out.Text = line.GetInt32(3).ToString();
                    Label5Out.Text = line.GetInt32(4).ToString();
                    Label6Out.Text = line.GetInt32(5).ToString();
                    Label7Out.Text = line.GetInt32(6).ToString();
                }
                conLabel.Close();
            }

            if (MainDataGrid.CurrentRow == null)
            {
                AddService.Enabled = false;
                EditPayment.Enabled = false;
                ButtonMoveOut.Enabled = false;
            }
            else
            {
                AddService.Enabled = true;
                EditPayment.Enabled = true;
                ButtonMoveOut.Enabled = true;
            }
        }

        void SelectWarningRows()
        {
            for (int i = 0; i < MainDataGrid.RowCount; i++)
            {
                DateTime d1 = Convert.ToDateTime(MainDataGrid.Rows[i].Cells[5].Value.ToString());
                int timeUot = (int)(d1 - new DateTime(1970, 1, 1)).TotalSeconds;
                int unixTime = (int)(DateTime.Today - new DateTime(1970, 1, 1)).TotalSeconds;

                if (timeUot <= unixTime)
                {
                    MainDataGrid.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                }
            }
            MainDataGrid.ClearSelection();
        }

        private void AddRoomMenuItem_Click(object sender, EventArgs e)
        {
            Add.AddRoom AddRoomWindow = new Add.AddRoom();
            AddRoomWindow.Show();
        }

        private void ViewRoomsMenuItem_Click(object sender, EventArgs e)
        {
            View.ViewRooms ViewRoomsWindow = new View.ViewRooms();
            ViewRoomsWindow.Show();
        }

        private void AddClientMenuItem_Click(object sender, EventArgs e)
        {
            Add.AddClient AddClientWindow = new Add.AddClient();
            AddClientWindow.Show();
        }

        private void ViewClientsMenuItem_Click(object sender, EventArgs e)
        {
            View.ViewClients ViewClientsWindow = new View.ViewClients();
            ViewClientsWindow.Show();
        }

        private void AddResidentMenuItem_Click(object sender, EventArgs e)
        {
            Add.AddResident AddResidentWindow = new Add.AddResident();
            AddResidentWindow.Show();
        }

        private void InfoMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox AboutBoxWindow = new AboutBox();
            AboutBoxWindow.Show();
        }

        private void UpdateWindow_Click(object sender, EventArgs e)
        {
            UpdateMainInfo();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateMainInfo();
        }

        private void ButtonMoveOut_Click(object sender, EventArgs e)
        {
            int paid = 0, cost = 0;
            string queryCost = "SELECT SumPaid, FinalyCost FROM RegisterCards WHERE ID = " + MainDataGrid.CurrentRow.Cells[0].Value;
            using (OleDbConnection conLabel = new OleDbConnection(ConnectionString))
            {
                conLabel.Open();
                OleDbCommand cmd = new OleDbCommand(queryCost, conLabel);
                OleDbDataReader line = cmd.ExecuteReader();

                if (line.Read())
                {
                    paid = line.GetInt32(0);
                    cost = line.GetInt32(1);
                }
                conLabel.Close();
            }
            if (paid < cost) MessageBox.Show("Вы не можете удалить пользователя пока у него задолженость!");
            else if (MessageBox.Show("Вы действительно хотите удалить пользователя?", "Удаление пользователя", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    string IsertQuery = string.Format("INSERT INTO Archives (Client_ID, Room_ID, DateSettling, DateEviction, FinalyCost) SELECT Client_ID, Room_ID, DateSettling, GetDate(), " + MainDataGrid.CurrentRow.Cells[6].Value + " FROM RegisterCards WHERE ID = '" + MainDataGrid.CurrentRow.Cells[0].Value + "';");

                    string DeleteQuery = string.Format("DELETE FROM RegisterCards WHERE ID = '" + MainDataGrid.CurrentRow.Cells[0].Value + "';");
                    connection.Open();
                    OleDbCommand commandInsert = new OleDbCommand(IsertQuery, connection);
                    commandInsert.ExecuteNonQuery();
                    OleDbCommand commandDelete = new OleDbCommand(DeleteQuery, connection);
                    commandDelete.ExecuteNonQuery();
                    connection.Close();
                }

                MainDataGrid.Rows.RemoveAt(MainDataGrid.SelectedRows[0].Index);
            }
        }

        private void UpdateMainWindow_Tick(object sender, EventArgs e)
        {
            UpdateMainInfo();
        }

        private void MainDataGrid_Sorted(object sender, EventArgs e)
        {
            SelectWarningRows();
        }

        private void AddService_Click(object sender, EventArgs e)
        {
            if(MainDataGrid.SelectedRows != null)
            {
                Add.AddAccounts AddAccounts = new Add.AddAccounts(Convert.ToInt32(MainDataGrid.CurrentRow.Cells[0].Value));
                AddAccounts.Show();
            }
            else MessageBox.Show("Не выбран клиент проживающий в отеле.", "Ошибочное действие", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void MainDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainDataGrid.SelectedRows != null)
            {
                View.ViewAccounts ViewAccounts = new View.ViewAccounts(Convert.ToInt32(MainDataGrid.CurrentRow.Cells[0].Value));
                ViewAccounts.Show();
            }
            else MessageBox.Show("Не выбран клиент проживающий в отеле.", "Ошибочное действие", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void ViewReservationsMenuItem_Click(object sender, EventArgs e)
        {
            View.ViewReservations ViewReservationsWindow = new View.ViewReservations();
            ViewReservationsWindow.Show();
        }

        private void AddReservationsMenuItem_Click(object sender, EventArgs e)
        {
            Add.AddReservations AddReservationsWindow = new Add.AddReservations();
            AddReservationsWindow.Show();
        }

        private void AddResidentBronMenuItem_Click(object sender, EventArgs e)
        {
            Add.AddResidentBron AddResWind = new Add.AddResidentBron();
            AddResWind.Show();
        }

        private void ViewManagersMenuItem_Click(object sender, EventArgs e)
        {
            View.ViewManagers ViewMWin = new View.ViewManagers();
            ViewMWin.Show();
        }

        private void EditPayment_Click(object sender, EventArgs e)
        {
            if (MainDataGrid.SelectedRows != null)
            {
                Edit.EditPaidInfo PaidInfoWin = new Edit.EditPaidInfo(Convert.ToInt32(MainDataGrid.CurrentRow.Cells[0].Value));
                PaidInfoWin.Show();
            }
            else MessageBox.Show("Не выбран клиент проживающий в отеле.", "Ошибочное действие", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
