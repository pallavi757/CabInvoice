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
            Invalid_Dist,Invalid_Time,Null_rides
        }
        public Cabexception(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
