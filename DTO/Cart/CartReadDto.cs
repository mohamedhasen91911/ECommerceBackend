using Backend.DTO.Cart;

public class CartReadDto
    {
        public int Cart_ID { get; set; }
        public int User_ID { get; set; }
        public List<CartItemReadDto> CartItems { get; set; }
    }