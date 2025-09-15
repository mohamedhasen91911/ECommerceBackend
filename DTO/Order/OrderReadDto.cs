namespace Backend.DTO.Order
{
    public class OrderReadDto
    {
        public int Order_ID { get; set; }
        public DateTime Order_Date { get; set; }
        public string Status { get; set; }

        public string CustomerName { get; set; }
        public List<OrderDetailDto> Items { get; set; } = new();
        public PaymentDto Payment { get; set; }
        public ShippingDto Shipping { get; set; }


    }

    public class OrderDetailDto
    {
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_Price { get; set; }

    }

    public class PaymentDto
    {
        public int Payment_ID { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Method { get; set; }
        public DateTime Payment_Date { get; set; }
    }
    public class ShippingDto
    {
        public int Shipping_ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string TrackingNumber { get; set; }
        public string ShippingStatus { get; set; }
     }
 }