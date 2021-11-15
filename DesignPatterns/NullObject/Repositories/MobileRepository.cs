using NullObjectPattern.Interfaces;
using NullObjectPattern.Mobiles;

namespace NullObjectPattern.Repositories
{
    internal static class MobileRepository
    {
        public static IMobile GetMobileByName(string mobileName)
        {
            IMobile mobile = NullMobile.Instance;
            switch (mobileName)
            {
                case "Sony":
                    mobile = new SonyXperiaMobile();
                    break;

                case "Apple":
                    mobile = new AppleIPhoneMobile();
                    break;

                case "Samsung":
                    mobile = new SamsungGalaxyMobile();
                    break;
            }
            return mobile;
        }
    }
}
