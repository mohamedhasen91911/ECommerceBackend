namespace Backend.DTO.Auth
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Customer";
        public string? Phone { get; set; }
    }
 }