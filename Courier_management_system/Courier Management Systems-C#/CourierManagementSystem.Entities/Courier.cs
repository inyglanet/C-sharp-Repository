using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entities
{
    public class Courier
    {
        

        public int CourierID { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public int Weight { get; set; }
        public string Status { get; set; }
        public string TrackingNumber{ get; set; }
        public DateTime DeliveryDate { get; set; }
        public int UserID { get; set; }

        

    }
}
