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
    public partial class TemplateAccounts : Form
    {
        bool idEditing = false;

        OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString);
        OleDbDataAdapter templateAdapter;
        OleDbCommandBuilder templateBuilder;
        DataSet templateDS;
        DataTable templateTable;    

        public TemplateAccounts()
        {
            InitializeComponent();

            String query = "SELECT ID, Name AS [Наименование], Cost AS [Стоимость] FROM TemplateAccounts";
            connection.Open();
            templateDS = new DataSet();
            templateAdapter = new OleDbDataAdapter(query, connection);
            templateBuilder = new OleDbCommandBuilder(templateAdapter);
            templateAdapter.Fill(templateDS, "Templates");
            templateTable = templateDS.Tables["Templates"];
            connection.Close();

            RoomGridView.DataSource = templateDS;
            RoomGridView.DataMember = "Templates";
            RoomGridView.Columns["ID"].Visible = false;
        }

        private void EditButtons_Click(object sender, EventArgs e)
        {
            if (!idEditing)
            {
                RoomGridView.ReadOnly = false;
                SaveButtons.Enabled = true;
                EditButtons.Text = "Удалить строку";
                idEditing = true;
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление строки", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RoomGridView.Rows.RemoveAt(RoomGridView.SelectedRows[0].Index);
                }
            }
        }

        private void SaveButtons_Click(object sender, EventArgs e)
        {
            templateAdapter.Update(templateDS, "Templates");
            RoomGridView.ReadOnly = true;
            SaveButtons.Enabled = false;
            EditButtons.Text = "Редактировать";
            idEditing = false;
        }

        private void ViewRooms_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (idEditing)
            {
                if (MessageBox.Show("Вы хотите выйти не сохранив изменения?", "Подтвердите выход", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        public string ReturnName()
        {
            return (RoomGridView.CurrentRow.Cells[1].Value.ToString().Trim());
        }

        public string ReturnCost()
        {
            return (RoomGridView.CurrentRow.Cells[2].Value.ToString().Trim());
        }

        private void RoomGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }  
    }
}
