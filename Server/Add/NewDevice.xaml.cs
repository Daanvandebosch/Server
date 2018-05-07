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
    /// Interaction logic for NewDevice.xaml
    /// </summary>
    public partial class NewDevice : Window
    {
        private string connectionstring;

        public NewDevice(string connectionstring)
        {
            this.connectionstring = connectionstring;
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO tbldevice (Van, Tot)";
            //query += " VALUES (@Van, @Tot)";
            string USdateVan = DateTime.Parse(DatePickerVan.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string USdateTot = DateTime.Parse(DatePickerTot.Text).ToString("yyyy-MM-dd HH:mm:ss");

            query += " VALUES ('" + USdateVan + "', '" + USdateTot + "')";

            Data d = new Data(connectionstring);
            d.DataInsert(query);

            this.Close();
        }
    }
}
