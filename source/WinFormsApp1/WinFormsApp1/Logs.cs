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
    public partial class Logs : Form
    {
        private MySqlConnection connect;
        private string conn;

        MySqlCommand cmd;
        bool searching;

        public Logs(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            searching = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.KeyUp += dataGridView1_KeyUp;

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;



            refreshTable();
        }

        private void refreshTable()
        {
            List<DevicePoint> devicelist = null;
            startConnect();
            if (searching)
            {
                String sqlstring = "SELECT * FROM device_tracked_location WHERE device_mac='" + textBoxSearch.Text + "' ORDER BY date DESC";
                cmd = new MySqlCommand(@sqlstring, connect);
            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM device_tracked_location ORDER BY date DESC", connect);
            }

            MySqlDataReader data = cmd.ExecuteReader();
            devicelist = DevicePoint.getList(data);

            if (devicelist != null)
            {
                dataGridView1.DataSource = devicelist;
            }
            connect.Close();
            dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
        }

        private void cellEvent()
        {

        }

        private void cellchange()
        {
            int row = dataGridView1.CurrentCellAddress.Y;
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null && row != -1)
            {
                SolidBrush blueBrush = new SolidBrush(Color.Blue);

                //get the row to find the floor,x,y
                //int row = dataGridView1.CurrentCellAddress.Y;
                string flr = dataGridView1[1, row].Value.ToString();
                int x = Int32.Parse(dataGridView1[2, row].Value.ToString());
                int y = Int32.Parse(dataGridView1[3, row].Value.ToString());

                //MessageBox.Show(x.ToString() +  " " + y.ToString());


                //use floor string to get the map
                Panel panel = new Panel();
                //set panel with height of flowlayoutpanel
                panel.Height = flowLayoutPanel1.Height - 50; //max height to the height of the flowlayout
                panel.AutoSize = true; //will autosize the width

                flowLayoutPanel1.Controls.Clear();
                startConnect();
                string sqlstring2 = "SELECT * FROM map_image WHERE mapfloor='" + flr + "'"; //will get one map
                MySqlCommand cmd2 = new MySqlCommand(sqlstring2, connect);
                MySqlDataReader data2 = cmd2.ExecuteReader();
                while (data2.Read())
                {
                    String mapfloor = data2["mapfloor"].ToString();
                    byte[] byteBLOBData = (byte[])data2["mapimage"];
                    Image img = Maps.byteArrayToImage(byteBLOBData);

                    //fix the coordinates if theyre out of bounds
                    if (x < 0)
                        x = 0;
                    else if (x > img.Width)
                        x = img.Width - 20;
                    if (y < 0)
                        y = 0;
                    else if (y > img.Height)
                        y = img.Height - 20;

                    using (Graphics g = Graphics.FromImage(img))
                        g.FillEllipse(blueBrush, x, y, 20, 20);



                    //make picturebox with the image blob
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Width = (int)(img.Width * 0.5);
                    pictureBox.Height = panel.Height; //same height as panel with a little less for label
                    pictureBox.Image = img;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Location = new Point(0, 20);
                    //make label with same width as picturebox and center the text
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Width = pictureBox.Width;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Text = mapfloor;
                    label.BackColor = Color.Yellow;
                    //add all to panel
                    panel.Controls.Add(label);
                    panel.Controls.Add(pictureBox);
                    //add to flowlayoutpanel
                    flowLayoutPanel1.Controls.Add(panel);
                }
                connect.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                cellchange();
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("event");
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                cellchange();
            }
        }

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            searching = true;
            refreshTable();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            searching = false;
            refreshTable();
        }
    }
}
