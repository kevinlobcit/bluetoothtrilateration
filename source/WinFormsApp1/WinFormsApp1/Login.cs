using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; // required for MySQL connection after addition of MySQL References

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        private string conn;
        private MySqlConnection connect;

        public Login()
        {
            InitializeComponent();
        }

        //return true if successful, false if fails
        private bool db_connection(string conn)
        {
            try
            {
                connect = new MySqlConnection(conn);
                connect.Open();
                return true; //connection successful
            }
            catch (MySqlException e) //connection unsuccessful
            {
                switch (e.Number)
                {
                    case 0:// Invalid sql host
                        MessageBox.Show("Ip address not valid MySql Target.", "Error");
                        break;
                    case 4060:// Invalid db
                        break;
                    case 18456://login failed
                        MessageBox.Show("Invalid Login.", "Error");
                        break;
                    default:
                        MessageBox.Show("MySQL Error", "Error");
                        break;
                }
                return false;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string ip = textBoxIP.Text;
            string user = textBoxLogin.Text;
            string pass = textBoxPassword.Text;
            string conn = "server=" + ip + ";database=tracking_data;uid=" + user + ";pwd=" + pass + ";";
            if (ip == "" || user == "" || pass == "")
            {
                MessageBox.Show("Empty Fields Detected! Please fill up all fields.", "Error");
                return;
            }
            if (db_connection(conn))
            {
                MainProgram form2 = new MainProgram(conn);
                //MainProgram form2 = new MainProgram(connManager);
                form2.Show();
                this.Hide();//hide this window (form1 login) and proceed to main beacon program window
                connect.Close();
            }
        }
    }
}