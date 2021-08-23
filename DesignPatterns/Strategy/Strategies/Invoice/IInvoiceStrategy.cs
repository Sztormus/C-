using StrategyPattern.Models;

namespace StrategyPattern.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}