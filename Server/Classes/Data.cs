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
        private string myConnectionString;
        MySqlConnection conn;
        MySqlCommand cmd;

        public Data(string connectionstring)
        {
            myConnectionString = connectionstring;
            conn = new MySqlConnection(myConnectionString);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }

        public void ConnectionTest()
        {
            conn.Open();
            conn.Close();
        }
        //dataSelect with single string output
        public string DataSelect(string _command)
        {
            dynamic output;
            cmd.CommandText = _command;
            conn.Open();
            output = cmd.ExecuteScalar().ToString();
            conn.Close();
            return output;
        }

        public void DataUpdate(string _command)
        {
            SimpleExecute(_command);
        }
        
        public void DataInsert(string _command)
        {
            SimpleExecute(_command);
        }

        public void DataRemoce(string _command)
        {
            SimpleExecute(_command);
        }

        private void SimpleExecute(string _command)
        {
            cmd.CommandText = _command;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
