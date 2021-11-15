using NullObjectPattern.Interfaces;

namespace NullObjectPattern.Mobiles
{
    internal class SamsungGalaxyMobile : IMobile
    {
        public void TurnOff()
        {
            Console.WriteLine("\nSamsung Galaxy Turned OFF!");
        }

        public void TurnOn()
        {
            Console.WriteLine("\nSamsung Galaxy Turned ON!");
        }
    }
}
