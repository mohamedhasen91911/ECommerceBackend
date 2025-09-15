using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class CartItem
    {
        [Key]
        public int CartItem_ID { get; set; }

        [Required]
        public int Cart_ID { get; set; }
        [ForeignKey("Cart_ID")]
        public ShoppingCart ShoppingCart { get; set; }

        [Required]
        public int Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public Product Product { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

 }