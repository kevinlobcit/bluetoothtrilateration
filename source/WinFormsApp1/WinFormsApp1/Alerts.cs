using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeaconApp
{
    public partial class Alerts : Form
    {
        private MySqlConnection connect;
        private string conn;

        public Alerts(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridViewAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            refreshTable();
        }




        private void refreshTable()
        {
            refreshTableRules();
            refreshTableDetect();
        }

        private void refreshTableRules()
        {

            List<AlertRuleEntry> list1 = null;
            //start connection

            startConnect();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM alert_rules ORDER BY mapfloor ASC", connect);
            MySqlDataReader data1 = cmd1.ExecuteReader();
            list1 = AlertRuleEntry.getList(data1);

            if (list1 != null)
            {
                dataGridViewRules.DataSource = list1;
            }
            connect.Close();
        }
        private void refreshTableDetect()
        {
            //MessageBox.Show("testing");
            List<AlertDetectEntry> list2 = null;
            //start connection
            startConnect();
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM alert_detections ORDER BY date DESC", connect);
            MySqlDataReader data2 = cmd2.ExecuteReader();
            list2 = AlertDetectEntry.getList(data2);

            if (list2 != null)
            {
                dataGridViewAlerts.DataSource = list2;
            }
            connect.Close();
            dataGridViewAlerts.Columns[5].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
        }

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            AlertsModify alertsModify = new AlertsModify(conn);
            alertsModify.ShowDialog();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshTable();
        }
    }
}
