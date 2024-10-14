using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelTrackingtwoDArray
{
    struct Parcel
    {
        public string TrackingNumber;
        public string Status;
    }
    internal class ParcelTracking
    {
        static void Main(string[] args)
        {
            Parcel[,] parcels = new Parcel[3, 2]
       {
            { new Parcel { TrackingNumber = "12345", Status = "In Transit" },
              new Parcel { TrackingNumber = "67890", Status = "Out for Delivery" } },
            { new Parcel { TrackingNumber = "54321", Status = "Delivered" },
              new Parcel { TrackingNumber = "09876", Status = "In Transit" } },
            { new Parcel { TrackingNumber = "11223", Status = "Out for Delivery" }, 
               new Parcel { TrackingNumber = "44556", Status = "Delivered" } }
       };

            Console.WriteLine("Enter a parcel tracking number:");
            string input = Console.ReadLine();

            bool found = false;
            foreach (var parcel in parcels)
            {
                if (parcel.TrackingNumber == input)
                {
                    Console.WriteLine($"Tracking Number: {parcel.TrackingNumber}, Status: {parcel.Status}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Tracking number not found.");
            }

        }
    }
}
