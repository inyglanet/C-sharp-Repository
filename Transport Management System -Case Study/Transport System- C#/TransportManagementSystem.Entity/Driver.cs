using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Entity
{
    public  class Driver
    {
        public int DriverID {  get; set; }
        public int TripID {  get; set; }
        public string DriverName { get; set; }
        public long ContactNumber { get; set; }

    }
}
