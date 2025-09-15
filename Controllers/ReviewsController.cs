using AutoMapper;
using Backend.DTO.Review;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ReviewService service;

        public ReviewsController(IMapper mapper, ReviewService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var reviews = await service.GetReviewsByProduct(productId);
            var result = mapper.Map<IEnumerable<ReviewReadDto>>(reviews);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var existing = await service.GetReview(id);
            if (existing == null) return BadRequest();

            var result = mapper.Map<ReviewReadDto>(existing);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var review = mapper.Map<Review>(dto);
            await service.AddReview(review);

            var readDto = mapper.Map<ReviewReadDto>(review);
            return CreatedAtAction(nameof(GetByProduct), new { productId = review.Product_ID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReviewUpdateDto dto)
        {
            var existing = await service.GetReview(id);
            if (existing == null) return NotFound();

            mapper.Map(dto, existing);
            await service.UpdateReview(existing);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await service.GetReview(id);
            if (existing == null) return NotFound();
            await service.DeleteReview(id);
            return NoContent();
         }

    }
 }