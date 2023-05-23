using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace BeaconApp
{
    internal class AlertDetectEntry
    {
        public string rule_name { get; set; }
        public string device_mac { get; set; }
        public string mapfloor { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public DateTime date { get; set; }

        public AlertDetectEntry(string rule_name, string device_mac, string mapfloor, int x, int y, DateTime date)
        {
            this.rule_name = rule_name;
            this.device_mac = device_mac;
            this.mapfloor = mapfloor;
            this.x = x;
            this.y = y;
            this.date = date;
        }

        public static List<AlertDetectEntry> getList(MySqlDataReader data)
        {
            List<AlertDetectEntry> list = new List<AlertDetectEntry>();
            while (data.Read())
            {
                string rule_name = data["rule_name"].ToString();
                string device_mac = data["device_mac"].ToString();
                string mapfloor = data["mapfloor"].ToString();
                int x = int.Parse(data["x"].ToString());
                int y = int.Parse(data["y"].ToString());
                DateTime date = DateTime.Parse(data["date"].ToString());
                AlertDetectEntry entry = new AlertDetectEntry(rule_name, device_mac, mapfloor, x, y, date);
                list.Add(entry);
            }
            return list;
        }
    }
}
