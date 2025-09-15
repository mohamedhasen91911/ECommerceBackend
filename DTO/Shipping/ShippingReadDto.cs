namespace Backend.DTO.Shipping

{
    public class ShippingReadDto
    {
        public int Shipping_ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string TrackingNumber { get; set; }
        public string ShippingStatus { get; set; }
        public int Order_ID { get; set; }
     }
 }