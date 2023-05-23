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
    public partial class Tracking : Form
    {
        private MySqlConnection connect;
        private string conn;
        System.Windows.Forms.Timer timer;

        public Tracking(string conn)
        {
            InitializeComponent();

            this.conn = conn;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;

            refreshImages();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = (2 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void refreshImages()
        {
            //make the brush
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            //get the beacon points
            List<BeaconPoint> beaconlist = null;
            startConnect();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM beacon_location ORDER BY floor DESC", connect);
            MySqlDataReader data1 = cmd1.ExecuteReader();
            beaconlist = BeaconPoint.getList(data1);
            connect.Close();


            //get latest beacon positions
            //gets the table of max date which is latest, and filters it down to wherre it equals that date for that group
            //SELECT device_tracked_location.* FROM device_tracked_location, ( SELECT device_mac, MAX(DATE) AS DATE FROM device_tracked_location GROUP BY device_mac ) AS devices WHERE device_tracked_location.device_mac = devices.device_mac AND device_tracked_location.date = devices.date
            List<DevicePoint> devicelist = null;
            startConnect();
            //MySqlCommand cmd2 = new MySqlCommand("SELECT device_tracked_location.* FROM device_tracked_location, ( SELECT device_mac, MAX(DATE) AS DATE FROM device_tracked_location GROUP BY device_mac ) AS devices WHERE device_tracked_location.device_mac = devices.device_mac AND device_tracked_location.date = devices.date", connect);
            //SELECT device_mac, MAX(DATE) AS date FROM device_tracked_location WHERE date >= DATE_ADD(now(), INTERVAL -5 MINUTE)GROUP BY device_mac
            //gets the most recent entries of devices cacluated fro the past 5 minutes
            MySqlCommand cmd2 = new MySqlCommand("SELECT device_tracked_location.* FROM device_tracked_location, ( SELECT device_mac, MAX(DATE) AS date FROM device_tracked_location WHERE date >= DATE_ADD(now(), INTERVAL -1 MINUTE)GROUP BY device_mac) AS devices WHERE device_tracked_location.device_mac = devices.device_mac AND device_tracked_location.date = devices.date", connect);
            MySqlDataReader data2 = cmd2.ExecuteReader();
            devicelist = DevicePoint.getList(data2);
            connect.Close();


            //Draw the maps
            flowLayoutPanel1.Controls.Clear();
            startConnect();
            MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM map_image ORDER BY mapfloor ASC", connect);
            MySqlDataReader data3 = cmd3.ExecuteReader();
            while (data3.Read())
            {
                String mapfloor = data3["mapfloor"].ToString();
                byte[] byteBLOBData = (byte[])data3["mapimage"];

                Panel panel = new Panel();
                //set panel with height of flowlayoutpanel
                panel.Height = flowLayoutPanel1.Height - 50; //max height to the height of the flowlayout
                panel.AutoSize = true; //will autosize the width

                //get and edit the image
                Image img = Maps.byteArrayToImage(byteBLOBData);
                for (int i = beaconlist.Count - 1; i >= 0; i--)
                {
                    if (beaconlist[i].floor == mapfloor)
                    {
                        int xpos = beaconlist[i].x;
                        int ypos = beaconlist[i].y;

                        if (xpos < 0)
                            xpos = 0;
                        else if (xpos > img.Width)
                            xpos = img.Width-20;
                        if (ypos < 0)
                            ypos = 0;
                        else if (ypos > img.Height)
                            ypos = img.Height-20;



                        using (Graphics g = Graphics.FromImage(img))
                            g.FillEllipse(redBrush, beaconlist[i].x, beaconlist[i].y, 20, 20);

                        beaconlist.RemoveAt(i);
                    }
                }
                for (int i = devicelist.Count - 1; i >= 0; i--)
                {
                    if (devicelist[i].floor == mapfloor)
                    {
                        int xpos = devicelist[i].x;
                        int ypos = devicelist[i].y;

                        if (xpos < 0)
                            xpos = 0;
                        else if (xpos > img.Width)
                            xpos = img.Width;
                        if (ypos < 0)
                            ypos = 0;
                        else if (ypos > img.Height)
                            ypos = img.Width;


                        using (Graphics g = Graphics.FromImage(img))
                            g.FillEllipse(blueBrush, devicelist[i].x, devicelist[i].y, 20, 20);

                        devicelist.RemoveAt(i);
                    }
                }




                //make picturebox with the image blob
                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = (int)(img.Width * 0.75);
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

        private void timer_Tick(object sender, EventArgs e)
        {
            //refresh here...
            refreshImages();
        }

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();

            //might need to sove the random disconnect from checking too often
        }

        private void Tracking_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }

}
