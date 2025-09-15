using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
        public class FeaturedProduct
        {
            [Key]
        public int Featured_ID { get; set; }

        [Required]
        public int Product_ID { get; set; }

        [ForeignKey("Product_ID")]
        public Product Product { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int Priority { get; set; }
        }

 }