using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TransportManagementSystem.Util
{
    public class DBConnectionUtil
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection connection;
            string connectionString = "Data Source=LENOVO ;Initial Catalog= TransportManagementSystem ; Integratrd Security=True ;";
            connection = new SqlConnection();
            connectionString = connection.ConnectionString;
            connection.Open();
            return connection;

        }
    }
}
