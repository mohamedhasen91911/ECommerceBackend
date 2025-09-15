using AutoMapper;
using Backend.DTO.Payment;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService service;
        private readonly IMapper mapper;

        public PaymentsController(PaymentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var payment = mapper.Map<Payment>(dto);
            await service.AddPayment(payment);

            var readDto = mapper.Map<PaymentReadDto>(payment);

            return CreatedAtAction(nameof(Get), new { id = payment.Payment_ID }, readDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var payment = await service.GetPayment(id);
            if (payment == null) return NotFound();

            var dto = mapper.Map<PaymentReadDto>(payment);
            return Ok(dto);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
        {
            var payment = await service.GetPaymentByOrder(orderId);
            if (payment == null) return NotFound();

            var dto = mapper.Map<PaymentReadDto>(payment);
            return Ok(dto);

         }

    }
 }