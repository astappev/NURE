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
    public partial class AddRoom : Form
    {
        private int type;

        public AddRoom()
        {
            InitializeComponent();

            string query = "SELECT ID, Name FROM RoomTypes;";
            DataSet RoomTypeDS = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
            {
                
                OleDbDataAdapter RoomTypeAdapter = new OleDbDataAdapter(query, connection);
                OleDbCommandBuilder RoomTypeBuilder = new OleDbCommandBuilder(RoomTypeAdapter);
                RoomTypeAdapter.Fill(RoomTypeDS, "Cards");
            }

            FormType.DataSource = RoomTypeDS.Tables[0];
            FormType.DisplayMember = "Name";
            FormType.ValueMember = "ID";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (FormType.SelectedItem != null && FormName.Text != String.Empty && FormFloor.Text != String.Empty && FormCost.Text != String.Empty && FormNum.Text != String.Empty)
            {
                this.type = Convert.ToInt32(FormType.SelectedValue);
                String query = "INSERT INTO Rooms (RoomType_ID,Name,Floor,Phone,Cost,NumBed) VALUES('" + type + "','" + FormName.Text + "','" + FormFloor.Text + "','" + FormPhone.Text + "','" + FormCost.Text + "','" + FormNum.Text + "')";

                using (OleDbConnection con = new OleDbConnection(MainForm.ConnectionString))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Информация о номере добавлена!", "Успех", MessageBoxButtons.OK);
                    this.Hide();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!\r\nВсе поля должны быть заполнены.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int currentValue = Convert.ToInt32(FormType.SelectedValue);
            if (currentValue == 1 || currentValue == 2)
            {
                FormCostLabel.Text = "Стоимость за номер:";
            }
            else
            {
                FormCostLabel.Text = "Стоимость за место:";
            }
        }

        private void FormFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void FormPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
