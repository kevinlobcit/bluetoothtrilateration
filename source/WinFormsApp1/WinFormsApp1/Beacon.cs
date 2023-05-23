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
    public partial class Beacon : Form
    {
        private MySqlConnection connect;
        private string conn;

        public Beacon(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            refreshTable();
        }

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }

        private void refreshTable()
        {
            List<BeaconPoint> list = null;
            //start connection
            startConnect();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM beacon_location ORDER BY floor ASC", connect);
            MySqlDataReader data = cmd.ExecuteReader();
            list = BeaconPoint.getList(data);

            if (list != null)
            {
                dataGridView1.DataSource = list;
            }
            connect.Close();
        }

        //use the map label to open a window with the map to allow the user to click and automatically enter coordinates
        private void buttonChooseFromMap_Click(object sender, EventArgs e)
        {
            //get floor label
            string floorlabel = textBoxFloorLabel.Text;
            if (floorlabel == string.Empty)
            {
                MessageBox.Show("Enter a valid Floor Label representing a map.", "Error");
            }
            else
            {
                startConnect();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM map_image WHERE mapfloor = " + floorlabel, connect);
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    //get the map image and send it to the next form to allow user to select x y position
                    data.Read();
                    String mapfloor = data["mapfloor"].ToString();
                    byte[] byteBLOBData = (byte[])data["mapimage"];
                    Image image = Maps.byteArrayToImage(byteBLOBData);


                    BeaconAddFromMap beaconAddFromMap = new BeaconAddFromMap(mapfloor, image);
                    var chooseFromMapResult = beaconAddFromMap.ShowDialog();
                    if (chooseFromMapResult == DialogResult.OK)
                    {
                        textBoxXPos.Text = beaconAddFromMap.x.ToString();
                        textBoxYPos.Text = beaconAddFromMap.y.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid map label.", "Error");
                }
                connect.Close();
            }
        }

        //find ideas for mac address of beacons
        private void buttonChooseBeacon_Click(object sender, EventArgs e)
        {
            BeaconIdeas beaconIdeas = new BeaconIdeas(conn);
            var chooseFromBeaconIdeas = beaconIdeas.ShowDialog();
            if (chooseFromBeaconIdeas == DialogResult.OK)
            {
                textBoxBeaconMac.Text = beaconIdeas.beaconmac;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //check if all fields filled
            if (textBoxBeaconMac.Text != string.Empty &&
                textBoxFloorLabel.Text != string.Empty &&
                textBoxXPos.Text != string.Empty &&
                textBoxYPos.Text != string.Empty)
            {
                bool successful = false;
                try
                {
                    //prepare and send the query
                    startConnect();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO beacon_location(beacon_mac, floor, x, y)values('" + textBoxBeaconMac.Text + "','" + textBoxFloorLabel.Text + "'," + textBoxXPos.Text + "," + textBoxYPos.Text + ")", connect);
                    //execute teh insert and close the connection
                    cmd.ExecuteNonQuery();
                    successful = true;
                }
                catch (MySqlException a)
                {
                    MessageBox.Show("MySQL error, duplicate beacon MAC address already exists.", "Error");
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
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM beacon_location WHERE beacon_mac = '" + textBoxDelete.Text + "'", connect);
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void buttonDisplayBeaconMap_Click(object sender, EventArgs e)
        {
            BeaconMaps beaconMaps = new BeaconMaps(conn);
            beaconMaps.Show();
        }

        private void buttonMaps_Click(object sender, EventArgs e)
        {
            Maps map = new Maps(conn);
            map.Show();
        }

        //button opens a map based on entered maplabel
        //clicking on the map will send the x and y coordinates according to the actual picture into the window
        //clicking the other button opens a list of unassigned beacons that have sent notifications but have not been added to the system

    }
}
