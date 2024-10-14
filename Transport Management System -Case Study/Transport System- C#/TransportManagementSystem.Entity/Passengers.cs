using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Entity
{
    public class Passengers
    {
        public int PassengerID {  get; set; }
        public string FirstName { get; set; }
        public string Gender {  get; set; }
        public int Age {  get; set; }
        public string Email {  get; set; }
        public long PhoneNumber { get; set; }

    }
}
