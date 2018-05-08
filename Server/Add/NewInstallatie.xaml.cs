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

            string USdateVan = DateTime.Parse(DatePickerVan.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string USdateTot = DateTime.Parse(DatePickerTot.Text).ToString("yyyy-MM-dd HH:mm:ss");

            query += " VALUES ('"
                + ComboAddContainerID.SelectedValue + "', '"
                + ComboAddDeviceID.SelectedValue + "', '"
                + USdateVan + "', '"
                + USdateTot + "', '"
                + ComboAddEventID.SelectedValue + "', '"
                + TextBoxOmschrijving + "', '"
                + ComboAddVerantwoordelijkeID.SelectedValue + "', '"
                + "')";

            Data d = new Data(connectionstring);
            d.DataInsert(query);

            this.Close();
        }
    }
}
