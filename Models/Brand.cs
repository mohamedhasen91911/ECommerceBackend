using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public class Brand
        {
            [Key]
            public int Brand_ID { get; set; }

            [Required, StringLength(50)]
            public string Brand_Name { get; set; }

            [StringLength(100)]
            public string Country { get; set; }

            // Navigation
            public ICollection<Product> Products { get; set; } = new List<Product>();
        }

}