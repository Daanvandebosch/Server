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
    public class InstallatieDB
    {
        public static List<Installatie> GetInstallaties(string connectionString)
        {
            List<Installatie> installaties = new List<Installatie>();

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select * from tblinstallatie";
            cmd.CommandText = command;

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Installatie installatie = new Installatie()
                    {
                        InstallatieID = Convert.ToInt32(reader[0]),
                        ContainerID = Convert.ToInt32(reader[1]),
                        DeviceID = Convert.ToInt32(reader[2]),
                        Van = Convert.ToDateTime(reader[3]),
                        Tot = Convert.ToDateTime(reader[4]),
                        EventID = Convert.ToInt32(reader[5]),
                        Omschrijving = Convert.ToString(reader[6]),
                        VerantwoordelijkeID = Convert.ToInt32(reader[7]),
                    };
                    installaties.Add(installatie);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return installaties;
        }

        
    }
}
