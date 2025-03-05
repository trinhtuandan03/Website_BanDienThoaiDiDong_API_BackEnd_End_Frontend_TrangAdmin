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
    public class OrderDetailApiController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailApiController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetOrderDetails()
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailsAsync();
            var orderDetailDtos = orderDetails.Select(detail => new OrderDetailDto
            {
                Id = detail.Id,
                OrderId = detail.OrderId,
                ProductId = detail.ProductId,
                ProductPrice = detail.Price,
                Quantity = detail.Quantity,
            });
            return Ok(orderDetailDtos);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetailDto>> PostOrderDetail(OrderDetailDto orderDetailDto)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = orderDetailDto.OrderId,
                ProductId = orderDetailDto.ProductId,
                Price = orderDetailDto.ProductPrice,
                Quantity = orderDetailDto.Quantity
            };

            await _orderDetailRepository.AddOrderDetailAsync(orderDetail);

            orderDetailDto.Id = orderDetail.Id;
            return CreatedAtAction(nameof(GetOrderDetails), new { id = orderDetailDto.Id }, orderDetailDto);
        }

        [HttpGet("by-order/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailsAsync();
            var filteredDetails = orderDetails.Where(od => od.OrderId == orderId);

            if (!filteredDetails.Any())
            {
                return NotFound("Không tìm thấy chi tiết đơn hàng.");
            }

            var orderDetailDtos = filteredDetails.Select(od => new OrderDetailDto
            {
                Id = od.Id,
                OrderId = od.OrderId,
                ProductId = od.ProductId,
                ProductPrice = od.Price,
                Quantity = od.Quantity,
            });

            return Ok(orderDetailDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDto>> GetOrderDetail(int id)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailByIdAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            var orderDetailDto = new OrderDetailDto
            {
                Id = orderDetail.Id,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                ProductPrice = orderDetail.Price,
                Quantity = orderDetail.Quantity,
            };

            return Ok(orderDetailDto);
        }
    }
}
