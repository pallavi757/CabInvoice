
namespace CabInvoiceGenerator
{
    using System;
    //Class to Enhanced invoice
    public class EnhancedInvoice
    {
        private int numberOfRides;
        public double totalFare;
        private double averageFare;

        public EnhancedInvoice(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

    }
}
