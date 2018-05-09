using MySql.Data.MySqlClient;
using Server.getDB;
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

            string ContainerID = getContainerID();
            string DeviceID = getDeviceID();
            string USdateVan = DateTime.Parse(DatePickerVan.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string USdateTot = DateTime.Parse(DatePickerTot.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string EventID = getEventID();
            string Omschrijving = TextBoxOmschrijving.Text;
            string VerantwoordelijkeID = getVerantwoordelijkeID();

            query += " VALUES ('"
                + ContainerID + "', '"
                + DeviceID + "', '"
                + USdateVan + "', '"
                + USdateTot + "', '"
                + EventID + "', '"
                + Omschrijving + "', '"
                + VerantwoordelijkeID + "')";

            Data d = new Data(connectionstring);
            d.DataInsert(query);

            this.Close();
        }

        private string getVerantwoordelijkeID()
        {
            string selected = ComboAddVerantwoordelijkeID.SelectedValue.ToString();
            string[] array = selected.Split(' ');
            return array[0];
        }

        private string getEventID()
        {
            string selected = ComboAddEventID.SelectedValue.ToString();
            string[] array = selected.Split(' ');
            return array[0];
        }

        private string getDeviceID()
        {
            string selected = ComboAddDeviceID.SelectedValue.ToString();
            string[] array = selected.Split(' ');
            return array[0];
        }

        private string getContainerID()
        {
            string selected = ComboAddContainerID.SelectedValue.ToString();
            string[] array = selected.Split(' ');
            return array[0];
        }

        private void LoadItemsCombobox()
        {
            // Load ContainerIDs //
            List<Container> containerList = ContainerDB.GetContainers(connectionstring);
            foreach (Container container in containerList)
            {
                ComboAddContainerID.Items.Add(
                    container.ContainerID.ToString().PadRight(2) +
                    container.Plaats);
            }

            // Load DeviceIDs //
            List<Device> deviceList = DeviceDB.GetDevice(connectionstring);
            foreach (Device device in deviceList)
            {
                ComboAddDeviceID.Items.Add(
                    device.DeviceID.ToString().PadRight(2) +
                    device.Van +
                    device.Tot);
            }

            // Load EventIDs //
            List<Events> eventsList = EventsDB.GetEvents(connectionstring);
            foreach (Events events in eventsList)
            {
                ComboAddEventID.Items.Add(
                    events.EventID.ToString().PadRight(2) +
                    events.Naam.PadRight(10) +
                    events.Locatie);
            }

            // Load VerantwoorkelijkeIDs //
            List<Persoon> persoonList = PersoonDB.GetPeople(connectionstring);
            foreach (Persoon persoon in persoonList)
            {
                ComboAddVerantwoordelijkeID.Items.Add(
                    persoon.PersoonID.ToString().PadRight(2) +
                    persoon.Voornaam.PadRight(10) +
                    persoon.Achternaam);
            }
        }
    }
}
