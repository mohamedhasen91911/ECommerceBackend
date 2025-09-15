using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&]).+$",
         ErrorMessage = "Password must contain letters, numbers, and special characters.")]
        public string Password { get; set; }

        [Phone, StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [RegularExpression("Customer|Merchant|Admin",
         ErrorMessage = "Role must be either Customer, Merchant, or Admin")]
        public string Role { get; set; }

        // Navigation
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ShoppingCart ShoppingCart { get; set; }

     }
 }