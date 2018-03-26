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
        public Data()
        {
            conn = new MySqlConnection(myConnectionString);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }
        //dataSelect with list<string[]> output
        public List<List<string>> MultipledataSelect(string _command)
        {
            List<List<string>> outputList = new List<List<String>>();
            List<string> varList = new List<string>();
            cmd.CommandText = _command;
            int varTeller = 0;
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                while(reader.GetValue(varTeller) != null)
                {
                    varList.Add(reader.GetValue(varTeller).ToString());
                    varTeller++;
                }
                varTeller = 0;
                outputList.Add(varList);
            }
            conn.Close();
            return outputList;
            
        }
        //dataSelect with single string output
        public string dataSelect(string _command)
        {
            string output;
            cmd.CommandText = _command;
            conn.Open();
            output = cmd.ExecuteScalar().ToString();
            conn.Close();
            return output;
        }

        public void dataUpdate(string _command)
        {
            simpleExecute(_command);
        }
        public void dataInsert(string _command)
        {
            simpleExecute(_command);
        }
        public void dataRemoce(string _command)
        {
            simpleExecute(_command);
        }
        private void simpleExecute(string _command)
        {
            cmd.CommandText = _command;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
