using MySql.Data.MySqlClient;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Server
{
    /// <summary>
    /// Interaction logic for NewEvent.xaml
    /// </summary>
    public partial class NewEvent : Window
    {
        private string connectionstring;

        public NewEvent(string connectionstring)
        {
            this.connectionstring = connectionstring;
            InitializeComponent();

            LoadItemsCombobox();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO tblevents (Naam, Locatie, ContactpersoonID, VerantwoordelijkID)";
            string ContactpersoonID = getContactpersoonID();
            string VerantwoordelijkeID = getVerantwoordelijkeID();

            query += " VALUES ('"
                + TextBoxNaam.Text + "', '"
                + TextBoxLocatie.Text + "', '"
                + ContactpersoonID + "', '"
                + VerantwoordelijkeID + "')";

            Data d = new Data(connectionstring);
            d.DataInsert(query);

            this.Close();
        }

        private void LoadItemsCombobox()
        {
            List<Persoon> persoonList = GetPeople(connectionstring);
            foreach (Persoon p in persoonList)
            {
                ComboAddContactpersoonID.Items.Add(p.PersoonID.ToString().PadRight(2) + p.Voornaam.PadRight(10) + p.Achternaam);
                ComboAddVerantwoordelijkeID.Items.Add(p.PersoonID.ToString().PadRight(2) + p.Voornaam.PadRight(10) + p.Achternaam);
            }
        }

        private string getContactpersoonID()
        {
            string selected = ComboAddContactpersoonID.SelectedValue.ToString();
            string[] array = selected.Split(' ');
            return array[0];
        }
        private string getVerantwoordelijkeID()
        {
            string selected = ComboAddVerantwoordelijkeID.SelectedValue.ToString();
            string[] array = selected.Split(' ');
            return array[0];
        }

        public static List<Persoon> GetPeople(string connectionstring)
        {
            List<Persoon> personen = new List<Persoon>();
            Persoon persoon;

            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select PersoonID,Voornaam,Achternaam from tblpersoon";
            cmd.CommandText = command;

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    persoon = new Persoon();
                    persoon.PersoonID = Convert.ToInt32(reader[0]);
                    persoon.Voornaam = Convert.ToString(reader[1]);
                    persoon.Achternaam = Convert.ToString(reader[2]);
                    personen.Add(persoon);
                }
            }
            catch
            {
                MessageBox.Show("Error while fetching data.");
            }

            return personen;
        } 
    }
}

//List<dynamic> list = new List<dynamic>();

//command = "select Voornaam from tblpersoon";
//            cmd.CommandText = command;

//            try
//            {
//                conn.Open();
//                MySqlDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    Persoon p = new Persoon();
//p.Voornaam = Convert.ToString(reader[0]);
//                    p.Achternaam = Convert.ToString(reader[1]);
//                    list.Add(p);
//                }
//            }
//            catch
//            {
//                MessageBox.Show("Error while fetching data.");
//            }

//            foreach (Persoon p in list)
//            {

//                ComboAddContactpersoonID.Items.Add(p.Voornaam.PadRight(10) + p.Achternaam);
//            }
