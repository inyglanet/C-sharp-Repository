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
    public class TripRepository : ITripService
    {
        public bool ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate)
        {
            string sql = "INSERT INTO Trip (VehicleID, RouteID, DepartureDate, ArrivalDate, Status, TripType) VALUES (@VehicleID, @RouteID, @DepartureDate, @ArrivalDate, @Status, @TripType)";
            using (var connection = DBConnectionUtil.GetDBConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@VehicleID", vehicleId);
                command.Parameters.AddWithValue("@RouteID", routeId);
                command.Parameters.AddWithValue("@DepartureDate", departureDate);
                command.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                command.Parameters.AddWithValue("@Status", "Scheduled");
                command.Parameters.AddWithValue("@TripType", "Freight");
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool CancelTrip(int tripId)
        {
            string sql = "DELETE FROM Trips WHERE Id = @TripId";
            using (var connection = DBConnectionUtil.GetDBConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TripId", tripId);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
