using System;
using StrategyPattern.Models;

namespace StrategyPattern.Strategies.Shipping
{
    public class UpsShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            Console.WriteLine("Order is shipped with UPS");
        }
    }
}
