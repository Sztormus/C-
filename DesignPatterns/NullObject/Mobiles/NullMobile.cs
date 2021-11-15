using NullObjectPattern.Interfaces;

namespace NullObjectPattern.Mobiles
{
    internal class NullMobile : IMobile
    {
        private static readonly Lazy<NullMobile> _lazy = new(() => new NullMobile());

        public static NullMobile Instance => _lazy.Value;

        private NullMobile()
        { }

        public void TurnOff()
        { }

        public void TurnOn()
        { }
    }
}
