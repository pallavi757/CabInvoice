

namespace CabInvoiceGenerator
{
    using System;
    public class InvoiceGenerator
    {
        //Charges of the rides
        private static int CHARGE_PER_KM;
        private static int CHARGE_PER_MIN;
        private static int MINIMUM_FARE;


        //Calculates the total fare for a particular ride
        public static double CalculateFare(double distanceInKM, int timeInMin, RideType rideType)
        {
            SetCharges(rideType);
            double calculatedFare = 0;
            if (distanceInKM <= 0)
            {
                throw new Cabexception(Cabexception.ExceptionType.Invalid_Time, "Invalid Distance");
            }
            if (timeInMin < 0)
            {
                throw new Cabexception(Cabexception.ExceptionType.Invalid_Time, "Invalid Time");
            }
            calculatedFare = (CHARGE_PER_KM * distanceInKM) + (CHARGE_PER_MIN * timeInMin);
            return Math.Max(calculatedFare, MINIMUM_FARE);
        }
        //Generates Rides Invoice Summary
        public static EnhancedInvoice CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            if (rides == null)
            {
                throw new Cabexception(Cabexception.ExceptionType.Null_rides, "Rides Are Null");
            }
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time, ride.rideType);
            }
            return new EnhancedInvoice(rides.Length, totalFare);
        }

        
        //private method for setting the charges for a each type of ride 
        private static void SetCharges(RideType rideType)
        {
            if (rideType.Equals(RideType.NORMAL))
            {
                CHARGE_PER_KM = 10;
                CHARGE_PER_MIN = 1;
                MINIMUM_FARE = 5;
            }
            else if (rideType.Equals(RideType.PREMIUM))
            {
                CHARGE_PER_KM = 15;
                CHARGE_PER_MIN = 2;
                MINIMUM_FARE = 20;
            }
            else
                throw new Cabexception(Cabexception.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
        }
    }
}
