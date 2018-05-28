using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
            try
            {
                if (TextBoxPlaats.Text == "")
                {
                    throw new Exception("Plaats nog niet ingegeven");
                }
                string query = "INSERT INTO tblcontainer (Plaats, Van, Tot)";

                string USdateVan = DateTime.Parse(DatePickerVan.Text).ToString("yyyy-MM-dd HH:mm:ss");
                string USdateTot = DateTime.Parse(DatePickerTot.Text).ToString("yyyy-MM-dd HH:mm:ss");

                query += " VALUES ('" +
                    TextBoxPlaats.Text + "', '" +
                    USdateVan + "', '" +
                    USdateTot + "')";

                Data d = new Data(connectionstring);
                d.DataInsert(query);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
