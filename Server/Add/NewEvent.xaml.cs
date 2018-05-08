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

            query += " VALUES ('"
                + TextBoxNaam.Text + "', '"
                + TextBoxLocatie.Text + "', '"
                + ComboAddContactpersoonID.SelectedValue + "', '"
                + ComboAddVerantwoordelijkeID.SelectedValue + "')";

            Data d = new Data(connectionstring);
            d.DataInsert(query);

            this.Close();
        }

        private void LoadItemsCombobox()
        {
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "";
            List<dynamic> list = new List<dynamic>();

            command = "select Voornaam,Achternaam from tblpersoon";
            cmd.CommandText = command;

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Persoon p = new Persoon();
                    p.Voornaam = Convert.ToString(reader[0]);
                    p.Achternaam = Convert.ToString(reader[1]);
                    list.Add(p);
                }
            }
            catch
            {
                MessageBox.Show("Error while fetching data.");
            }

            foreach (Persoon p in list)
            {
                ComboAddContactpersoonID.Items.Add(p.Voornaam.PadRight(10) + p.Achternaam);
                ComboAddVerantwoordelijkeID.Items.Add(p.Voornaam.PadRight(10) + p.Achternaam);
            }
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
