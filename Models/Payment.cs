using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public class Payment
        {
            [Key]
            public int Payment_ID { get; set; }

            public DateTime Payment_Date { get; set; } = DateTime.Now;

            [Required, Range(0.01, 100000)]
            public decimal Amount { get; set; }

            [Required]
            [RegularExpression("Card|Wallet|COD", ErrorMessage = "Invalid payment method.")]
            public string Payment_Method { get; set; }

            // FK
            [Required]
            public int Order_ID { get; set; }
            public Order Order { get; set; }
        }

 }