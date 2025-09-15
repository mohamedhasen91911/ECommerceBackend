namespace Backend.DTO.Cart
{
    public class CartItemReadDto
    {
        public int CartItem_ID { get; set; }
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}