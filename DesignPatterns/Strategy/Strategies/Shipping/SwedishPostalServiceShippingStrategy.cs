using System;
using StrategyPattern.Models;

namespace StrategyPattern.Strategies.Shipping
{
    public class SwedishPostalServiceShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            Console.WriteLine("Order is shipped with PostNord");
        }
    }
}
