using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }
        /// <summary>
        /// Setup voor database connectie en mainpage
        /// </summary>
        private void Setup()
        {
            
            try
            {
                sql = new Data();
                sql.ConnectionTest();
                Brush b = new SolidColorBrush(Colors.Green);
                status.Fill = b;
            }
            catch
            {
                Brush b = new SolidColorBrush(Colors.Red);
                status.Fill = b;
            }
        }
    }
}
