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


    public partial class AlertsModifyFromMap : Form
    {
        private string maplabel;
        private Image image;
        private PictureBox pictureBox;

        public int xStart { get; set; }
        public int yStart { get; set; }
        public int xEnd { get; set; }
        public int yEnd { get; set; }

        public AlertsModifyFromMap(string maplabel, Image image)
        {
            InitializeComponent();

            this.maplabel = maplabel;
            this.image = image;
            xStart = 0;
            yStart = 0;
            xEnd = 0;
            yEnd = 0;

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
            pictureBox.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);

            //add to panel
            panel.Controls.Add(pictureBox);
            //add to flowlayoutpanel
            flowLayoutPanel1.Controls.Add(panel);

            //set default 0 0 0 0 coordinates
            textBoxXStart.Text = "0";
            textBoxYStart.Text = "0";
            textBoxXEnd.Text = "0";
            textBoxYEnd.Text = "0";
        }


        //listener on picturebox to get starting coordinates
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            double xsizeratio = (double)pictureBox.Width / (double)image.Width;
            double ysizeratio = (double)pictureBox.Height / (double)image.Height;

            xStart = (int)(Math.Floor((double)e.X / xsizeratio));
            yStart = (int)(Math.Floor((double)e.Y / ysizeratio));
            textBoxXStart.Text = xStart.ToString();
            textBoxYStart.Text = yStart.ToString();
        }

        //listener on picturebox to get ending coordinates
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            double xsizeratio = (double)pictureBox.Width / (double)image.Width;
            double ysizeratio = (double)pictureBox.Height / (double)image.Height;

            xEnd = (int)(Math.Floor((double)e.X / xsizeratio));
            yEnd = (int)(Math.Floor((double)e.Y / ysizeratio));
            textBoxXEnd.Text = xEnd.ToString();
            textBoxYEnd.Text = yEnd.ToString();
        }

        
        //Send results back to AlertsModify
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxXStart.Text != string.Empty && textBoxYStart.Text != string.Empty && textBoxXEnd.Text != string.Empty && textBoxYEnd.Text != string.Empty)
            {
                //validate coordinate order
                //small to big


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
