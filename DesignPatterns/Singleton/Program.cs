using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SingletonPattern.Helpers;
using SingletonPattern.Singletons;

namespace SingletonPattern
{
    public static class Program
    {
        public static void Main()
        {
            Signature.Sign("Singleton Pattern", "Author: Piotr Stefaniak", "Based on Pluralsight course");
            Console.WriteLine();

            var singletonInstance = Singleton.Instance;
            
            singletonInstance.PrintNumberOfCalls();
            singletonInstance.PrintNumberOfCalls();
            singletonInstance.PrintNumberOfCalls();

            var singletonList = new List<Singleton>
            {
                Singleton.Instance,
                Singleton.Instance,
                Singleton.Instance
            };
            Parallel.ForEach(singletonList, element => element.PrintNumberOfCalls());
        }
    }
}
