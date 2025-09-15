using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Wishlist
    {
        [Key]
        public int Wishlist_ID { get; set; }

        [Required]
        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public User User { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
     }
 }