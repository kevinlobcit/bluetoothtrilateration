using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconApp
{
    //deviceentry is object for listing added devices to the server with device_mac and a reference rssi
    internal class DeviceEntry
    {
        public string device_mac { get; set; }
        public int reference_rssi { get; set; }

        public DeviceEntry(string device_mac, int ref_rssi)
        {
            this.device_mac = device_mac;
            this.reference_rssi = ref_rssi;
        }

        public static List<DeviceEntry> getList(MySqlDataReader data)
        {
            List<DeviceEntry> list = new List<DeviceEntry>();
            while (data.Read())
            {
                String dev_mac = data["device_mac"].ToString();
                int rssi = int.Parse(data["reference_rssi"].ToString());

                DeviceEntry dev = new DeviceEntry(dev_mac, rssi);
                list.Add(dev);
            }
            return list;
        }

    }
}
