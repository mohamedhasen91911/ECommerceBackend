using System.Runtime.CompilerServices;
using AutoMapper;
using Backend.DTO.Shipping;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingsController : ControllerBase
    {
        private readonly ShippingService service;
        private readonly IMapper mapper;
        public ShippingsController(ShippingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shippings = await service.GetShippings();
            var result = mapper.Map<IEnumerable<ShippingReadDto>>(shippings);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var shipping = await service.GetShipping(id);
            if (shipping == null) return NotFound();
            return Ok(mapper.Map<ShippingReadDto>(shipping));
        }
        [HttpPost]
        public async Task<IActionResult> Add(ShippingCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var shipping = mapper.Map<Shipping>(dto);
            await service.AddShipping(shipping);

            var readDto = mapper.Map<ShippingReadDto>(shipping);
            return CreatedAtAction(nameof(Get), new { id = shipping.Shipping_ID }, readDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ShippingUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var existing = await service.GetShipping(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);
            await service.UpdateShipping(existing);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await service.GetShipping(id);
            if (existing == null) return NotFound();

            await service.DeleteShipping(id);
            return NoContent();
         }
         






    }
 }