using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        public RideType rideType;
        //Constants
        public readonly double MINIMUM_COST_PER_KM;
        public readonly int COST_PER_MIN;
        public readonly double MINIMUM_FARE;

       public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            if (RideType.NORMAL == rideType)
            {
                MINIMUM_COST_PER_KM = 10;
                COST_PER_MIN = 1;
                MINIMUM_FARE = 5;
            }
            else
            {
                MINIMUM_COST_PER_KM = 15;
                COST_PER_MIN = 2;
                MINIMUM_FARE = 20;
            }
        }
        public double CalculateTotalFare(double distance, int time)
        {
            try
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Distance is invalid");
                }
                else if (time <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_TIME, "Time is invalid");
                }
                else {
                    double totalFare = 0;
                    totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_MIN;
                    return Math.Max(totalFare, MINIMUM_FARE);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
