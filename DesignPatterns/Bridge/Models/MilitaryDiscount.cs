using BridgePattern.Interfaces;

namespace BridgePattern.Models
{
    public class MilitaryDiscount : IDiscount
    {
        public int GetDiscount() => 10;
    }
}