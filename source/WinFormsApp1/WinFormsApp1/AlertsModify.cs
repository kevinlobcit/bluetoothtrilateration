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
    public partial class AlertsModify : Form
    {
        private MySqlConnection connect;
        private string conn;

        public AlertsModify(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            refreshTable();
        }

        //use the map label to open a window with the map to allow the user to click and automatically enter coordinates
        private void buttonSelectArea_Click(object sender, EventArgs e)
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


                    AlertsModifyFromMap alertsModifyFromMap = new AlertsModifyFromMap(mapfloor, image);
                    var chooseFromMapResult = alertsModifyFromMap.ShowDialog();
                    if (chooseFromMapResult == DialogResult.OK)
                    {
                        numericUpDownXStart.Text = alertsModifyFromMap.xStart.ToString();
                        numericUpDownYStart.Text = alertsModifyFromMap.yStart.ToString();
                        numericUpDownXEnd.Text = alertsModifyFromMap.xEnd.ToString();
                        numericUpDownYEnd.Text = alertsModifyFromMap.yEnd.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid map label.", "Error");
                }
                connect.Close();
            }
        }


        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //check if all fields filled
            if (textBoxRuleDelete.Text != string.Empty)
            {
                bool successful = false;
                try
                {
                    //prepare and send the query
                    startConnect();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM alert_rules WHERE rule_name = '" + textBoxRuleDelete.Text + "'", connect);
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
                    }
                }

            }
            else
            {
                MessageBox.Show("Missing fields.", "Error");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //check if all fields filled
            if (textBoxRuleName.Text != string.Empty &&
                textBoxDeviceMac.Text != string.Empty &&
                textBoxFloorLabel.Text != string.Empty &&
                numericUpDownXStart.Text != string.Empty &&
                numericUpDownYStart.Text != string.Empty &&
                numericUpDownXEnd.Text != string.Empty &&
                numericUpDownYEnd.Text != string.Empty)
            {


                bool successful = false;
                try
                {
                    //prepare and send the query
                    startConnect();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO alert_rules(rule_name,device_mac,mapfloor,x_start,y_start,x_end,y_end)values('" + textBoxRuleName.Text + "','" + textBoxDeviceMac.Text + "','" + textBoxFloorLabel.Text + "'," + numericUpDownXStart.Text + "," + numericUpDownYStart.Text + "," + numericUpDownXEnd.Text + "," + numericUpDownYEnd.Text + ")", connect);
                    //execute teh insert and close the connection
                    cmd.ExecuteNonQuery();
                    successful = true;
                }
                catch (MySqlException a)
                {
                    MessageBox.Show("MySQL error, duplicate rule name already exists.", "Error");
                    //MessageBox.Show(a.Message, "Error");
                }
                finally
                {
                    connect.Close();
                    if (successful)
                    {
                        MessageBox.Show("Successfully Added rule");
                        refreshTable();
                    }
                }

            }
            else
            {
                MessageBox.Show("Missing fields.", "Error");
            }
        }

        private void refreshTable()
        {
            List<AlertRuleEntry> list = null;
            //start connection
            startConnect();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM alert_rules ORDER BY mapfloor ASC", connect);
            MySqlDataReader data = cmd.ExecuteReader();
            list = AlertRuleEntry.getList(data);

            if (list != null)
            {
                dataGridView1.DataSource = list;
            }
            connect.Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshTable();
        }
    }
}
