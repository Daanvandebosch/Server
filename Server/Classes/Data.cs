using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Server
{
    class Data
    {
        private string myConnectionString = "server=localhost;uid=root;pwd=bobeke;database=mydb";
        MySqlConnection conn;
        MySqlCommand cmd;
        public Data(string _command, string commandtype)
        {
            conn = new MySqlConnection();
            cmd.Connection = conn;
        }
        public string dataSelect(string _command, int arrsize)
        {
            string[] output = new string[arrsize];
            cmd.CommandText = _command;
            return "t";
            
        }
        public string dataSelect(string _command)
        {
            string output;
            cmd.CommandText = _command;
            conn.Open();
            //output = cmd.ExecuteScalar();
            return "t";
        }
    }
}
