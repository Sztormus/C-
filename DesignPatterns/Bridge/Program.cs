using System;
using BridgePattern.Discounts;
using BridgePattern.Helpers;
using BridgePattern.MovieLicenses;

namespace BridgePattern
{
    public static class Program
    {
        public static void Main()
        {
            Signature.Sign("Bridge Pattern", "Author: Piotr Stefaniak", "Based on Pluralsight course");
            Console.WriteLine();

            var now = DateTime.Now;
            var noDiscount = new NoDiscount();

            Console.WriteLine("Creating TwoDaysMovieLicense with NoDiscount");
            var twoDaysMovieLicenseNoDiscount = new TwoDaysMovieLicense("Frozen", now, noDiscount);
            PrintLicenseDetails(twoDaysMovieLicenseNoDiscount);

            Console.WriteLine("Creating YearMovieLicense with NoDiscount");
            var yearMovieLicenseNoDiscount = new YearMovieLicense("Matrix", now, noDiscount);
            PrintLicenseDetails(yearMovieLicenseNoDiscount);

            var seniorDiscount = new SeniorDiscount();
            var militaryDiscount = new MilitaryDiscount();
            
            Console.WriteLine("Creating TwoDaysMovieLicense with SeniorDiscount");
            var twoDaysMovieLicenseSeniorDiscount = new TwoDaysMovieLicense("Frozen", now, seniorDiscount);
            PrintLicenseDetails(twoDaysMovieLicenseSeniorDiscount);
            
            Console.WriteLine("Creating YearMovieLicense with MilitaryDiscount");
            var yearMovieLicenseMilitaryDiscount = new YearMovieLicense("Matrix", now, militaryDiscount);
            PrintLicenseDetails(yearMovieLicenseMilitaryDiscount);
            
            Console.WriteLine("Thanks to Bridge pattern both MovieLicense and Discount entities can exist independently.");
            Console.WriteLine();
            
            Console.WriteLine("Bridge pattern allow us to split a class hierarchy");
            Console.WriteLine("through composition to reduce coupling.");
        }
        
        private static void PrintLicenseDetails(MovieLicense license)
        {
            Console.WriteLine($"Movie: {license.Movie}");
            Console.WriteLine($"Price: {GetPrice(license)}");
            Console.WriteLine($"Valid for: {GetValidFor(license)}");

            Console.WriteLine();
        }
        
        private static string GetPrice(MovieLicense license)
        {
            return $"${license.GetPrice():0.00}";
        }

        private static string GetValidFor(MovieLicense license)
        {
            var expirationDate = license.GetExpirationDate();
            var timeSpan = expirationDate - DateTime.Now;

            return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }
    }
}