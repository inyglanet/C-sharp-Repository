using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entity;

namespace TransportManagementSystem.BuisnessLayer.Services
{
    public interface ITripService
    {
        bool ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate);
        bool CancelTrip(int tripId);
    }
}
