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
    public partial class AddAccounts : Form
    {
        int RgCard;

        public AddAccounts(int RegCard)
        {
            InitializeComponent();
            RgCard = RegCard;

            String query = "SELECT (FirstName + ' ' + LEFT(LastName, 1) + '.' + LEFT(Patronymic, 1) + '.') AS Fio, (Name + ' (' + CAST(Rooms.ID AS VARCHAR(11)) + ')') AS Nomer FROM RegisterCards INNER JOIN Clients ON RegisterCards.Client_ID = Clients.ID INNER JOIN Rooms ON RegisterCards.Room_ID = Rooms.ID WHERE RegisterCards.ID = " + RgCard;

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

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != String.Empty && CostBox.Text != String.Empty)
            {
                String query = "INSERT INTO Accounts (Card_ID,Name,Cost) VALUES('" + RgCard + "','" + NameBox.Text + "','" + CostBox.Text + "')";
                String UpdateQuary = "UPDATE RegisterCards SET FinalyCost = FinalyCost + " + CostBox.Text + " WHERE ID = " + RgCard;

                using (OleDbConnection con = new OleDbConnection(MainForm.ConnectionString))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(UpdateQuary, con);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Информация добавлена!", "Успех", MessageBoxButtons.OK);
                    this.Hide();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!\r\nВсе поля должны быть заполнены.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TemplateButton_Click(object sender, EventArgs e)
        {
            View.TemplateAccounts Template = new View.TemplateAccounts();
            Template.ShowDialog();

            if (Template.DialogResult == DialogResult.OK)
            {
                NameBox.Text = Template.ReturnName();
                CostBox.Text = Template.ReturnCost();
            }
        }

        private void CostBox_KeyPress(object sender, KeyPressEventArgs e)
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
