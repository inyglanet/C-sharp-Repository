using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;

namespace CourierManagementSystem.BuisnessLayer.Services
{
    public interface ICourierUserService
    {
        string PlaceOrder(Courier courier);
        string GetOrderStatus(string trackingNumber);
        bool CancelOrder(string trackingNumber);
        List<Courier> GetAssignedOrders(int courierStaffId);
    }
}
