using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crypt = BCrypt.Net.BCrypt;
using System.Data.OleDb;

namespace Hotel_Booking_System.Add
{
    public partial class AddManager : Form
    {
        public AddManager()
        {
            InitializeComponent();
        }

        private void AddManagerButton_Click(object sender, EventArgs e)
        {
            if (FormLoginBox.Text != String.Empty && FormPasswordBox.Text != String.Empty)
            {
                String query = "INSERT INTO Users (Role_ID, Login, Password) VALUES(2,'" + FormLoginBox.Text + "','" + Crypt.HashPassword(FormPasswordBox.Text) + "')";

                using (OleDbConnection con = new OleDbConnection(MainForm.ConnectionString))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Менеджер добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    return;
                }
                MessageBox.Show("Ошибка подключения к БД.", "Ошибка добавления.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!\r\nВсе поля должны быть заполнены.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
