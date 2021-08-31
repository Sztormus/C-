using BridgePattern.Interfaces;

namespace BridgePattern.Models
{
    public class NoDiscount : IDiscount
    {
        public int GetDiscount() => 0;
    }
}