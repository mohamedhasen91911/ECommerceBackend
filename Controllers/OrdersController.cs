using AutoMapper;
using Backend.DTO.Order;
using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService service;
        private readonly IMapper mapper;

        public OrdersController(OrderService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await service.GetOrders();
            var result = mapper.Map<IEnumerable<OrderListDto>>(orders);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await service.GetOrder(id);
            if (order == null) return NotFound();

            var dto = mapper.Map<OrderReadDto>(order);
            return Ok(dto);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var orders = await service.GetCustomerOrders(customerId);
            var result = mapper.Map<IEnumerable<OrderListDto>>(orders);
            return Ok(result);
        }

        [HttpGet("merchant/{merchantId}")]
        public async Task<IActionResult> GetByMerchant(int merchantId)
        {
            var orders = await service.GetMerchantOrders(merchantId);
            var result = mapper.Map<IEnumerable<OrderListDto>>(orders);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var order = mapper.Map<Order>(dto);
            order.Status = "Pending";
            order.Order_Date = DateTime.Now;

            await service.AddOrder(order);

            var created = await service.GetOrder(order.Order_ID);
            var readDto = mapper.Map<OrderReadDto>(created);

            return CreatedAtAction(nameof(Get), new { id = created.Order_ID }, readDto);

        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var existing = await service.GetOrder(id);
            if (existing == null) return NotFound();

            existing.Status = status;
            await service.UpdateOrder(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await service.GetOrder(id);
            if (existing == null) return NotFound();

            await service.DeleteOrder(id);
            return NoContent();

         }















    }
 }