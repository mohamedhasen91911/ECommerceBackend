using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class WishlistItem
    {
        [Key]
        public int WishlistItem_ID { get; set; }

        [Required]
        public int Wishlist_ID { get; set; }
        [ForeignKey("Wishlist_ID")]
        public Wishlist Wishlist { get; set; }

        [Required]
        public int Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public Product Product { get; set; }
    }
 }