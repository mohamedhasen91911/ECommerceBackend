using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
        public class ShoppingCart
    {
        [Key]
        public int Cart_ID { get; set; }

        [Required]
        public int User_ID { get; set; }

        [ForeignKey("User_ID")]
        public User User { get; set; }

        // Navigation
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

 }