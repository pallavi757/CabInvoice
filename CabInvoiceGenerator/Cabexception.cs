
namespace CabInvoiceGenerator
{
    using System;
    //Custom exception class
     class Cabexception:Exception
    {
        private ExceptionType type;
        public enum ExceptionType
        {
            Invalid_Dist,Invalid_Time,Null_rides,Invalid_User_Id,Invalid_Ride_Type
        }
        public Cabexception(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
