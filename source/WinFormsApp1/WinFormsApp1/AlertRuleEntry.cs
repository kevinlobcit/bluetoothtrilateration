using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace BeaconApp
{
    internal class AlertRuleEntry
    {
        public string rule_name { get; set; }
        public string device_mac { get; set; }
        public string floor { get; set; }
        public int xstart { get; set; }
        public int ystart { get; set; }
        public int xend { get; set; }
        public int yend { get; set; }

        public AlertRuleEntry(string rule_name,string device_mac, string floor, int xstart, int ystart, int xend, int yend)
        {
            this.rule_name = rule_name;
            this.device_mac = device_mac;
            this.floor = floor;

            this.xstart = xstart;
            this.ystart = ystart;
            this.yend = xend;
            this.xend = yend;
        }

        public static List<AlertRuleEntry> getList(MySqlDataReader data)
        {
            List<AlertRuleEntry> list = new List<AlertRuleEntry>();
            while (data.Read())
            {
                string rule_name = data["rule_name"].ToString();
                string device_mac = data["device_mac"].ToString();
                string mapfloor = data["mapfloor"].ToString();

                int xstart = int.Parse(data["x_start"].ToString());
                int ystart = int.Parse(data["y_start"].ToString());
                int xend = int.Parse(data["x_end"].ToString());
                int yend = int.Parse(data["y_end"].ToString());

                AlertRuleEntry entry = new AlertRuleEntry(rule_name,device_mac,mapfloor,xstart,ystart,xend,yend) ;
                list.Add(entry);
            }
            return list;
        }
    }
}
