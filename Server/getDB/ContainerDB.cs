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
    class ContainerDB
    {
        public static List<Container> GetPeople(string connectionstring)
        {
            List<Container> containers = new List<Container>();

            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select * from tblcontainer";
            cmd.CommandText = command;

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Container container = new Container();
                    container.ContainerID = Convert.ToInt32(reader[0]);
                    container.Plaats = Convert.ToString(reader[1]);
                    container.Van = Convert.ToDateTime(reader[2]);
                    container.Tot = Convert.ToDateTime(reader[3]);
                    containers.Add(container);
                }
            }
            catch
            {
                MessageBox.Show("Error while fetching Event data.");
            }

            return containers;
        }
    }
}
