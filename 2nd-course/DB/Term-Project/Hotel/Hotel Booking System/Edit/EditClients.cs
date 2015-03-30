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
    public partial class EditClients : Form
    {
        int id;

        public EditClients()
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

        internal void LoadClients(String NomerMarshID)
        {
            this.id = Convert.ToInt32(NomerMarshID);
            String query = "SELECT * FROM Clients WHERE ID = " + NomerMarshID;

            DataSet ZupynkiDS = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand(query, connection);
                OleDbDataReader line = cmd.ExecuteReader();

                if (line.Read())
                {
                    FormFirstName.Text = line.GetString(2).ToString();
                    FormLastName.Text = line.GetString(3).ToString();
                    FormPatronymic.Text = line.GetString(4).ToString();
                    FormGender.SelectedValue = line.GetInt32(5).ToString();
                    FormBirthday.Value = line.GetDateTime(6);
                    FormDocType.SelectedValue = line.GetInt32(7).ToString();
                    FormDocNumber.Text = line.GetString(8).ToString();
                    FormAdress.Text = line.GetString(9).ToString();
                    FormPhone.Text = line.GetString(10).ToString();
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (FormFirstName.Text != String.Empty && FormLastName.Text != String.Empty && FormPatronymic.Text != String.Empty && FormDocNumber.Text != String.Empty && FormAdress.Text != String.Empty && FormPhone.Text != String.Empty)
            {
                String query = "UPDATE Clients SET FirstName = '" + FormFirstName.Text + "', LastName = '" + FormLastName.Text + "', Patronymic = '" + FormPatronymic.Text + "', DocType_ID = " + FormDocType.SelectedValue + ", DocNumber = '" + FormDocNumber.Text + "', Adress = '" + FormAdress.Text + "', Phone = '" + FormPhone.Text + "' WHERE ID = " + this.id;

                using (OleDbConnection con = new OleDbConnection(MainForm.ConnectionString))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Информация о клиенте обновлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!\r\nВсе поля должны быть заполнены.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormDocNumber.Text = String.Empty;
        }
    }
}
