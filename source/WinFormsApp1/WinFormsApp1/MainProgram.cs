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
using BeaconApp;
using MySql.Data.MySqlClient; // required for MySQL connection after addition of MySQL References

namespace WinFormsApp1
{
    public partial class MainProgram : Form
    {
        private MySqlConnection connect;
        private string conn;
        //private Maps form3;
        //private ConnectionSQL ConnectionSQL;
        public MainProgram(string conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        //closing the main beacon progam window after logging in closes the program
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //connect.Close(); //close the connection
            Application.Exit(); //exit the program
        }

        private void buttonAddMaps_Click(object sender, EventArgs e)
        {
            //open window to add maps
            Maps form3 = new Maps(conn);
            form3.Show();
        }

        private void buttonBeacons_Click(object sender, EventArgs e)
        {
            Beacon form8 = new Beacon(conn);
            form8.Show();
        }

        private void buttonDevices_Click(object sender, EventArgs e)
        {
            Devices devices = new Devices(conn);
            devices.Show();
        }

        private void buttonTracking_Click(object sender, EventArgs e)
        {
            Tracking tracking = new Tracking(conn);
            tracking.Show();
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            Logs logs = new Logs(conn);
            logs.Show();
        }

        private void buttonAlerts_Click(object sender, EventArgs e)
        {
            Alerts alerts = new Alerts(conn);
            alerts.Show();
        }
    }
}
