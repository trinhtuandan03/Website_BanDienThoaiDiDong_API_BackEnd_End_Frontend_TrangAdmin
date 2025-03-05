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
    public class CartDetailsApiController : ControllerBase
    {
        private readonly ICartDetailRepository _cartDetailRepository;

        public CartDetailsApiController(ICartDetailRepository cartDetailRepository)
        {
            _cartDetailRepository = cartDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetailDto>>> GetCartDetails()
        {
            var cartDetails = await _cartDetailRepository.GetCartDetailsAsync();
            var cartDetailDtos = cartDetails.Select(cd => new CartDetailDto
            {
                Id = cd.Id,
                CartId = cd.CartId,
                ProductId = cd.ProductId,
                Quantity = cd.Quantity,

            });
            return Ok(cartDetailDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetailDto>> GetCartDetail(int id)
        {
            var cartDetail = await _cartDetailRepository.GetCartDetailByIdAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            var cartDetailDto = new CartDetailDto
            {
                Id = cartDetail.Id,
                CartId = cartDetail.CartId,
                ProductId = cartDetail.ProductId,
                Quantity = cartDetail.Quantity,
            };

            return Ok(cartDetailDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetail(int id, CartDetailDto cartDetailDto)
        {
            if (id != cartDetailDto.Id)
            {
                return BadRequest();
            }

            var existingCartDetail = await _cartDetailRepository.GetCartDetailByIdAsync(id);
            if (existingCartDetail == null)
            {
                return NotFound();
            }

            existingCartDetail.CartId = cartDetailDto.CartId;
            existingCartDetail.ProductId = cartDetailDto.ProductId;
            existingCartDetail.Quantity = cartDetailDto.Quantity;

            await _cartDetailRepository.UpdateCartDetailAsync(existingCartDetail);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CartDetailDto>> PostCartDetail(CartDetailDto cartDetailDto)
        {
            var cartDetail = new CartDetail
            {
                CartId = cartDetailDto.CartId,
                ProductId = cartDetailDto.ProductId,
                Quantity = cartDetailDto.Quantity
            };

            await _cartDetailRepository.AddCartDetailAsync(cartDetail);

            cartDetailDto.Id = cartDetail.Id;
            return CreatedAtAction(nameof(GetCartDetail), new { id = cartDetailDto.Id }, cartDetailDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartDetail(int id)
        {
            await _cartDetailRepository.DeleteCartDetailAsync(id);
            return NoContent();
        }
    }
}
