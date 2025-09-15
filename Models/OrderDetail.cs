using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
        public class OrderDetail
        {
            [Key, Column(Order = 0)]
            public int Order_ID { get; set; }

            [Key, Column(Order = 1)]
            public int Product_ID { get; set; }

            [Required, Range(1, int.MaxValue)]
            public int Quantity { get; set; }

            [Required, Range(0.01, 100000)]
            public decimal Unit_Price { get; set; }

            // Navigation
            public Order Order { get; set; }
            public Product Product { get; set; }
        }

 }