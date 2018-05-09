using MySql.Data.MySqlClient;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Server.getDB
{
    public class DeviceDB
    {
        public static List<Device> GetDevice(string connectionstring)
        {
            List<Device> devices = new List<Device>();

            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select * from tbldevice";
            cmd.CommandText = command;

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Device Device = new Device();
                    Device.DeviceID = Convert.ToInt32(reader[0]);
                    Device.Van = Convert.ToDateTime(reader[1]);
                    Device.Tot = Convert.ToDateTime(reader[2]);
                    devices.Add(Device);
                }
            }
            catch { MessageBox.Show("Error while fetching Device data."); }

            return devices;
        }
    }
}
