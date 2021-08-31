using System;
using BridgePattern.Interfaces;

namespace BridgePattern.MovieLicenses
{
    public class TwoDaysMovieLicense : MovieLicense
    {
        public TwoDaysMovieLicense(string movie, DateTime purchaseTime, IDiscount discount) 
            : base(movie, purchaseTime, discount)
        { }

        public override DateTime GetExpirationDate()
        {
            return PurchaseTime.AddDays(2);
        }

        protected override decimal GetFullPrice()
        {
            return 1;
        }
    }
}