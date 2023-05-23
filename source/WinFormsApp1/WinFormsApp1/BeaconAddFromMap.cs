using Org.BouncyCastle.Asn1.X9;
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
    public partial class BeaconAddFromMap : Form
    {
        private string maplabel;
        private Image image;
        private PictureBox pictureBox;

        public int x { get; set; }
        public int y { get; set; }


        public BeaconAddFromMap(string maplabel, Image image)
        {
            InitializeComponent();
            this.maplabel = maplabel;
            this.image = image;
            x = 0;
            y = 0;

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;

            Panel panel = new Panel();
            //set panel with height of flowlayoutpanel
            panel.Height = flowLayoutPanel1.Height - 50; //max height to the height of the flowlayout
            panel.AutoSize = true; //will autosize the width
            //make picturebox with the image blob
            pictureBox = new PictureBox();
            pictureBox.Width = (int)(image.Width * 0.75);
            pictureBox.Height = panel.Height; //same height as panel with a little less for label
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.Yellow;
            pictureBox.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);

            //add to panel
            panel.Controls.Add(pictureBox);
            //add to flowlayoutpanel
            flowLayoutPanel1.Controls.Add(panel);

            //the actual image limit size,
            //display limits
            textBoxXLimit.Text = image.Width.ToString();
            textBoxYLimit.Text = image.Height.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            double xsizeratio = (double)pictureBox.Width / (double)image.Width;
            double ysizeratio = (double)pictureBox.Height / (double)image.Height;

            x = (int)(Math.Floor((double)e.X / xsizeratio));
            y = (int)(Math.Floor((double)e.Y / ysizeratio));
            textBoxXPos.Text = x.ToString();
            textBoxYPos.Text = y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxXPos.Text != string.Empty && textBoxYPos.Text != string.Empty)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Click on the map to choose a X,Y point.", "Error");
            }
        }
    }
}
