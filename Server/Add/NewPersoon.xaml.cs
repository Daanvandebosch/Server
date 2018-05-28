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
            try
            {
                string query = "INSERT INTO tblpersoon (GSM, Functie, Voornaam, Achternaam)";
                if (TextBoxAchternaam.Text == "")
                {
                    throw new Exception("Je moet de achternaam invullen.");
                }
                if (TextBoxFunctie.Text == "")
                {
                    throw new Exception("Je moet de functie invullen.");
                }
                if (TextBoxGSM.Text == "")
                {
                    throw new Exception("Je moet het gsm nummer invullen");
                }
                if (TextBoxVoornaam.Text == "")
                {
                    throw new Exception("Je moet de voornaam invullen");
                }


                query += " VALUES ('" +
                    TextBoxGSM.Text + "', '" +
                    TextBoxFunctie.Text + "', '" +
                    TextBoxVoornaam.Text + "', '" +
                    TextBoxAchternaam.Text + "')";

                Data d = new Data(connectionstring);
                d.DataInsert(query);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
