using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoringTrackingHistory
{
    internal class TrackingHistory
    {
        static void Main(string[] args)
        {
            String[] trackingHistory = new String[5];
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the tracking history of parcel {0}", i);
                trackingHistory[i] = Console.ReadLine();

            }
            foreach(var location_update in trackingHistory)
            {
                Console.WriteLine(location_update);
            }

            Console.ReadKey();

        }
    }
}
