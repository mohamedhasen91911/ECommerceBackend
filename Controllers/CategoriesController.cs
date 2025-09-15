using AutoMapper;
using Backend.DTO.Cateogy;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService service;
        private readonly IMapper mapper;

        public CategoriesController(CategoryService service, IMapper mapper)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await service.GetCategories();
            var result = mapper.Map<IEnumerable<CategoryReadDto>>(categories);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await service.GetCategory(id);
            if (category == null) return NotFound();
            var dto = mapper.Map<CategoryCreateDto>(category);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = mapper.Map<Category>(dto);
            await service.AddCategory(category);

            var readDto = mapper.Map<CategoryReadDto>(category);

            return CreatedAtAction(nameof(Get), new { id = category.Category_ID }, readDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var existing = await service.GetCategory(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);
            await service.UpdateCategory(existing);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await service.GetCategory(id);
            if (existing == null) return NotFound();

            await service.DeleteCategory(id);
            return NoContent();
         }
         



    }
 }