using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace BeaconApp
{
    //object to contain a saved location a device has been detected at
    internal class DevicePoint
    {
        public string device_mac { get; set; }
        public string floor { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public DateTime date { get; set; }

        public DevicePoint()
        {
            device_mac = string.Empty;
            this.floor = "-1";
            x = 0; y = 0;
        }

        public DevicePoint(string beacon_mac)
        {
            this.device_mac = beacon_mac;
            this.floor = "-1";
            x = 0; y = 0;
        }

        public DevicePoint(string beacon_mac,  int x, int y,string floor, DateTime date)
        {
            this.floor = floor;
            this.device_mac = beacon_mac;
            this.x = x; this.y = y;
            this.date = date;
        }

        public static List<DevicePoint> getList(MySqlDataReader data)
        {
            List<DevicePoint> list = new List<DevicePoint>();
            while (data.Read())
            {
                String beacon_mac = data["device_mac"].ToString();
                
                int x = int.Parse(data["x"].ToString());
                int y = int.Parse(data["y"].ToString());
                String floor = data["floor"].ToString();
                DateTime datetime = DateTime.Parse(data["date"].ToString());
                DevicePoint point = new DevicePoint(beacon_mac,x,y,floor,datetime);
                list.Add(point);
            }
            return list;
        }
    }
}
