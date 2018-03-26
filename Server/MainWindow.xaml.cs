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
        Data sql = new Data();
        string command;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewDevice_Click(object sender, RoutedEventArgs e)
        {
            command = "INSERT INTO tblDevice (Van) VALUES ('" + DateTime.Today.ToString() + "')";
            sql.dataInsert(command);
            Refresh();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            //TblDevices

        }
    }
}
