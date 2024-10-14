using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TransportManagementSystem.Entity;
using TransportManagementSystem.BuisnessLayer.Repository;
using TransportManagementSystem.BuisnessLayer.Services;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.Util;


namespace TransportManagementSystem.UI
{
    public class TransportSystem
    {
        static void Main(string[] args)
        {
            var vehicleService = new VehicleRepositoy();
            var bookingService = new BookingRepository();
            var driverService = new DriverRepository();
            var tripService = new TripRepository();
            bool condition = true;

            while (condition)
            {
                Console.WriteLine("Transport Management System Menu");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Update Vehicle");
                Console.WriteLine("3. Delete Vehicle");
                Console.WriteLine("4. Schedule Trip");
                Console.WriteLine("5. Cancel Trip");
                Console.WriteLine("6. Book Trip");
                Console.WriteLine("7. Cancel Booking");
                Console.WriteLine("8. Allocate Driver");
                Console.WriteLine("9. Deallocate Driver");
                Console.WriteLine("10. Get Vehicle By ID");
                Console.WriteLine("11. Get Booking By ID");
                Console.WriteLine("12. Get Booking Details using PassengerID");
                Console.WriteLine("13. Get Booking Details using TripId");
                Console.WriteLine("14. Get the details of available Drivers");
                Console.WriteLine("15. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":// Add Vehicle
                        try
                        {
                            var vehicle = new Vehicle
                            {
                                Model = "Truck Model",
                                Capacity = 1500.00m,
                                Type = "Truck",
                                Status = "Available"
                            };
                            bool added = vehicleService.AddVehicle(vehicle);
                            Console.WriteLine(added ? "Vehicle added successfully." : "Failed to add vehicle.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":// Update Vehicle
                        try
                        {
                            Console.Write("Enter Vehicle ID to update: ");
                            int vehicleId = int.Parse(Console.ReadLine());
                            Vehicle vehicle = vehicleService.GetVehicleById(vehicleId);
                            vehicle.Model = "Updated Truck Model";
                            bool updated = vehicleService.UpdateVehicle(vehicle);
                            Console.WriteLine(updated ? "Vehicle updated successfully." : "Failed to update vehicle.");
                        }
                        catch (VehicleNotFoundException vnfe)
                        {
                            Console.WriteLine(vnfe.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "3":// Delete Vehicle
                        try
                        {
                            Console.Write("Enter Vehicle ID to delete: ");
                            int vehicleId = int.Parse(Console.ReadLine());
                            bool deleted = vehicleService.DeleteVehicle(vehicleId);
                            Console.WriteLine(deleted ? "Vehicle deleted successfully." : "Failed to delete vehicle.");
                        }
                        catch (VehicleNotFoundException vnfe)
                        {
                            Console.WriteLine(vnfe.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "4": // Schedule Trip
                        try
                        {
                            Console.Write("Enter Vehicle ID: ");
                            int vehicleId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Route ID: ");
                            int routeId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Departure Date (YYYY-MM-DD HH:MM): ");
                            DateTime departureDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Arrival Date (YYYY-MM-DD HH:MM): ");
                            DateTime arrivalDate = DateTime.Parse(Console.ReadLine());

                            bool scheduled = tripService.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate);
                            Console.WriteLine(scheduled ? "Trip scheduled successfully." : "Failed to schedule trip.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "5": // Cancel Trip
                        try
                        {
                            Console.Write("Enter Trip ID to cancel: ");
                            int tripIdToCancel = int.Parse(Console.ReadLine());
                            bool tripCanceled = tripService.CancelTrip(tripIdToCancel);
                            Console.WriteLine(tripCanceled ? "Trip canceled successfully." : "Failed to cancel trip.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;


                    case "6"://Book Trip
                        try
                        {
                            Console.Write("Enter Trip ID: ");
                            int tripId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Passenger ID: ");
                            int passengerID = int.Parse(Console.ReadLine());
                            Console.Write("Enter Booking Date (YYYY-MM-DD): ");
                            string bookingDate = Console.ReadLine();
                            Booking booking = new Booking
                            {
                                TripID = tripId,
                                PassengerID = passengerID,
                                BookingDate = DateTime.Parse(bookingDate)
                            };
                            bool booked = bookingService.BookTrip(booking);
                            Console.WriteLine(booked ? "Trip booked successfully." : "Failed to book trip.");
                        }
                        catch (BookingNotFoundException bnfe)
                        {
                            Console.WriteLine(bnfe.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "7": // Cancel Booking
                        try
                        {
                            Console.Write("Enter Booking ID to cancel: ");
                            int bookingIdToCancel = int.Parse(Console.ReadLine());
                            bool bookingCanceled = bookingService.CancelBooking(bookingIdToCancel);
                            Console.WriteLine(bookingCanceled ? "Booking canceled successfully." : "Failed to cancel booking.");
                        }
                        catch (BookingNotFoundException bnfe)
                        {
                            Console.WriteLine(bnfe.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "8": // Allocate Driver
                        try
                        {
                            Console.Write("Enter Trip ID to allocate driver: ");
                            int tripIdToAllocate = int.Parse(Console.ReadLine());
                            Console.Write("Enter Driver ID: ");
                            int driverIdToAllocate = int.Parse(Console.ReadLine());
                            bool driverAllocated = driverService.AllocateDriver(tripIdToAllocate, driverIdToAllocate);
                            Console.WriteLine(driverAllocated ? "Driver allocated successfully." : "Failed to allocate driver.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "9": // Deallocate Driver
                        try
                        {
                            Console.Write("Enter Trip ID to deallocate driver: ");
                            int tripIdToDeallocate = int.Parse(Console.ReadLine());
                            bool driverDeallocated = driverService.DeallocateDriver(tripIdToDeallocate);
                            Console.WriteLine(driverDeallocated ? "Driver deallocated successfully." : "Failed to deallocate driver.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "10":// Get Vehicle By Id
                        try
                        {
                            Console.Write("Enter Vehicle ID: ");
                            int vehicleId = int.Parse(Console.ReadLine());
                            Vehicle vehicle = vehicleService.GetVehicleById(vehicleId);
                            Console.WriteLine($"Vehicle ID: {vehicle.VehicleID}, Model: {vehicle.Model}, Status: {vehicle.Status}");
                        }
                        catch (VehicleNotFoundException vnfe)
                        {
                            Console.WriteLine(vnfe.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "11": // Get Booking By ID
                        try
                        {
                            Console.Write("Enter Booking ID: ");
                            int bookingId = int.Parse(Console.ReadLine());
                            Booking booking = bookingService.GetBookingById(bookingId);
                            Console.WriteLine($"Booking ID: {booking.BookingID}, Trip ID: {booking.TripID}, Status: {booking.Status}");
                        }
                        catch (BookingNotFoundException bnfe)
                        {
                            Console.WriteLine(bnfe.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "12": // Get Booking Details using PassengerID
                        try
                        {
                            Console.Write("Enter Passenger ID: ");
                            int passengerId = int.Parse(Console.ReadLine());
                            var bookingsByPassenger = bookingService.GetBookingsByPassenger(passengerId);

                            if (bookingsByPassenger.Count > 0)
                            {
                                foreach (var booking in bookingsByPassenger)
                                {
                                    Console.WriteLine($"Booking ID: {booking.BookingID}, Trip ID: {booking.TripID}, Booking Date: {booking.BookingDate}, Status: {booking.Status}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No bookings found for this passenger.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "13": // Get Booking Details using TripId
                        try
                        {
                            Console.Write("Enter Trip ID: ");
                            int tripId = int.Parse(Console.ReadLine());
                            var bookingsByTrip = bookingService.GetBookingsByTrip(tripId);

                            if (bookingsByTrip.Count > 0)
                            {
                                foreach (var booking in bookingsByTrip)
                                {
                                    Console.WriteLine($"Booking ID: {booking.BookingID}, Passenger ID: {booking.PassengerID}, Booking Date: {booking.BookingDate}, Status: {booking.Status}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No bookings found for this trip.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "14":// Get Available Drivers
                        var availableDrivers = driverService.GetAvailableDrivers();
                        foreach (var driver in availableDrivers)
                        {
                            Console.WriteLine($"Driver ID: {driver.DriverID}, Name: {driver.DriverName}");
                        }
                        break;

                    case "15":// To exist the Program
                        condition = false;
                        break;

                    default: // Invalid option
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Exiting Transport Management System!!!!");
            Console.WriteLine("Thank You!!");
            Console.ReadKey();
        }
    }
}
    

