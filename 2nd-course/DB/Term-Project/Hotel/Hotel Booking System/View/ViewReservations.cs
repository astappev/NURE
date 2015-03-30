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

namespace Hotel_Booking_System.View
{
    public partial class ViewReservations : Form
    {
        public ViewReservations()
        {
            InitializeComponent();
            UpdateGridClients();
        }

        void UpdateGridClients()
        {
            String query = "SELECT Reservations.ID AS ID, FirstName AS [Фамилия], LastName AS [Имя], Patronymic AS [Отчество], RoomTypes.Name AS [Тип номера], DateSettling AS [Дата заезда], DateEviction AS [Дата виезда] FROM Reservations, Clients, RoomTypes WHERE Reservations.Client_ID = Clients.ID AND Reservations.RoomType_ID = RoomTypes.ID";

            if (!string.IsNullOrEmpty(FirstNameBox.Text) && !FirstNameBox.Text.Equals("Фамилия", StringComparison.OrdinalIgnoreCase))
            {
                query += " AND FirstName LIKE '%" + FirstNameBox.Text + "%'";
            }

            if (!string.IsNullOrEmpty(LastNameBox.Text) && !LastNameBox.Text.Equals("Имя", StringComparison.OrdinalIgnoreCase))
            {
                query += " AND LastName LIKE '%" + LastNameBox.Text + "%'";
            }

            DataSet clientDS = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
            {
                
                OleDbDataAdapter clientAdapter = new OleDbDataAdapter(query, connection);
                OleDbCommandBuilder clientBuilder = new OleDbCommandBuilder(clientAdapter);
                clientAdapter.Fill(clientDS, "Clients");
            }

            ReservationsGridView.DataSource = clientDS;
            ReservationsGridView.DataMember = "Clients";
            ReservationsGridView.Columns["ID"].Visible = false;
        }

        private void ViewReservations_Load(object sender, EventArgs e)
        {
            UpdateGridClients();
        }

        private void DeleteButtons_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить бронь?", "Удаление строки", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
                {
                    connection.Open();
                    string DeleteQuery = string.Format("DELETE FROM Reservations WHERE ID = '" + ReservationsGridView.CurrentRow.Cells[0].Value + "';");
                    OleDbCommand commandUpdate = new OleDbCommand(DeleteQuery, connection);
                    commandUpdate.ExecuteNonQuery();
                    connection.Close();
                }

                ReservationsGridView.Rows.RemoveAt(ReservationsGridView.SelectedRows[0].Index);
            }
        }

        private void FirstNameBox_Enter(object sender, EventArgs e)
        {
            if(FirstNameBox.Text.Equals("Фамилия", StringComparison.OrdinalIgnoreCase))
            {
                FirstNameBox.Text = string.Empty;
            }  
        }

        private void FirstNameBox_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(FirstNameBox.Text))
            {
                FirstNameBox.Text = "Фамилия";
            }
        }

        private void LastNameBox_Enter(object sender, EventArgs e)
        {
            if(LastNameBox.Text.Equals("Имя", StringComparison.OrdinalIgnoreCase))
            {
                LastNameBox.Text = string.Empty;
            } 
        }

        private void LastNameBox_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(LastNameBox.Text))
            {
                LastNameBox.Text = "Имя";
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            UpdateGridClients();
        }

        private void ClientGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit.EditClients MarshrutZupynka = new Edit.EditClients();
            MarshrutZupynka.LoadClients(ReservationsGridView.CurrentRow.Cells[0].Value.ToString());
            MarshrutZupynka.Show();
        }

        private void ViewReservations_Activated(object sender, EventArgs e)
        {
            UpdateGridClients();
        }
    }
}
