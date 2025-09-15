using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
        public class StockHistory
    {
        [Key]
        public int StockHistory_ID { get; set; }

        [Required]
        public int Product_ID { get; set; }

        [ForeignKey("Product_ID")]
        public Product Product { get; set; }

        [Required]
        public int Change { get; set; } // +10 (new stock), -2 (sale), +1 (return)

        [Required]
        public string Reason { get; set; } // "New stock", "Sale", "Return", "Correction"

        public DateTime Date { get; set; } = DateTime.Now;
    }

 }