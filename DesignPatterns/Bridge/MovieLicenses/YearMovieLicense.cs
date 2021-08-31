using System;
using BridgePattern.Interfaces;

namespace BridgePattern.MovieLicenses
{
    public class YearMovieLicense : MovieLicense
    {
        public YearMovieLicense(string movie, DateTime purchaseTime, IDiscount discount) 
            : base(movie, purchaseTime, discount)
        { }

        public override DateTime GetExpirationDate()
        {
            return PurchaseTime.AddYears(1);
        }

        protected override decimal GetFullPrice()
        {
            return 25;
        }
    }
}