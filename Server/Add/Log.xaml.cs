using MySql.Data.MySqlClient;
using Server.getDB;
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

namespace Server.Add
{
    /// <summary>
    /// Interaction logic for Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        Data d;
        string connectionstring;
        public Log(string connectionstring)
        {
            InitializeComponent();
            this.connectionstring = connectionstring;
            d = new Data(connectionstring);

            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select * from tbllog";
            cmd.CommandText = command;
            List<Models.Log> logs = new List<Models.Log>();

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Models.Log log = new Models.Log()
                    {
                       LogID = Convert.ToInt32(reader[0]),
                       InstallatieID = Convert.ToInt32(reader[1]),
                       Melding = Convert.ToString(reader[2]),
                       Tijd = Convert.ToDateTime(reader[3]),
                        
                    };
                    logs.Add(log);
                }
            }
            catch
            {

            }
            finally
            {
                foreach(Models.Log l in logs)
                {
                    string x = l.LogID + '\t' + l.InstallatieID + '\t' + l.Melding + '\t' + l.Tijd;
                    listLogs.Items.Add(x);
                 }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listLogs.Items.Clear();
            MySqlConnection conn = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string command = "select * from tbllog";
            cmd.CommandText = command;
            List<Models.Log> logs = new List<Models.Log>();

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Models.Log log = new Models.Log()
                    {
                        LogID = Convert.ToInt32(reader[0]),
                        InstallatieID = Convert.ToInt32(reader[1]),
                        Melding = Convert.ToString(reader[2]),
                        Tijd = Convert.ToDateTime(reader[3]),

                    };
                    logs.Add(log);
                }
            }
            catch
            {

            }
            finally
            {
                foreach (Models.Log l in logs)
                {
                    string x = l.LogID + '\t' + l.InstallatieID + '\t' + l.Melding + '\t' + l.Tijd;
                    listLogs.Items.Add(x);
                }
            }
        }
    }
}
