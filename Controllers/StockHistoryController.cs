using AutoMapper;
using Backend.DTO.StockHistory;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class StockHistoryController : ControllerBase
    {
        private readonly StockHistoryService service;
        private readonly IMapper mapper;

        public StockHistoryController(StockHistoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await service.GetAll();
            var dto = mapper.Map<IEnumerable<StockHistoryReadDto>>(list);
            return Ok(dto);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var list = await service.GetByProductId(productId);
            var dto = mapper.Map<IEnumerable<StockHistoryReadDto>>(list);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StockHistoryCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = mapper.Map<StockHistory>(dto);
            await service.Add(entity);

            var readDto = mapper.Map<StockHistoryReadDto>(entity);
            return CreatedAtAction(nameof(GetByProduct), new { productId = entity.Product_ID }, readDto);
        }
    }
 }