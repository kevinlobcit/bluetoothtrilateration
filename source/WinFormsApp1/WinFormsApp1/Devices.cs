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
    public partial class Devices : Form
    {
        private MySqlConnection connect;
        private string conn;
        public Devices(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            refreshTable();
        }

        private void refreshTable()
        {
            List<DeviceEntry> list = null;
            //start connection
            startConnect();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM devices ORDER BY device_mac ASC", connect);
            MySqlDataReader data = cmd.ExecuteReader();
            list = DeviceEntry.getList(data);

            if (list != null)
            {
                dataGridView1.DataSource = list;
            }
            connect.Close();
        }

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //check if devicemac has value
            if (textBoxDeviceMac.Text != String.Empty)
            {
                bool successful = false;
                try
                {
                    //prepare and send the query
                    startConnect();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO devices(device_mac, reference_rssi)values('" + textBoxDeviceMac.Text + "','" + numericUpDownRSSI.Value + "')", connect);
                    //execute teh insert and close the connection
                    cmd.ExecuteNonQuery();
                    successful = true;
                }
                catch (MySqlException a)
                {
                    MessageBox.Show("MySQL error, duplicate device MAC address already exists.", "Error");
                    //MessageBox.Show(a.Message, "Error");
                }
                finally
                {
                    connect.Close();
                    if (successful)
                    {
                        MessageBox.Show("Successfully Added Beacon");
                        refreshTable();
                        //this.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Missing fields.", "Error");
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //check if all fields filled
            if (textBoxDelete.Text != string.Empty)
            {
                bool successful = false;
                try
                {
                    //prepare and send the query
                    startConnect();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM devices WHERE device_mac = '" + textBoxDelete.Text + "'", connect);
                    //execute teh insert and close the connection
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        successful = true;
                    }
                    else
                    {
                        MessageBox.Show("MySQL error, delete target doesn't exist.", "Error");
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("MySQL error", "Error");
                }
                finally
                {
                    connect.Close();
                    if (successful)
                    {
                        MessageBox.Show("Successfully Deleted");
                        refreshTable();
                        //this.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Missing fields.", "Error");
            }
        }
    }
}
