using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public class Review
        {
            [Key]
            public int Review_ID { get; set; }

            [Range(1, 5)]
            public int Rating { get; set; }

            [StringLength(500)]
            public string Comment { get; set; }

            public DateTime Review_Date { get; set; } = DateTime.Now;

            [Required]
            public int Customer_ID { get; set; }
            public User Customer { get; set; }

            [Required]
            public int Product_ID { get; set; }
            public Product Product { get; set; }
        }

 }