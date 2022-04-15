using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private readonly int minimumFare = 5;
        private double calculatedFare = 0;
        public double CalculateFare(double distanceInKM, int timeInMin)
        {
            if (distanceInKM <= 0)
            {
                throw new Cabexception( Cabexception.ExceptionType.Invalid_Dist, "Invalid Distance");
            }
            if (timeInMin < 0)
            {
                throw new Cabexception(Cabexception.ExceptionType.Invalid_Time, "Invalid Time");
            }
            calculatedFare = (10 * distanceInKM) + timeInMin;
            return Math.Max(calculatedFare, minimumFare);
        }
        public double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            if (rides == null)
            {
                throw new Cabexception(Cabexception.ExceptionType.Null_rides, "Rides Are Null");
            }
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
}
