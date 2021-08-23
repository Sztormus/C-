using System;
using System.Net.Http;
using Newtonsoft.Json;
using StrategyPattern.Models;

namespace StrategyPattern.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using var client = new HttpClient();
            var content = JsonConvert.SerializeObject(order);

            client.BaseAddress = new Uri("https://pluralsight.com");

            client.PostAsync("/print-on-demand", new StringContent(content));

            Console.WriteLine($"Invoice sent for printing");
        }
    }
}
