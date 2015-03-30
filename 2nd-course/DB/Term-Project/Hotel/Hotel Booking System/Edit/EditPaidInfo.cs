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

namespace Hotel_Booking_System.Edit
{
    public partial class EditPaidInfo : Form
    {
        int RgCard;
        int cost = 0, paid = 0;

        public EditPaidInfo(int id)
        {
            RgCard = id;
            InitializeComponent();

            
            String query = "SELECT (FirstName + ' ' + LEFT(LastName, 1) + '.' + LEFT(Patronymic, 1) + '.') AS Fio, (Name + ' (' + CAST(Rooms.ID AS VARCHAR(11)) + ')') AS Nomer FROM RegisterCards INNER JOIN Clients ON RegisterCards.Client_ID = Clients.ID INNER JOIN Rooms ON RegisterCards.Room_ID = Rooms.ID WHERE RegisterCards.ID = " + RgCard;
            String queryTwo = "SELECT CostReservation, NumDaysPaid, SumPaid, FinalyCost FROM RegisterCards WHERE RegisterCards.ID = " + RgCard;

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

                cmd = new OleDbCommand(queryTwo, connection);
                line = cmd.ExecuteReader();

                if (line.Read())
                {
                    CostBronOut.Text = line.GetInt32(0).ToString();
                    DayPaidOut.Text = line.GetInt32(1).ToString();
                    PaidOut.Text = line.GetInt32(2).ToString();
                    paid = line.GetInt32(2);
                    CostOut.Text = line.GetInt32(3).ToString();
                    cost = line.GetInt32(3);
                    DolgOut.Text = (cost - paid).ToString() + " грн.";
                }
            }


        }

        private void AddButtons_Click(object sender, EventArgs e)
        {
            if(textBox.Text != String.Empty)
            {
                String UpdateQuary = "UPDATE RegisterCards SET SumPaid = SumPaid + " + textBox.Text + " WHERE ID = " + RgCard;

                using (OleDbConnection con = new OleDbConnection(MainForm.ConnectionString))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(UpdateQuary, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (paid + Convert.ToInt32(textBox.Text) >= cost) MessageBox.Show("Вы все оплатили!", "Успех", MessageBoxButtons.OK);
                    else MessageBox.Show("Оплата добавлена!", "Успех", MessageBoxButtons.OK);
                    this.Hide();
                    return;
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
