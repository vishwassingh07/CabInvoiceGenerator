﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;
        
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceCustomException)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }
        public Ride[] getRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }

    }
}
