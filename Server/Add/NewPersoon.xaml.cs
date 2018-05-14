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
    /// Interaction logic for NewPersoon.xaml
    /// </summary>
    public partial class NewPersoon : Window
    {
        private string connectionstring;

        public NewPersoon(string connectionstring)
        {
            this.connectionstring = connectionstring;
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO tblpersoon (GSM, Functie, Voornaam, Achternaam)";

            query += " VALUES ('" +
                TextBoxGSM.Text + "', '" +
                TextBoxFunctie.Text + "', '" +
                TextBoxVoornaam.Text + "', '" +
                TextBoxAchternaam.Text + "')";

            Data d = new Data(connectionstring);
            d.DataInsert(query);

            this.Close();
        }
    }
}
