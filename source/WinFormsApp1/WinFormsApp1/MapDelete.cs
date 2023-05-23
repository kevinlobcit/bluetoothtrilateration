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
    public partial class MapDelete : Form
    {
        private MySqlConnection connect;
        private string conn;
        private bool successful;

        public MapDelete(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            successful = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //verify that textboxmaplabel isnt empty
            if (string.IsNullOrEmpty(textBoxMapLabel.Text))
            {
                MessageBox.Show("Map to delete not selected.");
            }
            else
            {
                try
                {
                    //prepare and send the query
                    startConnect();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM map_image WHERE mapfloor = '" + textBoxMapLabel.Text + "'", connect);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        successful = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid delete target.", "Error");
                    }
                    
                }
                catch (MySqlException)
                {
                    MessageBox.Show("MySQL error", "Error");
                }
                finally
                {
                    //close this window and update Maps.cs
                    connect.Close();
                    if (successful)
                    {
                        this.DialogResult = DialogResult.OK;
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
