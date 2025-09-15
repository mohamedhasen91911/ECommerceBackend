using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
        public class Shipping
        {
            [Key]
            public int Shipping_ID { get; set; }

            [Required, StringLength(200)]
            public string Address { get; set; }

            [Required, StringLength(50)]
            public string City { get; set; }

            [Required, StringLength(50)]
            public string Country { get; set; }

            [Required, StringLength(20)]
            public string PostalCode { get; set; }

            [StringLength(50)]
            public string TrackingNumber { get; set; }

            [Required]
            [RegularExpression("Pending|In Transit|Delivered|Returned",
            ErrorMessage = "Invalid shipping status.")]
            public string ShippingStatus { get; set; }

            // FK
            [Required]
            public int Order_ID { get; set; }
            public Order Order { get; set; }
        }

 }