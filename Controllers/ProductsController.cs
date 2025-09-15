using AutoMapper;
using Backend.DTO.Product;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService service;
        private readonly IMapper mapper;
        public ProductsController(ProductService service , IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await service.GetProducts();
            var result = mapper.Map<IEnumerable<ProductListDto>>(products);
            return Ok(result);
         } 

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await service.GetProduct(id);
            if (product == null) return NotFound();

            var dto = mapper.Map<ProductReadDto>(product);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var product = mapper.Map<Product>(dto);
            await service.AddProduct(product);

            var created = await service.GetProduct(product.Product_ID);
            var readDto = mapper.Map<ProductReadDto>(created);

            return CreatedAtAction(nameof(Get), new { id = created.Product_ID }, readDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await service.GetProduct(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);

            await service.UpdateProduct(existing);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var existing = await service.GetProduct(id);
            if (existing == null) return NotFound();

            await service.DeleteProduct(id);
            return NoContent();
         }

    }
 }