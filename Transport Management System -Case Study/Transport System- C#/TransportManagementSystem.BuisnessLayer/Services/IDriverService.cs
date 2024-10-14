using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entity;

namespace TransportManagementSystem.BuisnessLayer.Services
{
    public interface IDriverService
    {
        List<Driver> GetAvailableDrivers();
        bool AllocateDriver(int tripId, int driverId);
        bool DeallocateDriver(int tripId);
    }
}
