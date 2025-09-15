namespace Backend.DTO.Order
{
    public class OrderCreateDto
    {
        public int Customer_ID { get; set; }
        public List<OrderItemDto> Items { get; set; }

    }
    public class OrderItemDto
    {
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
     }
 }