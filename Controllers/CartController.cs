using AutoMapper;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly CartService service;
        public CartController(IMapper mapper, CartService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await service.GetCart(userId);
            if (cart == null) return NotFound();

            var dto = mapper.Map<CartReadDto>(cart);
            return Ok(dto);

        }

        [HttpPost("{userId}/items")]
        public async Task<IActionResult> AddItem(int userId, CartItemCreateDto dto)
        {
            var item = mapper.Map<CartItem>(dto);
            await service.AddItem(userId, item);
            return Ok();
        }

        [HttpDelete("{userId}/items/{itemId}")]
        public async Task<IActionResult> RemoveItem(int userId, int itemId)
        {
            await service.RemoveItem(userId, itemId);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            await service.ClearCart(userId);
            return NoContent();
         }
        
        











     }
 }