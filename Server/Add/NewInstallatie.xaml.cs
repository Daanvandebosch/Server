using MySql.Data.MySqlClient;
using Server.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NewInstallatie.xaml
    /// </summary>
    public partial class NewInstallatie : Window
    {
        private string connectionstring;

        public NewInstallatie(string connectionstring)
        {
            this.connectionstring = connectionstring;
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO tblinstallatie (ContainerID, DeviceID, Van, Tot, EventID, Omschrijving, VerantwoordelijkeID)";

            string USdateVan = DateTime.Parse(DatePickerVan.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string USdateTot = DateTime.Parse(DatePickerTot.Text).ToString("yyyy-MM-dd HH:mm:ss");

            query += " VALUES ('"
                + ComboAddContainerID.SelectedValue + "', '"
                + ComboAddDeviceID.SelectedValue + "', '"
                + USdateVan + "', '"
                + USdateTot + "', '"
                + ComboAddEventID.SelectedValue + "', '"
                + TextBoxOmschrijving + "', '"
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

            /// Verantwoorkelijke ID ///
            command = "select ContainerID,Plaats from tblcontainer";
            cmd.CommandText = command;
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Container c = new Container();
                    c.ContainerID = Convert.ToInt32(reader[0]);
                    c.Plaats = Convert.ToString(reader[1]);
                    list.Add(c);
                }
            }
            catch { MessageBox.Show("Error while fetching 'ContainerID' data."); }

            foreach (Container c in list)
            {
                ComboAddContainerID.Items.Add(c.ContainerID.ToString().PadRight(2) + c.Plaats);
            }
            list.Clear();

            /// Verantwoorkelijke ID ///
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
            catch { MessageBox.Show("Error while fetching 'VerantwoordelijkeID' data."); }

            foreach (Persoon p in list)
            {
                ComboAddVerantwoordelijkeID.Items.Add(p.Voornaam.PadRight(10) + p.Achternaam);
            }
        }
    }
}
