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
    public partial class MapAdd : Form
    {
        private MySqlConnection connect;
        private string conn;
        private bool imageSelected;
        private bool successful;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public MapAdd(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            imageSelected = false;
            successful = false;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Title = "Browse Images";
            openFileDialog1.Filter = "Files | *.jpg; *.jpeg;";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFilename.Text = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                imageSelected = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //verify that textboxmaplabel isnt empty
            if (string.IsNullOrEmpty(textBoxMapLabel.Text) || imageSelected == false)
            {
                MessageBox.Show("Map label empty, or image not selected");
            }
            else
            {
                try
                {
                    //open the image and read into byte array
                    byte[] imgdata;
                    FileStream fs = new FileStream(textBoxFilename.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imgdata = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    //prepare and send the query
                    startConnect();
                    //MySqlCommand cmd = new MySqlCommand("INSERT INTO map_image(mapfloor, mapimage)values('" + textBoxMapLabel.Text + "',?Image)", connect);
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO map_image(mapfloor, mapimage, scaling)values('" + textBoxMapLabel.Text + "',?Image," + numericUpDown1.Value.ToString() + ")", connect);
                    MySqlParameter parImage = new MySqlParameter();
                    parImage.ParameterName = "?Image";
                    parImage.MySqlDbType = MySqlDbType.MediumBlob; //16,777,215 bytes limit
                    parImage.Size = 1670000;
                    parImage.Value = imgdata; //takes the image byte array

                    //replace ?Image with the byte array parameter
                    cmd.Parameters.Add(parImage);
                    //execute teh insert and close the connection
                    cmd.ExecuteNonQuery();
                    successful = true;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("MySQL error, duplicate map label already exists.", "Error");
                }
                finally
                {
                    //close this window and update Maps.cs
                    connect.Close();
                    if (successful)
                    {
                        this.Close();
                    }
                }
            }

        }

        private void startConnect()
        {
            connect = new MySqlConnection(conn);
            connect.Open();
        }
    }
}
