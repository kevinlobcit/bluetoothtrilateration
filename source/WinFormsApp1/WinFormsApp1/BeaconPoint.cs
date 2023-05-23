using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace BeaconApp
{
    //object to contain the coordinates and details of a saved beacon location
    internal class BeaconPoint
    {
        public string beacon_mac { get; set; }
        public string floor { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public BeaconPoint()
        {
            beacon_mac = string.Empty;
            this.floor = "-1";
            x = 0; y = 0;
        }

        public BeaconPoint(string beacon_mac)
        {
            this.beacon_mac = beacon_mac;
            this.floor = "-1";
            x = 0; y = 0;
        }

        public BeaconPoint(string beacon_mac, string floor, int x, int y)
        {
            this.floor = floor;
            this.beacon_mac = beacon_mac;
            this.x = x; this.y = y;
        }

        public static List<BeaconPoint> getList(MySqlDataReader data)
        {
            List<BeaconPoint> list = new List<BeaconPoint>();
            while (data.Read())
            {
                String beacon_mac = data["beacon_mac"].ToString();
                String floor = data["floor"].ToString();
                int x = int.Parse(data["x"].ToString());
                int y = int.Parse(data["y"].ToString());

                BeaconPoint point = new BeaconPoint(beacon_mac, floor, x ,y);
                list.Add(point);
            }
            return list;
        }
    }
}
