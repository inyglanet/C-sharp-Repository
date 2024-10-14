using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entity;

namespace TransportManagementSystem.BuisnessLayer.Services
{
    public interface IVehicleService
    {
        Vehicle GetVehicleById(int vehicleID);
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int VehicleID);
    }
}
