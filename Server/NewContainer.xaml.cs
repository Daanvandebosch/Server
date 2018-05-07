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
using System.Windows.Shapes;

namespace Server
{
    /// <summary>
    /// Interaction logic for NewContainer.xaml
    /// </summary>
    public partial class NewContainer : Window
    {
        private string connectionstring;

        public NewContainer(string connectionstring)
        {
            this.connectionstring = connectionstring;
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO tblcontainer (Plaats, Van, Tot)";
            //query += " VALUES (@Plaats, @Van, @Tot)";
            query += " VALUES (" + TextBoxPlaats.Text + ", " + DatePickerVan.Text + ", " + DatePickerTot.Text + ")";

            Data d = new Data(connectionstring);
            d.DataInsert(query);
        }
    }
}
