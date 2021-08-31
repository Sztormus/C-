using BridgePattern.Interfaces;

namespace BridgePattern.Discounts
{
    public class SeniorDiscount : IDiscount
    {
        public int GetDiscount() => 20;
    }
}