using AutoMapper;
using Backend.DTO.Brand;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly BrandService service;
        public BrandsController(IMapper mapper, BrandService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await service.GetBrands();
            var result = mapper.Map<IEnumerable<BrandReadDto>>(brands);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await service.GetBrand(id);
            if (brand == null) return NotFound();
            var dto = mapper.Map<BrandReadDto>(brand);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var brand = mapper.Map<Brand>(dto);
            await service.AddBrand(brand);

            var readDto = mapper.Map<BrandReadDto>(brand);
            return CreatedAtAction(nameof(Get), new { id = brand.Brand_ID }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BrandUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existing = await service.GetBrand(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);
            await service.UpdateBrand(existing);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await service.GetBrand(id);
            if (existing == null) return NotFound();

            await service.DeleteBrand(id);
            return NoContent();

        }
    }
 }