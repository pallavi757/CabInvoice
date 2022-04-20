using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        private Dictionary<string, List<Ride>> userRides = null;
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        public EnhancedInvoice GetInvoice(string userId)
        {
            if (userRides.ContainsKey(userId))
                return InvoiceGenerator.CalculateFare(userRides[userId].ToArray());
            else
                throw new Cabexception(Cabexception.ExceptionType.Invalid_User_Id, "Invalid UserID");
        }
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
