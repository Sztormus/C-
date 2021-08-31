using BridgePattern.Interfaces;

namespace BridgePattern.Discounts
{
    public class NoDiscount : IDiscount
    {
        public int GetDiscount() => 0;
    }
}