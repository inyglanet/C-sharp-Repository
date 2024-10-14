using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entity;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.BuisnessLayer.Services;
using TransportManagementSystem.Util;
using System.Data.SqlClient;


namespace TransportManagementSystem.BuisnessLayer.Repository
{
    public class DriverRepository : IDriverService
    {
        private SqlConnection GetConnection()
        {
            var connection = DBConnectionUtil.GetDBConnection();
            connection.Open();
            return connection;
        }

        public List<Driver> GetAvailableDrivers()
        {
            var drivers = new List<Driver>();
            string sql = "SELECT * FROM Drivers WHERE Id NOT IN (SELECT DriverId FROM Trips WHERE DriverId IS NOT NULL)";
            using (var connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        drivers.Add(new Driver
                        {
                            DriverID = reader.GetInt32(0),
                            DriverName = reader.GetString(1)
                        });
                    }
                }
            }
            return drivers;
        }

        public bool AllocateDriver(int tripID, int driverID)
        {
            string sql = "UPDATE Trips SET DriverId = @DriverId WHERE Id = @TripID";
            using (var connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TripId", tripID);
                command.Parameters.AddWithValue("@DriverId", driverID);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeallocateDriver(int tripID)
        {
            string sql = "UPDATE Trips SET DriverId = NULL WHERE Id = @TripId";
            using (var connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TripId", tripID);
                return command.ExecuteNonQuery() > 0;
            }

        }

    }
}
