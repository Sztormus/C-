using System;
using System.Net;
using System.Net.Mail;
using StrategyPattern.Models;

namespace StrategyPattern.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using var client = new SmtpClient("smtp.sendgrid.net", 587);
            var credentials = new NetworkCredential("USERNAME", "PASSWORD");
            client.Credentials = credentials;

            var mail = new MailMessage("YOUR EMAIL", "YOUR EMAIL")
            {
                Subject = "We've created an invoice for your order",
                Body = GenerateTextInvoice(order)
            };

            client.Send(mail);

            Console.WriteLine("Invoice for order sent over e-mail");
        }
    }
}
