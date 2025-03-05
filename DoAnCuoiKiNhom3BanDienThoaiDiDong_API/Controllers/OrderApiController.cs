using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.DTOs;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.IRepositories;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApiController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            var orderDtos = orders.Select(order => new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                TotalPrice = order.TotalPrice,
                PaymentMethod = order.PaymentMethod,
                ShippingAddress = order.ShippingAddress
            });
            return Ok(orderDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                TotalPrice = order.TotalPrice,
                PaymentMethod = order.PaymentMethod,
                ShippingAddress = order.ShippingAddress,
            };

            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                UserId = orderDto.UserId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = orderDto.OrderStatus,
                TotalPrice = orderDto.TotalPrice,
                PaymentMethod = orderDto.PaymentMethod,
                ShippingAddress = orderDto.ShippingAddress
            };

            await _orderRepository.AddOrderAsync(order);

            orderDto.Id = order.Id;
            return CreatedAtAction(nameof(GetOrder), new { id = orderDto.Id }, orderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest();
            }

            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.OrderStatus = orderDto.OrderStatus;
            existingOrder.PaymentMethod = orderDto.PaymentMethod;
            existingOrder.ShippingAddress = orderDto.ShippingAddress;

            await _orderRepository.UpdateOrderAsync(existingOrder);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
