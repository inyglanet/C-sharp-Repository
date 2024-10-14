using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Exceptions;
using CourierManagementSystem.BuisnessLayer.Services;

namespace CourierManagementSystem.BuisnessLayer.Repository
{
    public class CourierUserService : ICourierUserService
    {
        private readonly List<Courier> couriers = new List<Courier>();
        private static int trackingNumberCounter = 1000; 

        public string PlaceOrder(Courier courier)
        {
            courier.TrackingNumber = "TN" + trackingNumberCounter++;
            couriers.Add(courier);
            return courier.TrackingNumber;
        }

        public string GetOrderStatus(string trackingNumber)
        {
            var courier = couriers.Find(c => c.TrackingNumber == trackingNumber);
            if (courier == null)
            {
                throw new TrackingNumberNotFoundException("Tracking number not found.");
            }
            return courier.Status;
        }

        public bool CancelOrder(string trackingNumber)
        {
            var courier = couriers.Find(c => c.TrackingNumber == trackingNumber);
            if (courier == null)
            {
                throw new TrackingNumberNotFoundException("Tracking number not found.");
            }

            if (courier.Status != "Delivered")
            {
                courier.Status = "Canceled";
                return true;
            }
            return false;
        }

        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            return couriers; 
        }
    }

}
