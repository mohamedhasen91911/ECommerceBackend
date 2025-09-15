using AutoMapper;
using Backend.DTO.Featured;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturedController : ControllerBase
    {
        private readonly FeaturedService service;
        private readonly IMapper mapper;

        public FeaturedController(FeaturedService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await service.GetAll();
            var dto = mapper.Map<IEnumerable<FeaturedReadDto>>(list);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var featured = await service.Get(id);
            if (featured == null) return NotFound();
            var dto = mapper.Map<FeaturedReadDto>(featured);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FeaturedCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = mapper.Map<FeaturedProduct>(dto);
            await service.Add(entity);

            var readDto = mapper.Map<FeaturedReadDto>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Featured_ID }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FeaturedUpdateDto dto)
        {
            var existing = await service.Get(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);
            await service.Update(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return NoContent();
        }
    }
 }