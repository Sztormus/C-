using StrategyPattern.Models;

namespace StrategyPattern.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}
