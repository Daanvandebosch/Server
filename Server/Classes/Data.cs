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
        private string myConnectionString = string.Format("datasource ={0}; port=3306;username= {1};password= {2};database={3}", "10.11.51.22", "root", "bobeke", "mydb");
        MySqlConnection conn;
        MySqlCommand cmd;

        public Data()
        {
            conn = new MySqlConnection(myConnectionString);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }

        public void ConnectionTest()
        {
            conn.Open();
            conn.Close();
        }

        //dataSelect with list<string[]> output
        public List<List<string>> MultipledataSelect(string _command, int Aantalvars)
        {
            List<List<string>> outputList = new List<List<String>>();
            List<string> varList = new List<string>();
            cmd.CommandText = _command;
            Aantalvars--;
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i <= Aantalvars; i++)
                {
                    varList.Add(reader.GetValue(i).ToString());
                    string x = reader.GetValue(i).ToString();
                }
                outputList.Add(varList);
            }
            conn.Close();
            return outputList;
            
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
