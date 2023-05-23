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
using WinFormsApp1;

namespace BeaconApp
{
    public partial class BeaconIdeas : Form
    {
        private MySqlConnection connect;
        private string conn;
        public string beaconmac;

        public BeaconIdeas(string conn)
        {
            InitializeComponent();
            this.conn = conn;

            refreshTable();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
                    textBoxBeaconMac.Text = dataGridView1.CurrentCell.Value.ToString();
            }
        }

        private void refreshTable()
        {
            List<string> list = null;
            //start connection
            startConnect();
            //selects the beacon_macs that are registered to the tracking database but not yet added to the beacon_location table
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT beacon_mac FROM tracking WHERE beacon_mac NOT IN (SELECT beacon_mac FROM beacon_location)", connect);
            MySqlDataReader data = cmd.ExecuteReader();
            list = getList(data);

            if (list != null)
            {
                var result = list.Select(s => new { beacon_mac = s }).ToList();
                dataGridView1.DataSource = result;
            }
            connect.Close();
        }

        public static List<string> getList(MySqlDataReader data)
        {
            List<String> list = new List<string>();
            while (data.Read())
            {
                String devicename = data["beacon_mac"].ToString();
                list.Add(devicename);
            }
            return list;
        }
        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxBeaconMac.Text != string.Empty)
            {
                beaconmac = textBoxBeaconMac.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Select a beacon_mac to add.", "Error");
            }
        }
    }
}
