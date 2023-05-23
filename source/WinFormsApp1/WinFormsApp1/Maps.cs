using BeaconApp;
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

namespace WinFormsApp1
{
    public partial class Maps : Form
    {
        private MySqlConnection connect;
        private string conn;
        public Maps(string conn)
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
            flowLayoutPanel1.Controls.Clear();

            startConnect();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM map_image ORDER BY mapfloor ASC", connect);
            MySqlDataReader data = cmd.ExecuteReader();
            //list = getList(data);
            while (data.Read())
            {
                String mapfloor = data["mapfloor"].ToString();
                byte[] byteBLOBData = (byte[])data["mapimage"];
                String scaling = data["scaling"].ToString();

                Panel panel = new Panel();
                //set panel with height of flowlayoutpanel
                panel.Height = flowLayoutPanel1.Height - 50; //max height to the height of the flowlayout
                panel.AutoSize = true; //will autosize the width
                Image img = byteArrayToImage(byteBLOBData);
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
                label.Text = "Map:" + mapfloor + ", Scaling:" + scaling;
                label.BackColor = Color.Yellow;
                //add all to panel
                panel.Controls.Add(label);
                panel.Controls.Add(pictureBox);
                //add to flowlayoutpanel
                flowLayoutPanel1.Controls.Add(panel);

                //MessageBox.Show(img.Width.ToString() + "," + img.Height.ToString() + "--" + pictureBox.Width.ToString() + "," + pictureBox.Height.ToString());
            }
            connect.Close();
        }

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }

        //takes byte array and returns image for maps
        public static Image byteArrayToImage(byte[] byteBLOBData)
        {
            MemoryStream ms = new MemoryStream(byteBLOBData);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //open window to add maps
            MapAdd form4 = new MapAdd(conn);
            form4.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshImages();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MapDelete form5 = new MapDelete(conn);
            var chooseFromMapResult = form5.ShowDialog();
            if (chooseFromMapResult == DialogResult.OK)
            {
                refreshImages();
            }
        }
    }
}
