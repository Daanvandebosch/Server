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
    public class EventDB
    {
        public static List<Events> GetPeople(string connectionstring)
        {
            List<Events> eventen = new List<Events>();

            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select * from tblevents";
            cmd.CommandText = command;

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Events events = new Events();
                    events.EventID = Convert.ToInt32(reader[0]);
                    events.Naam = Convert.ToString(reader[1]);
                    events.Locatie = Convert.ToString(reader[2]);
                    events.ContactpersoonID = Convert.ToInt32(reader[3]);
                    events.VerantwoordelijkeID = Convert.ToInt32(reader[4]);
                    eventen.Add(events);
                }
            }
            catch
            {
                MessageBox.Show("Error while fetching Event data.");
            }

            return eventen;
        }
    }
}
