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
using Server.Models;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string myConnectionString = string.Format("datasource ={0}; port=3306;username= {1};password= {2};database={3}", "10.11.51.152", "root", "bobeke", "mydb");
        Data sql;
        private DispatcherTimer tCheckConnectionDatabase = new DispatcherTimer();
        private string selectedAdd = "";

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
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command;

            List<Installatie> listI = new List<Installatie>();

            command = "select * from tblinstallatie";
            cmd.CommandText = command;
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Installatie i = new Installatie()
                    {
                        InstallatieID = Convert.ToInt32(reader[0]),
                        ContainerID = Convert.ToInt32(reader[1]),
                        DeviceID = Convert.ToInt32(reader[2]),
                        Van = Convert.ToDateTime(reader[3]),
                        Tot = Convert.ToDateTime(reader[4]),
                        EventID = Convert.ToInt32(reader[5]),
                        Omschrijving = Convert.ToString(reader[6]),
                        VerantwoordelijkeID = Convert.ToInt32(reader[7])
                    };
                    listI.Add(i);
                    ListInstallaties.Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "";
            List<dynamic> lijst = new List<dynamic>();

            switch (ComboAdd.SelectedValue.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Device":
                    selectedAdd = "Device";
                    command = "select * from tbldevice";
                    cmd.CommandText = command;
                    try
                    {
                        conn.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        Device d = new Device();
                        while (reader.Read())
                        {
                            d.DeviceID = Convert.ToInt32(reader[0]);
                            d.Van = Convert.ToDateTime(reader[1]);
                            d.Tot = Convert.ToDateTime(reader[2]);
                        }
                        lijst.Add(d);
                    }
                    catch
                    {
                        MessageBox.Show("Error while fetching data.");
                    }
                    break;
                case "System.Windows.Controls.ComboBoxItem: Container":
                    selectedAdd = "Container";
                    command = "select * from tblcontainer";
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
                            c.Van = Convert.ToDateTime(reader[2]);
                            c.Tot = Convert.ToDateTime(reader[3]);
                            lijst.Add(c);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error while fetching data.");
                    }
                    break;
                case "System.Windows.Controls.ComboBoxItem: Event":
                    selectedAdd = "Event";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Persoon":
                    selectedAdd = "Persoon";
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
                    break;
                case "Event":
                    break;
            }
        }
    }
}
