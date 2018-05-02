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
        private string myConnectionString = string.Format("datasource ={0}; port=3306;username= {1};password= {2};database={3}", "10.11.51.22", "root", "bobeke", "mydb");
        Data sql;
        private DispatcherTimer tCheckConnectionDatabase = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            CheckConnectionDatabase();
            tCheckConnectionDatabase.Interval = TimeSpan.FromMilliseconds(5000);
            tCheckConnectionDatabase.Tick += tCheckConnectionDatabase_Tick;
            tCheckConnectionDatabase.IsEnabled = true;
            UpdateLists();
        }

        private void tCheckConnectionDatabase_Tick(object sender, EventArgs e)
        {
            CheckConnectionDatabase();
        }

        /// <summary>
        /// Setup voor database connectie en mainpage
        /// </summary>
        private void CheckConnectionDatabase()
        {
            try
            {
                sql = new Data(myConnectionString);
                sql.ConnectionTest();
                Brush b = new SolidColorBrush(Colors.Green);
                status.Fill = b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Brush b = new SolidColorBrush(Colors.Red);
                status.Fill = b;
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
    }
}
