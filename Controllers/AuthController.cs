using Backend.DTO.Auth;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(UserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var existing = await _userService.GetByEmail(dto.Email);
            if (existing != null) return BadRequest("Email already exists");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role,
                Phone = dto.Phone ?? ""
            };

            await _userService.AddUser(user);
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userService.GetByEmail(dto.Email);
            if (user == null) return Unauthorized("Invalid email or password");

            bool validPass = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!validPass) return Unauthorized("Invalid email or password");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}