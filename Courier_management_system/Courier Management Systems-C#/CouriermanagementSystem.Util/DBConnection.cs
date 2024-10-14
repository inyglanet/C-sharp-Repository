using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CouriermanagementSystem.Util
{
    public class DBConnection
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection connection;
            string connectionString = "Data Source=LENOVO ;Initial Catalog= CourierManagementSystem ; Integratrd Security=True ;";
            connection = new SqlConnection();
            connectionString = connection.ConnectionString;
            connection.Open();
            return connection;

        }


    }
}
