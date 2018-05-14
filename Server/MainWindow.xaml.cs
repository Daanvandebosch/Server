using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;
using Server.getDB;
using Server.Models;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string myConnectionString = string.Format("datasource ={0}; port=3306;username= {1};password= {2};database={3}", "10.11.51.246", "root", "bobeke", "mydb");
        Data sql;
        private DispatcherTimer tCheckConnectionDatabase = new DispatcherTimer();
        private string selectedAdd = "";
        private DispatcherTimer tRefreshData = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            if (CheckConnectionDatabase())
            {
                UpdateLists();
            }
            tCheckConnectionDatabase.Interval = TimeSpan.FromMilliseconds(15000);
            tCheckConnectionDatabase.Tick += tCheckConnectionDatabase_Tick;
            tCheckConnectionDatabase.IsEnabled = true;
        }

        private void tCheckConnectionDatabase_Tick(object sender, EventArgs e)
        {
            if (CheckConnectionDatabase())
            {
                UpdateLists();
                updateRightList();
            }
        }

        /// <summary>
        /// Setup voor database connectie en mainpage
        /// </summary>
        private bool CheckConnectionDatabase()
        {
            try
            {
                sql = new Data(myConnectionString);
                sql.ConnectionTest();
                Brush b = new SolidColorBrush(Colors.Green);
                status.Fill = b;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Brush b = new SolidColorBrush(Colors.Red);
                status.Fill = b;
                return false;
            }
        }

        /// <summary>
        /// Update alle listboxen
        /// </summary>
        private void UpdateLists()
        {
            ListInstallaties.Items.Clear();
            ListInstallaties.Items.Add(
                "InstallatieID".PadRight(15) +
                "ContainerID".PadRight(15) +
                "DeviceID".PadRight(15) +
                "Van".PadRight(10) +
                "Tot".PadRight(10) +
                "EventID".PadRight(10) +
                "Omschrijving".PadRight(15) +
                "VerantwoordelijkeID");
            List<Installatie> installaties = InstallatieDB.GetInstallaties(myConnectionString);
            foreach (Installatie installatie in installaties)
            {
                ListInstallaties.Items.Add(
                    installatie.InstallatieID.ToString().PadRight(15) +
                    installatie.ContainerID.ToString().PadRight(15) +
                    installatie.DeviceID.ToString().PadRight(15) +
                    installatie.Van.ToString("dd/MM/yyyy").PadRight(10) +
                    installatie.Tot.ToString("dd/MM/yyyy").PadRight(10) +
                    installatie.EventID.ToString().PadRight(10) +
                    installatie.Omschrijving.PadRight(15) +
                    installatie.VerantwoordelijkeID.ToString());
            }
        }
        private void updateRightList()
        {
            ListData.Items.Clear();

            switch (selectedAdd)
            {
                case "Container":
                    ListData.Items.Add(
                        "ContainerID".PadRight(12) +
                        "Plaats".PadRight(10) +
                        "Van".PadRight(20) +
                        "Tot");
                    List<Container> containerList = ContainerDB.GetContainers(myConnectionString);
                    foreach (Container container in containerList)
                    {
                        ListData.Items.Add(
                            container.ContainerID.ToString().PadRight(12) +
                            container.Plaats.PadRight(10) +
                            container.Van.ToString().PadRight(20) +
                            container.Tot);
                    }
                    break;
                case "Device":
                    ListData.Items.Add(
                        "DeviceID".PadRight(9) +
                        "Van".PadRight(20) +
                        "Tot");
                    List <Device> deviceList = DeviceDB.GetDevice(myConnectionString);
                    foreach (Device device in deviceList)
                    {
                        ListData.Items.Add(
                            device.DeviceID.ToString().PadRight(9) +
                            device.Van.ToString().PadRight(20) +
                            device.Tot);
                    }
                    break;
                case "Event":
                    ListData.Items.Add(
                        "ContactpersoonID".PadRight(17) +
                        "Naam".PadRight(10) +
                        "Locatie".PadRight(10) +
                        "ContactpersoonID".PadRight(5) +
                        "VerantwoordelijkeID");
                    List<Events> eventsList = EventsDB.GetEvents(myConnectionString);
                    foreach (Events events in eventsList)
                    {
                        ListData.Items.Add(
                            events.ContactpersoonID.ToString().PadRight(17) +
                            events.Naam.PadRight(10) +
                            events.Locatie.PadRight(10) +
                            events.ContactpersoonID.ToString().PadRight(5) +
                            events.VerantwoordelijkeID);
                    }
                    break;
                case "Persoon":
                    ListData.Items.Add(
                        "PersoonID".PadRight(10) +
                        "Functie".PadRight(10) +
                        "Voornaam".PadRight(10) +
                        "Achternaam".PadRight(15) +
                        "GSM");
                    List<Persoon> persoonList = PersoonDB.GetPeople(myConnectionString);
                    foreach (Persoon persoon in persoonList)
                    {
                        ListData.Items.Add(
                            persoon.PersoonID.ToString().PadRight(10) +
                            persoon.Functie.PadRight(10) +
                            persoon.Voornaam.PadRight(10) +
                            persoon.Achternaam.PadRight(15) +
                            persoon.GSM);
                    }
                    break;
            }
        }

        private void ComboAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboAdd.SelectedValue.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Container":
                    selectedAdd = "Container";
                    updateRightList();
                    break;
                case "System.Windows.Controls.ComboBoxItem: Device":
                    selectedAdd = "Device";
                    updateRightList();
                    break;
                case "System.Windows.Controls.ComboBoxItem: Event":
                    selectedAdd = "Event";
                    updateRightList();
                    break;
                case "System.Windows.Controls.ComboBoxItem: Persoon":
                    selectedAdd = "Persoon";
                    updateRightList();
                    break;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedAdd)
            {
                case "Device":
                    NewDevice d = new NewDevice(myConnectionString);
                    d.Show();
                    break;
                case "Container":
                    NewContainer c = new NewContainer(myConnectionString);
                    c.Show();
                    break;
                case "Persoon":
                    NewPersoon p = new NewPersoon(myConnectionString);
                    p.Show();
                    break;
                case "Event":
                    NewEvent ev = new NewEvent(myConnectionString);
                    ev.Show();
                    break;
            }
        }

        private void BtnAddInstallatie_Click(object sender, RoutedEventArgs e)
        {
            NewInstallatie i = new NewInstallatie(myConnectionString);
            i.Show();
        }

        private void BtnDeleteInstallatie_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM ";
            switch (selectedAdd)
            {
                case "Container":
                    query += "tblcontainer " +
                        "WHERE ContainerID = "
                        ;
                    break;
                case "Device":
                    query += "tbldevice";
                    break;
                case "Event":
                    query += "tblevents";
                    break;
                case "Persoon":
                    query += "tblpersoon";
                    break;
            }
        }
    }
}
