using System;
using BridgePattern.Interfaces;

namespace BridgePattern.Models
{
    public abstract class MovieLicense
    {
        private readonly IDiscount _discount;
        
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        protected MovieLicense(string movie, DateTime purchaseTime, IDiscount discount)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
        }

        public decimal GetPrice()
        {
            var multiplier = 1 - _discount.GetDiscount() / 100m;
            return multiplier * GetFullPrice();
        }
        
        public abstract DateTime GetExpirationDate();
        protected abstract decimal GetFullPrice();
    }
}