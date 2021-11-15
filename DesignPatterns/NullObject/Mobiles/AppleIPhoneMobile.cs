using NullObjectPattern.Interfaces;

namespace NullObjectPattern.Mobiles
{
    internal class AppleIPhoneMobile : IMobile
    {
        public void TurnOff()
        {
            Console.WriteLine("\nApple IPhone Turned OFF!");
        }

        public void TurnOn()
        {
            Console.WriteLine("\nApple IPhone Turned ON!");
        }
    }
}
