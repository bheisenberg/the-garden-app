using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BigHelpers
{
    class DataConnector
    {
        public MySqlConnection connection;

        public DataConnector ()
        {
            string connectionString = "server=127.0.0.1;uid=root;" + "pwd=flickamole2;database=thegarden;";
            try
            {
                connection = new MySqlConnection(connectionString);
                Console.WriteLine("Successfully connected to " + connection.Database);

            } catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
