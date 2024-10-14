using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransportManagementSystem.Entity;
using TransportManagementSystem.BuisnessLayer;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.BuisnessLayer.Repository;


namespace TransportManagementSystem_Testing
{
    [TestFixture]
    public class TestingClass
    {
        private VehicleRepositoy _vehicleRepository;
        private BookingRepository _bookingRepository;
        private DriverRepository _driverRepository;
        private TripRepository _tripRepository;

        [SetUp]
        public void Setup()
        {
            _vehicleRepository = new VehicleRepositoy();
            _bookingRepository = new BookingRepository();
            _driverRepository = new DriverRepository();
            _tripRepository = new TripRepository();
        }

        [Test]
        public void Test_AddVehicle_Success()
        {
            var vehicle = new Vehicle
            {
                Model = "Bus",
                Capacity = 50.0m,
                Type = "Bus",
                Status = "Available"
            };

            var result = _vehicleRepository.AddVehicle(vehicle);

            //Assert
            Assert.IsTrue(result, "Vehicle should be added successfully.");
        }

        [Test]
        public void Test_UpdateVehicle_Success()
        {
            var vehicle = new Vehicle
            {
                VehicleID = 1, 
                Model = "Updated Bus",
                Capacity = 60.0m,
                Type = "Bus",
                Status = "Available"
            };

            var result = _vehicleRepository.UpdateVehicle(vehicle);

            //Assert
            Assert.IsTrue(result, "Vehicle should be updated successfully.");
        }

        [Test]
        public void Test_DeleteVehicle_Success()
        {
            int vehicleId = 1;
            var result = _vehicleRepository.DeleteVehicle(vehicleId);

            //Assert
            Assert.IsTrue(result, "Vehicle should be deleted successfully.");
        }

        [Test]
        public void Test_BookTrip_Success()
        {
            var booking = new Booking
            {
                TripID = 1, 
                PassengerID = 1, 
                BookingDate = DateTime.Now 
            };

            var result = _bookingRepository.BookTrip(booking);

            //Assert
            Assert.IsTrue(result, "Trip should be booked successfully.");
        }

        [Test]
        public void Test_CancelBooking_Success()
        {
            int bookingId = 1; 
            var result = _bookingRepository.CancelBooking(bookingId);

            Assert.IsTrue(result, "Booking should be canceled successfully.");
        }

        [Test]
        public void Test_ScheduleTrip_Success()
        {
            var trip = new Trips
            {
                VehicleID = 1, 
                RouteID = 1,
                DepartureDate = DateTime.Now.AddHours(1), 
                ArrivalDate = DateTime.Now.AddHours(2) 
            };

            var result = _tripRepository.ScheduleTrip(trip);

            //Assert
            Assert.IsTrue(result, "Trip should be scheduled successfully.");
        }

        [Test]
        public void Test_CancelTrip_Success()
        {
            int tripId = 1; 
            var result = _tripRepository.CancelTrip(tripId);

            //Assert
            Assert.IsTrue(result, "Trip should be canceled successfully.");
        }

    }
}
