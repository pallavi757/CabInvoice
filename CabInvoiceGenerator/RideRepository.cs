

namespace CabInvoiceGenerator
{
    using System.Collections.Generic;
    public class RideRepository
    {
        //Dictionary to store rides for each user
        private Dictionary<string, List<Ride>> userRides = null;
        //Constructor to instantiante Dictionary userRides
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        //Gets Invoice for a particular user
        public EnhancedInvoice GetInvoice(string userId)
        {
            if (userRides.ContainsKey(userId))
                return InvoiceGenerator.CalculateFare(userRides[userId].ToArray());
            else
                throw new Cabexception(Cabexception.ExceptionType.Invalid_User_Id, "Invalid UserID");
        }
        //Adds the user alongwith its rides to userRides dictionary. Overwrites the rides if user exists
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            if (rides == null)
                throw new Cabexception(Cabexception.ExceptionType.Null_rides, "Rides Are Null");
            if (rideList)
            {
                userRides[userId].Clear();
                userRides[userId].AddRange(rides);
            }
            else
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userId, list);
            }
        }
    }
}
