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
    public partial class ViewManagers : Form
    {
        OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString);

        public ViewManagers()
        {
            InitializeComponent();
            ViewManage_Load();
        }

        private void AddButtons_Click(object sender, EventArgs e)
        {
            Add.AddManager AddManagerWindow = new Add.AddManager();
            AddManagerWindow.Show();
        }

        private void ViewManage_Load()
        {
            String query = "SELECT ID, Login AS Логин, DateReg AS [Дата регистрации], DateLastLogin AS [Дата последней ауторизации] FROM Users WHERE Role_ID = 2";

            if (!string.IsNullOrEmpty(LoginBox.Text) && !LoginBox.Text.Equals("Логин", StringComparison.OrdinalIgnoreCase))
            {
                query += " AND Login LIKE '%" + LoginBox.Text + "%'";
            }

            connection.Open();
            DataSet roomDS = new DataSet();
            OleDbDataAdapter roomAdapter = new OleDbDataAdapter(query, connection);
            OleDbCommandBuilder roomBuilder = new OleDbCommandBuilder(roomAdapter);
            roomAdapter.Fill(roomDS, "Users");
            connection.Close();

            ManagerGridView.ReadOnly = true;
            ManagerGridView.AllowUserToAddRows = false;
            ManagerGridView.AllowUserToDeleteRows = false;
            ManagerGridView.AllowUserToOrderColumns = true;
            ManagerGridView.RowHeadersVisible = false;
            ManagerGridView.DataSource = roomDS;
            ManagerGridView.DataMember = "Users";
            ManagerGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ManagerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //.DisplayedCells;
            ManagerGridView.Columns["ID"].Visible = false;
        }

        private void DeleteButtons_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите пользователя?", "Удаление пользователя", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                connection.Open();
                string DeleteQuery = string.Format("DELETE FROM Users WHERE ID = '" + ManagerGridView.CurrentRow.Cells[0].Value + "';");
                OleDbCommand commandUpdate = new OleDbCommand(DeleteQuery, connection);
                commandUpdate.ExecuteNonQuery();
                connection.Close();

                ManagerGridView.Rows.RemoveAt(ManagerGridView.SelectedRows[0].Index);
            }
        }

        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if(LoginBox.Text.Equals("Логин", StringComparison.OrdinalIgnoreCase))
            {
                LoginBox.Text = string.Empty;
            }  
        }

        private void LoginBox_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(LoginBox.Text))
            {
                LoginBox.Text = "Логин";
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            ViewManage_Load();
        }
    }
}
