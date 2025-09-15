using AutoMapper;
using Backend.DTO.Merchant;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarchentsController : ControllerBase
    {
        public readonly MerchantService service;
        private readonly IMapper mapper;
        public MarchentsController(MerchantService service , IMapper mapper) { this.service = service; this.mapper = mapper; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var merchants = await service.GetMerchants();
            var result = mapper.Map<IEnumerable<MerchantReadDto>>(merchants);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var merchant = await service.GetMerchant(id);
            if (merchant == null) return NotFound();
            var dto = mapper.Map<MerchantReadDto>(merchant);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MerchantCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var merchant = mapper.Map<User>(dto);
            await service.AddMerchant(merchant);
            var readDto = mapper.Map<MerchantReadDto>(merchant);
            return CreatedAtAction(nameof(Get), new { id = merchant.User_ID }, readDto);
         }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MerchantUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var existing = await service.GetMerchant(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);

            await service.UpdateMerchant(existing);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await service.GetMerchant(id);
            if (existing == null) return NotFound();
            await service.DeleteMerchant(id);
            return NoContent();
         }
    }
 }