namespace StrategyPattern.Models
{
    public class ShippingDetails
    {
        public string Receiver { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public string DestinationCountry { get; init; }
        public string DestinationState { get; set; }

        public string OriginCountry { get; init; }
        public string OriginState { get; set; }
    }
}