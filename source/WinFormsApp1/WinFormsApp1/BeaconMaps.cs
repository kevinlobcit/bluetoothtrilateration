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
    public partial class BeaconMaps : Form
    {
        private MySqlConnection connect;
        private string conn;

        public BeaconMaps(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;

            refreshImages();
        }

        private void refreshImages()
        {
            //make the brush
            SolidBrush redBrush = new SolidBrush(Color.Red);

            //get the beacon points
            List<BeaconPoint> beaconlist = null;
            startConnect();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM beacon_location ORDER BY floor DESC", connect);
            MySqlDataReader data1 = cmd1.ExecuteReader();
            beaconlist = BeaconPoint.getList(data1);
            connect.Close();

            //Draw the maps
            flowLayoutPanel1.Controls.Clear();
            startConnect();
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM map_image ORDER BY mapfloor ASC", connect);
            MySqlDataReader data2 = cmd2.ExecuteReader();
            while (data2.Read())
            {
                String mapfloor = data2["mapfloor"].ToString();
                byte[] byteBLOBData = (byte[])data2["mapimage"];

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

                        if(xpos < 0)
                            xpos = 0;
                        else if(xpos > img.Width)
                            xpos = img.Width;
                        if (ypos < 0)
                            ypos = 0;
                        else if (ypos > img.Height)
                            ypos = img.Width;


                        using (Graphics g = Graphics.FromImage(img))
                            g.FillEllipse(redBrush, beaconlist[i].x, beaconlist[i].y, 20, 20);

                        beaconlist.RemoveAt(i);
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

        //private void getBeaconPoints()
        //{
        //    List<BeaconPoint> list = null;
        //    //start connection
        //    startConnect();
        //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM beacon_location ORDER BY floor DESC", connect);
        //    MySqlDataReader data = cmd.ExecuteReader();
        //    list = BeaconPoint.getList(data);
        //
        //    connect.Close();
        //}

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }
    }
}
