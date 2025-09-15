using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public class Category
        {
            [Key]
            public int Category_ID { get; set; }

            [Required, StringLength(50)]
            public string Category_Name { get; set; }

            // Navigation
            public ICollection<Product> Products { get; set; } = new List<Product>();
        }

 }