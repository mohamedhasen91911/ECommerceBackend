namespace Backend.DTO.Wishlist
{
    public class WishlistReadDto
    {
        public int Wishlist_ID { get; set; }
        public int User_ID { get; set; }
        public List<WishlistItemReadDto> WishlistItems { get; set; }
    }
 }