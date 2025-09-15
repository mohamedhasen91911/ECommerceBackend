using AutoMapper;
using Backend.DTO.Wishlist;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistService service;
        private readonly IMapper mapper;

        public WishlistController(WishlistService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWishlist(int userId)
        {
            var wishlist = await service.GetWishlist(userId);
            if (wishlist == null) return NotFound();

            var dto = mapper.Map<WishlistReadDto>(wishlist);
            return Ok(dto);
        }

        [HttpPost("{userId}/items")]
        public async Task<IActionResult> AddItem(int userId, WishlistItemCreateDto dto)
        {
            var item = mapper.Map<WishlistItem>(dto);
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
        public async Task<IActionResult> ClearWishlist(int userId)
        {
            await service.ClearWishlist(userId);
            return NoContent();
        }
    }
 }