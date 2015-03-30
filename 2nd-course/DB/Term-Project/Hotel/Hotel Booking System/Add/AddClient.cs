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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();

            string query = "SELECT ID, Name FROM DocType;";
            DataSet DocTypeDS = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
            {

                OleDbDataAdapter DocTypeAdapter = new OleDbDataAdapter(query, connection);
                OleDbCommandBuilder DocTypeBuilder = new OleDbCommandBuilder(DocTypeAdapter);
                DocTypeAdapter.Fill(DocTypeDS, "DocTypes");
            }

            FormDocType.DataSource = DocTypeDS.Tables[0];
            FormDocType.DisplayMember = "Name";
            FormDocType.ValueMember = "ID";

            string queryClientGender = "SELECT ID, Name FROM ClientGender;";
            DataSet ClientGenderDS = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
            {

                OleDbDataAdapter ClientGenderAdapter = new OleDbDataAdapter(queryClientGender, connection);
                OleDbCommandBuilder ClientGenderBuilder = new OleDbCommandBuilder(ClientGenderAdapter);
                ClientGenderAdapter.Fill(ClientGenderDS, "ClientGenders");
            }

            FormGender.DataSource = ClientGenderDS.Tables[0];
            FormGender.DisplayMember = "Name";
            FormGender.ValueMember = "ID";
        }

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            if (FormFirstName.Text != String.Empty && FormLastName.Text != String.Empty && FormPatronymic.Text != String.Empty && FormDocNumber.Text != String.Empty && FormAdress.Text != String.Empty && FormPhone.Text != String.Empty)
            {
                String query = "INSERT INTO Clients (FirstName, LastName, Patronymic, Gender, Birthday, DocType_ID, DocNumber, Adress, Phone) VALUES('" + FormFirstName.Text + "','" + FormLastName.Text + "','" + FormPatronymic.Text + "','" + FormGender.SelectedValue + "','" + FormBirthday.Value.Date.ToString("yyyy-MM-dd") + "','" + FormDocType.SelectedValue + "','" + FormDocNumber.Text + "','" + FormAdress.Text + "','" + FormPhone.Text + "')";

                using (OleDbConnection con = new OleDbConnection(MainForm.ConnectionString))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Информация о клиенте добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FormPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
