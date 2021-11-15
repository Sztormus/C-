using NullObjectPattern.Interfaces;

namespace NullObjectPattern.Mobiles
{
    internal class SonyXperiaMobile : IMobile
    {
        public void TurnOff()
        {
            Console.WriteLine("\nSony Xperia Turned OFF!");
        }

        public void TurnOn()
        {
            Console.WriteLine("\nSony Xperia Turned ON!");
        }
    }
}
