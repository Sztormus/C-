using StrategyPattern.Enums;

namespace StrategyPattern.Models
{
    public class Payment
    {
        public decimal Amount { get; }
        public PaymentProvider PaymentProvider { get; init; }
    }
}