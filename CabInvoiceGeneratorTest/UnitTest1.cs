using CabInvoiceGenerator;
using NUnit.Framework;
using System;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenetratorTestObj;
        [SetUp]
        public void Setup()
        {
            invoiceGenetratorTestObj = new InvoiceGenerator();
        }

        [Test]
        public void GivenDistanceAndTime_ShouldReturn_TotalFare()
        {
            double expected = 25;
            
            double result = invoiceGenetratorTestObj.CalculateFare(2, 5);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GivenInvalidDistance_ShouldThrow_CabInvoiceException()
        {
            try
            {
               // InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
                double result = invoiceGenetratorTestObj.CalculateFare(-2, 5);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Distance");
            }
        }
        [Test]
        public void GivenInvalidTime_ShouldThrow_CabInvoiceException()
        {
            try
            {
               // InvoiceGenerator invoiceGenetratorTestObj = new InvoiceGenerator();
                double result = invoiceGenetratorTestObj.CalculateFare(2, -5);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Time");
            }
        }
        [Test]
        public void GivenMultipleRides_ShouldReturn_TotalFare()
        {
            double expected = 32;
            Ride[] ridesTestObj = { new Ride(0.1, 2), new Ride(2, 2), new Ride(0.2, 2) };
            double result = invoiceGenetratorTestObj.CalculateFare(ridesTestObj);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GivenNullRides_ShouldThrow_CabInvoiceException()
        {
            try
            {
                Ride[] ridesTestObj = null;
                double result = invoiceGenetratorTestObj.CalculateFare(ridesTestObj);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Rides Are Null");
            }
        }
    }
}