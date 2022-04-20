using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Cabexception:Exception
    {
        private ExceptionType type;
        public enum ExceptionType
        {
            Invalid_Dist,Invalid_Time,Null_rides,Invalid_User_Id
        }
        public Cabexception(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
