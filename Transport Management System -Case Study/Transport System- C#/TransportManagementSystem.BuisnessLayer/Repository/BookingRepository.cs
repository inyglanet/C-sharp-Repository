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
    public class BookingRepository : IBookingService
    {
        private SqlConnection GetConnection()
        {
            var connection = DBConnectionUtil.GetDBConnection();
            connection.Open();
            return connection;
        }

        public bool BookTrip(Booking booking)
        {
            if (!TripExists(booking.TripID))
            {
                throw new Exception($"Trip with ID {booking.TripID} not found.");
            }
            if (!PassengerExists(booking.PassengerID))
            {
                throw new Exception($"Passenger with ID {booking.PassengerID} not found.");
            }

            string sql = "INSERT INTO Bookings (TripID, PassengerID, BookingDate, Status) VALUES (@TripID, @PassengerID, @BookingDate, @Status)";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TripID", booking.TripID);
                command.Parameters.AddWithValue("@PassengerID", booking.PassengerID);
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@Status", "Confirmed");
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool CancelBooking(int bookingId)
        {
            string sql = "DELETE FROM Bookings WHERE BookingID = @BookingID";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@BookingID", bookingId);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new BookingNotFoundException($"Booking with ID {bookingId} not found.");
                }
                return true;
            }
        }

        public Booking GetBookingById(int bookingId)
        {
            string sql = "SELECT * FROM Bookings WHERE BookingID = @BookingID";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@BookingID", bookingId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Booking
                        {
                            BookingID = reader.GetInt32(0),
                            TripID = reader.GetInt32(1),
                            PassengerID = reader.GetInt32(2),
                            BookingDate = reader.GetDateTime(3),
                            Status = reader.GetString(4)
                        };
                    }
                }
            }
            throw new BookingNotFoundException($"Booking with ID {bookingId} not found.");
        }

        public List<Booking> GetBookingsByPassenger(int passengerId)
        {
            List<Booking> bookings = new List<Booking>();
            string sql = "SELECT * FROM Bookings WHERE PassengerID = @PassengerID";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@PassengerID", passengerId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            BookingID = reader.GetInt32(0),
                            TripID = reader.GetInt32(1),
                            PassengerID = reader.GetInt32(2),
                            BookingDate = reader.GetDateTime(3),
                            Status = reader.GetString(4)
                        });
                    }
                }
            }
            return bookings;
        }

        public List<Booking> GetBookingsByTrip(int tripId)
        {
            List<Booking> bookings = new List<Booking>();
            string sql = "SELECT * FROM Bookings WHERE TripID = @TripID";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TripID", tripId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            BookingID = reader.GetInt32(0),
                            TripID = reader.GetInt32(1),
                            PassengerID = reader.GetInt32(2),
                            BookingDate = reader.GetDateTime(3),
                            Status = reader.GetString(4)
                        });
                    }
                }
            }
            return bookings;
        }

        private bool TripExists(int tripID)
        {
            string sql = "SELECT COUNT(*) FROM Trips WHERE TripID = @TripID";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TripID", tripID);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private bool PassengerExists(int passengerID)
        {
            string sql = "SELECT COUNT(*) FROM Passengers WHERE PassengerID = @PassengerID";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@PassengerID", passengerID);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
