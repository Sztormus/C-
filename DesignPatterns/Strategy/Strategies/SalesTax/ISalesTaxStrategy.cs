using StrategyPattern.Models;

namespace StrategyPattern.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}