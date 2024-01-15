using MySqlConnector;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik.DB
{
    public class SqlConnectionFactory
    {
        public static string SqlConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Baza"].ConnectionString;
            }
        }
        public MySqlConnection GetNewConnection()
        {
            try
            {
                var connection = new MySqlConnection(SqlConnectionString);
                connection.Open();

                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

