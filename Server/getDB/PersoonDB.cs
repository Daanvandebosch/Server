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
    public class PersoonDB
    {
        public static List<Persoon> GetPeople(string connectionstring)
        {
            List<Persoon> personen = new List<Persoon>();

            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select * from tblpersoon";
            cmd.CommandText = command;

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Persoon persoon = new Persoon();
                    persoon.PersoonID = Convert.ToInt32(reader[0]);
                    persoon.GSM = Convert.ToString(reader[1]);
                    persoon.Functie = Convert.ToString(reader[2]);
                    persoon.Voornaam = Convert.ToString(reader[3]);
                    persoon.Achternaam = Convert.ToString(reader[4]);
                    personen.Add(persoon);
                }
            }
            catch
            {
                MessageBox.Show("Error while fetching Persoon data.");
            }

            return personen;
        }
    }
}
