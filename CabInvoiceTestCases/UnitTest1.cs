using System;
using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceTestCases
{
   public class CabInvoiceTests
    {
        InvoiceGenerator invoiceGenerator;
        [SetUp]
        //Test Case 1 : For Normal Ride
        public void SetUp()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
        }
        [Test]
        public void GivenDistanceAndTimeReturnTotalFare()
        {
            //Arrange
            double distance = 2;
            int time = 5;
            double expectedFare = 25;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            //Arrange
            double actualFare = invoiceGenerator.CalculateTotalFare(distance, time);

            //Act
            Assert.AreEqual(expectedFare, actualFare);
        }

    }
}