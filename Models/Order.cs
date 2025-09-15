using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Order
    {
        [Key]
        public int Order_ID { get; set; }

        public DateTime Order_Date { get; set; } = DateTime.Now;

        [Required]
        [RegularExpression("Pending|Confirmed|Shipped|Delivered|Cancelled",
         ErrorMessage = "Invalid order status.")]
        public string Status { get; set; }

        [Required]
        public int Customer_ID { get; set; }
        [ForeignKey("Customer_ID")]
        public User Customer { get; set; }

        // Navigation
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public Payment Payment { get; set; }
        public Shipping Shipping { get; set; }
    }
 }

