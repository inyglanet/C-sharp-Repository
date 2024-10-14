using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;

namespace CourierManagementSystem.BuisnessLayer.Services
{
    public interface ICourierAdminService
    {
        int AddCourierStaff(Employees employee);
    }
}
