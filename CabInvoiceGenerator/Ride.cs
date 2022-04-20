using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    //Class to store info about particular ride
    public class Ride
    {
        public double distance;
        public int time;
        public RideType rideType;

        public Ride(double distance, int time, RideType rideType)
        {
            this.distance = distance;
            this.time = time;
            this.rideType= rideType;
        }
    }
}
