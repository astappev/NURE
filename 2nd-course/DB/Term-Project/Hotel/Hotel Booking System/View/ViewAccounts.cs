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
    public partial class ViewAccounts : Form
    {
        public ViewAccounts(int RegCard)
        {
            InitializeComponent();

            string queryAccounts = "SELECT ID, Name AS [Название], Cost AS [Стоимость] FROM Accounts WHERE Card_ID = " + RegCard;

            DataSet AccountsDS = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
            {
                OleDbDataAdapter AccountsAdapter = new OleDbDataAdapter(queryAccounts, connection);
                OleDbCommandBuilder AccountsBuilder = new OleDbCommandBuilder(AccountsAdapter);
                AccountsAdapter.Fill(AccountsDS, "Accounts");
            }

            AccountsGridView.DataSource = AccountsDS;
            AccountsGridView.DataMember = "Accounts";
            AccountsGridView.Columns["ID"].Visible = false;

            String query = "SELECT (FirstName + ' ' + LEFT(LastName, 1) + '.' + LEFT(Patronymic, 1) + '.') AS Fio, (Name + ' (' + CAST(Rooms.ID AS VARCHAR(11)) + ')') AS Nomer FROM RegisterCards INNER JOIN Clients ON RegisterCards.Client_ID = Clients.ID INNER JOIN Rooms ON RegisterCards.Room_ID = Rooms.ID WHERE RegisterCards.ID = " + RegCard;

            using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand(query, connection);
                OleDbDataReader line = cmd.ExecuteReader();

                if (line.Read())
                {
                    OutNumLabel.Text = line.GetString(1).ToString();
                    OutFioLabel.Text = line.GetString(0).ToString();
                }
            }
        }
    }
}
