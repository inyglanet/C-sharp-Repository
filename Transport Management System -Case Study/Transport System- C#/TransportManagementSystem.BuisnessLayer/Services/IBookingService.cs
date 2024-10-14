using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entity;

namespace TransportManagementSystem.BuisnessLayer.Services
{
    public  interface IBookingService
    {
        bool BookTrip(Booking booking);
        bool CancelBooking(int bookingId);
        Booking GetBookingById(int bookingId);
        List<Booking> GetBookingsByPassenger(int passengerId);
        List<Booking> GetBookingsByTrip(int tripId);
    }
}
