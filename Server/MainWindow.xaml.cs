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
        string myConnectionString = "server=localhost;uid=root;pwd=bobeke;database=mydb";
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO tblLog (Melding) VALUES ('Luca is wel gay')";
            conn.Open();
            cmd.Connection = conn;
            while (true)
            {
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
