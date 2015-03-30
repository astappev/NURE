using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Data.OleDb;
using Crypt = BCrypt.Net.BCrypt;

namespace Hotel_Booking_System
{
    public partial class Login : Form
    {
        static public bool status = true;
        static public int role = 3;
        static public string username = "Oleg";//String.Empty;
        
        public Login()
        {
            InitializeComponent();
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginForm_buttonLogin_Click(sender, e);
            }
        }

        private void LoginForm_buttonLogin_Click(object sender, EventArgs e)
        {
            if(LoginForm_login.Text == String.Empty)
            {
                MessageBox.Show("Поле «Логин», не заполнено!\r\nДля продолжения вы должны ввести логин.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (LoginForm_password.Text == String.Empty)
            {
                MessageBox.Show("Поле «Пароль», не заполнено!\r\nДля продолжения вы должны ввести пароль.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string queryString = string.Format("SELECT ID,Role_ID,Login,Password  FROM Users WHERE Login='" + LoginForm_login.Text + "'");

                using (OleDbConnection connection = new OleDbConnection(MainForm.ConnectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader line = command.ExecuteReader();

                    if(line.Read())
                    {
                        int id = line.GetInt32(0);
                        string password_hash = line.GetString(3).ToString();

                        if (Crypt.Verify(LoginForm_password.Text, password_hash))
                        {
                            if (line.GetInt32(1) == 2 || line.GetInt32(1) == 3)
                            {
                                role = line.GetInt32(1);
                                username = line.GetString(2).ToString();

                                string UpdateQuery = string.Format("UPDATE Users SET DateLastLogin = GetDate() WHERE ID = '" + id + "';");
                                OleDbCommand commandUpdate = new OleDbCommand(UpdateQuery, connection);
                                commandUpdate.ExecuteNonQuery();

                                LoginClose();
                            }
                            else
                            {
                                MessageBox.Show("У вас нет права доступа к базе данных!\r\nПолучить доступ может пользователь с правами менеджера или администратора.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            LoginForm_password.Text = String.Empty;
                            MessageBox.Show("Неверный пароль!\r\nПопробуйте еще раз.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данный логин не существует!\r\nВ БД не найдено соответсвующих данных.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    line.Close();
                    return;
                }
                MessageBox.Show("Ошибка подключения к БД.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoginClose()
        {
            status = true;
            Close();
        }
    }
}
