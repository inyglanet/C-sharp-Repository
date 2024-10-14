using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Entity
{
    public class Trips
    {
        public int TripID {  get; set; }
        public int VehicleID { get; set; }
        public int RouteID { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Status { get; set; }
        public string TripType {  get; set; }
        public int MaxPassengers {  get; set; }
        
        


    }
}
