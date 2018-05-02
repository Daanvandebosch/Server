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


namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data sql;
        string command;
        private DispatcherTimer tCheckConnectionDatabase = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            CheckConnectionDatabase();
            tCheckConnectionDatabase.Interval = TimeSpan.FromMilliseconds(5000);
            tCheckConnectionDatabase.Tick += tCheckConnectionDatabase_Tick;
            tCheckConnectionDatabase.IsEnabled = true;
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
                sql = new Data();
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
            Data d = new Data();
            d.DataSelect("select * from tblinstallatie");
            MySqlDataReader reader = cmd
        }
    }
}
