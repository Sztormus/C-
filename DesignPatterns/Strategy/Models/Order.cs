using System;
using System.Collections.Generic;
using System.Linq;
using StrategyPattern.Enums;
using StrategyPattern.Strategies.Invoice;
using StrategyPattern.Strategies.SalesTax;
using StrategyPattern.Strategies.Shipping;

namespace StrategyPattern.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new();
        public IList<Payment> SelectedPayments { get; } = new List<Payment>();
        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);
        public ShippingDetails ShippingDetails { get; init; }
        public ISalesTaxStrategy SalesTaxStrategy { get; init; }
        public IInvoiceStrategy InvoiceStrategy { get; init; }
        public IShippingStrategy ShippingStrategy { get; init; }
        
        private ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;
        private IEnumerable<Payment> FinalizedPayments { get; } = new List<Payment>();
        private decimal AmountDue => TotalPrice - FinalizedPayments.Sum(payment => payment.Amount);

        public decimal GetTax()
        {
            return SalesTaxStrategy?.GetTaxFor(this) ?? 0m;
        }

        public void FinalizeOrder()
        {
            if(SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice) &&
               AmountDue > 0 && 
               ShippingStatus == ShippingStatus.WaitingForPayment)
            {
                InvoiceStrategy.Generate(this);

                ShippingStatus = ShippingStatus.ReadyForShipment;
            }
            else if(AmountDue > 0)
            {
                throw new Exception("Unable to finalize order");
            }

            ShippingStrategy.Ship(this);
        }
    }
}