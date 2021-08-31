using BridgePattern.Interfaces;

namespace BridgePattern.Discounts
{
    public class MilitaryDiscount : IDiscount
    {
        public int GetDiscount() => 10;
    }
}