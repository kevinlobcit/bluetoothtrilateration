using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    //outdated object to store the basic entry detected on teh server from tracking table
    internal class BeaconEntry
    {
        public string beacon_mac { get; set; }
        public string devicename { get; set; }
        public int rssi { get; set; }
        public DateTime datetime { get; set; }
        public string floor { get; set; }

        public BeaconEntry()
        {
            this.floor = "-1";
        }

        public BeaconEntry(string beacon_mac, string devicename, int rssi, DateTime dateTime)
        {
            this.beacon_mac = beacon_mac;
            this.devicename = devicename;
            this.rssi = rssi;
            this.datetime = dateTime;
            this.floor = "-1";
        }
        public BeaconEntry(string beacon_mac, string devicename, int rssi, DateTime dateTime, string floor)
        {
            this.beacon_mac = beacon_mac;
            this.devicename = devicename;
            this.rssi = rssi;
            this.datetime = dateTime;
            this.floor = floor;
        }

        public static List<BeaconEntry> getList(MySqlDataReader data)
        {
            List<BeaconEntry> list = new List<BeaconEntry>();
            while (data.Read())
            {
                String beacon_mac = data["beacon_mac"].ToString();
                String devicename = data["device_mac"].ToString();
                int rssi = int.Parse(data["rssi"].ToString());
                DateTime datetime = DateTime.Parse(data["date"].ToString());
                //add one for floor, use other entry if not null from crossreference

                BeaconEntry entry = new BeaconEntry(beacon_mac, devicename, rssi, datetime);
                list.Add(entry);
            }
            return list;
        }
    }
}
