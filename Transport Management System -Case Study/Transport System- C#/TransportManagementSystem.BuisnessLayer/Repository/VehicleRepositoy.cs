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
    public class VehicleRepositoy : IVehicleService
    {
        private SqlConnection GetConnection()
        {
            var connection = DBConnectionUtil.GetDBConnection();
            connection.Open();
            return connection;
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            string sql = "INSERT INTO Vehicles (Model, Capacity, Type, Status) VALUES (@Model, @Capacity, @Type, @Status)";
            using (var connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Model", vehicle.Model);
                command.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                command.Parameters.AddWithValue("@Type", vehicle.Type);
                command.Parameters.AddWithValue("@Status", vehicle.Status);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            string sql = "UPDATE Vehicles SET Model = @Model, Capacity = @Capacity, Type = @Type, Status = @Status WHERE VehicleID = @VehicleID";
            using (var connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                command.Parameters.AddWithValue("@Model", vehicle.Model);
                command.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                command.Parameters.AddWithValue("@Type", vehicle.Type);
                command.Parameters.AddWithValue("@Status", vehicle.Status);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteVehicle(int VehicleID)
        {
            string sql = "DELETE FROM Vehicles WHERE VehicleID = @VehicleID";
            using (var connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@VehicleID", VehicleID);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public Vehicle GetVehicleById(int vehicleID)
        {
            string sql = "SELECT * FROM Vehicles WHERE VehicleID = @VehicleID";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@VehicleID", vehicleID);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Vehicle
                        {
                            VehicleID = reader.GetInt32(0),
                            Model = reader.GetString(1),
                            Capacity = reader.GetDecimal(2),
                            Type = reader.GetString(3),
                            Status = reader.GetString(4)
                        };
                    }
                }
            }
            throw new VehicleNotFoundException($"Vehicle with ID {vehicleID} not found.");
        }
    }
}
