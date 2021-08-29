using System;

namespace SingletonPattern.Singletons
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> Lazy = new Lazy<Singleton>(() => new Singleton());

        private int _count = 0;
        
        public static Singleton Instance
        {
            get
            {
                Console.WriteLine("Instance called.");
                return Lazy.Value;
            }
        }

        public void PrintNumberOfCalls()
        {
            Console.WriteLine($"Function has been called {++_count} times");
        }

        private Singleton()
        {
            Console.WriteLine("Singleton has been created.");
        }
    }
}