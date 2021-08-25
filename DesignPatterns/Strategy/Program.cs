using StrategyPattern.Enums;
using StrategyPattern.Helpers;
using StrategyPattern.Models;
using StrategyPattern.Strategies.Invoice;
using StrategyPattern.Strategies.SalesTax;
using StrategyPattern.Strategies.Shipping;
using System;

namespace StrategyPattern
{
    public static class Program
    {
        public static void Main()
        {
            Signature.Sign("Strategy Pattern", "Author: Piotr Stefaniak", "Based on Pluralsight course");

            Console.WriteLine("\nPlease select an origin country: ");
            var origin = Console.ReadLine()?.Trim();

            Console.WriteLine("Please select a destination country: ");
            var destination = Console.ReadLine()?.Trim();

            var state = "";
            if (destination == "usa")
            {
                Console.WriteLine("Please select a destination state: ");
                state = Console.ReadLine()?.Trim();
            }

            Console.WriteLine("Choose one of the following shipping providers.");
            Console.WriteLine("1. PostNord (Swedish Postal Service)");
            Console.WriteLine("2. DHL");
            Console.WriteLine("3. USPS");
            Console.WriteLine("4. Fedex");
            Console.WriteLine("5. UPS");
            Console.WriteLine("Select shipping provider: ");
            var provider = Convert.ToInt32(Console.ReadLine()?.Trim());

            Console.WriteLine("Choose one of the following invoice delivery options.");
            Console.WriteLine("1. E-mail");
            Console.WriteLine("2. File (download later)");
            Console.WriteLine("3. Mail");
            Console.WriteLine("Select invoice delivery options: ");
            var invoiceOption = Convert.ToInt32(Console.ReadLine()?.Trim());

            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    DestinationCountry = destination,
                    DestinationState = state
                },
                SalesTaxStrategy = GetSalesTaxStrategyFor(origin),
                InvoiceStrategy = GetInvoiceStrategyFor(invoiceOption),
                ShippingStrategy = GetShippingStrategyFor(provider)
            };

            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);

            Console.WriteLine("Tax:");
            Console.WriteLine(order.GetTax());

            order.FinalizeOrder();
        }

        private static IInvoiceStrategy GetInvoiceStrategyFor(int option)
        {
            return option switch
            {
                1 => new EmailInvoiceStrategy(),
                2 => new FileInvoiceStrategy(),
                3 => new PrintOnDemandInvoiceStrategy(),
                _ => throw new Exception("Unsupported invoice delivery option")
            };
        }

        private static IShippingStrategy GetShippingStrategyFor(int provider)
        {
            return provider switch
            {
                1 => new SwedishPostalServiceShippingStrategy(),
                2 => new DhlShippingStrategy(),
                3 => new UnitedStatesPostalServiceShippingStrategy(),
                4 => new FedexShippingStrategy(),
                5 => new UpsShippingStrategy(),
                _ => throw new Exception("Unsupported shipping method")
            };
        }

        private static ISalesTaxStrategy GetSalesTaxStrategyFor(string origin)
        {
            return origin.ToLowerInvariant() switch
            {
                "sweden" => new SwedenSalesTaxStrategy(),
                "usa" => new USAStateSalesTaxStrategy(),
                _ => throw new Exception("Unsupported shipping region")
            };
        }
    }
}