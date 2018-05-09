using MySql.Data.MySqlClient;
using Server.getDB;
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
            List<Persoon> persoonList = PersoonDB.GetPeople(connectionstring);
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
    }
}