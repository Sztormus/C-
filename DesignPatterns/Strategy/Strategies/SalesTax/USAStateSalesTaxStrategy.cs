using StrategyPattern.Models;

namespace StrategyPattern.Strategies.SalesTax
{
    public class USAStateSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var totalPrice = order.TotalPrice;

            return order.ShippingDetails.DestinationState.ToLowerInvariant() switch
            {
                "la" => totalPrice * 0.095m,
                "ny" => totalPrice * 0.04m,
                "nyc" => totalPrice * 0.045m,
                _ => 0m
            };
        }
    }
}
