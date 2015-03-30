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
    public partial class ViewRooms : Form
    {
        bool idEditing = false;
        bool isFree = false;

        OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString);
        OleDbDataAdapter roomAdapter;
        OleDbCommandBuilder roomBuilder;
        DataSet roomDS;
        DataTable roomTable;    

        public ViewRooms()
        {
            InitializeComponent();

            string sql = "SELECT ID, Name FROM RoomTypes";
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "RoomTypes");
            connection.Close();

            RoomTypeBox.DataSource = ds.Tables[0];
            RoomTypeBox.ValueMember = "ID";
            RoomTypeBox.DisplayMember = "Name";
            RoomTypeBox.SelectedIndexChanged += new System.EventHandler(RoomTypeBox_SelectedIndexChanged);

            LoadRoomsGrid();
        }

        private void RoomTypeBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadRoomsGrid();
        }

        private void LoadRoomsGrid()
        {
            int type = (RoomTypeBox.SelectedItem != null)?(int)RoomTypeBox.SelectedValue:0;
            String query;
            if(type == 1 || type == 2)
            {
                if (isFree) query = "SELECT ID, Name AS Название, Floor AS Этаж, Cost AS Стоимость, Phone AS Телефон, NumBed AS \"Кол-во мест\" FROM Rooms WHERE RoomType_ID = " + type + " AND NOT EXISTS(SELECT ID FROM RegisterCards WHERE Room_ID = Rooms.ID AND GetDate() BETWEEN DateSettling AND DateEviction);";
                else query = "SELECT ID, Name AS Название, Floor AS Этаж, Cost AS Стоимость, Phone AS Телефон, NumBed AS \"Кол-во мест\" FROM Rooms WHERE RoomType_ID = " + type + ";";
            }
            else
            {
                if (isFree) query = "SELECT ID, Name AS Название, Floor AS Этаж, Cost AS Стоимость, Phone AS Телефон, NumBed AS [Кол-во мест], NumBed - isNull((LiveRoom), 0) AS [Мест свободно] FROM Rooms LEFT JOIN (SELECT Room_ID, COUNT(*) AS LiveRoom FROM RegisterCards WHERE GetDate() BETWEEN DateSettling AND DateEviction GROUP BY Room_ID) AS FreeTable ON Rooms.ID = FreeTable.Room_ID WHERE NumBed > FreeTable.LiveRoom OR FreeTable.LiveRoom IS NULL AND RoomType_ID = " + type + ";";
                else query = "SELECT ID, Name AS Название, Floor AS Этаж, Cost AS Стоимость, Phone AS Телефон, NumBed AS \"Кол-во мест\" FROM Rooms WHERE RoomType_ID = " + type + ";";
            }

            connection.Open();
            roomDS = new DataSet();
            roomAdapter = new OleDbDataAdapter(query, connection);
            roomBuilder = new OleDbCommandBuilder(roomAdapter);
            roomAdapter.Fill(roomDS, "Rooms");
            roomTable = roomDS.Tables["Rooms"];
            connection.Close();

            RoomGridView.DataSource = roomDS;
            RoomGridView.DataMember = "Rooms";
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
                RoomTypeBox.Enabled = false;
                isFreeBox.Enabled = false;
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить номер?", "Удаление строки", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RoomGridView.Rows.RemoveAt(RoomGridView.SelectedRows[0].Index);
                }
            }
        }

        private void SaveButtons_Click(object sender, EventArgs e)
        {
            roomAdapter.Update(roomDS, "Rooms");
            RoomGridView.ReadOnly = true;
            SaveButtons.Enabled = false;
            EditButtons.Text = "Редактировать";
            idEditing = false;
            RoomTypeBox.Enabled = true;
            isFreeBox.Enabled = true;
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

        private void isFreeBox_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (isFreeBox.Checked) isFree = true;
            else isFree = false;

            LoadRoomsGrid();
        }
    }
}
