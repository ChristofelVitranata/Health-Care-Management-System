using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UASbd
{
    internal class Connection
    {
        string conectionstring = "Server=localhost;Database=uasbd;Uid=root;Pwd=;";
        MySqlConnection cnt;

        public void OpenConnection()
        {
            cnt = new MySqlConnection(conectionstring);
            cnt.Open();
        }

        public void CloseConnection()
        {
            cnt.Close();
        }

        public void ExecuteQuery (string query)
        {
            MySqlCommand command = new MySqlCommand(query, cnt);
            command.ExecuteNonQuery();
        }

        public object ShowData(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conectionstring);
            DataSet data = new DataSet();

            adapter.Fill(data);
            object bebas = data.Tables[0];
            return bebas;
        }
    }
}
