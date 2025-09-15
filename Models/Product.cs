using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

        [Required, StringLength(100)]
        public string Product_Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required, Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        [Required]
        public int Merchant_ID { get; set; }
        [ForeignKey("Merchant_ID")]
        public User Merchant { get; set; }

        [Required]
        public int Category_ID { get; set; }
        [ForeignKey("Category_ID")]
        public Category Category { get; set; }

        [Required]
        public int Brand_ID { get; set; }
        [ForeignKey("Brand_ID")]
        public Brand Brand { get; set; }

        // Navigation
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
 }