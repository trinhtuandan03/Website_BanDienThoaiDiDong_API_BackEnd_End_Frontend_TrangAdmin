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
    public class CartsApiController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartsApiController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartsDto>>> GetCarts()
        {
            var carts = await _cartRepository.GetCartsAsync();
            var cartDtos = carts.Select(c => new CartsDto
            {
                Id = c.Id,
                UserId = c.UserId,
                PaymentMethod = c.PaymentMethod,
                CreatedAt = c.CreatedAt,         
            });
            return Ok(cartDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartsDto>> GetCart(int id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            var cartDto = new CartsDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                PaymentMethod = cart.PaymentMethod,
                CreatedAt = cart.CreatedAt,            
            };

            return Ok(cartDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, CartsDto cartDto)
        {
            if (id != cartDto.Id)
            {
                return BadRequest();
            }

            var existingCart = await _cartRepository.GetCartByIdAsync(id);
            if (existingCart == null)
            {
                return NotFound();
            }

            existingCart.UserId = cartDto.UserId;
            existingCart.PaymentMethod = cartDto.PaymentMethod;

            await _cartRepository.UpdateCartAsync(existingCart);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CartsDto>> PostCart(CartsDto cartDto)
        {
            var cart = new Cart
            {
                UserId = cartDto.UserId,
                PaymentMethod = cartDto.PaymentMethod
            };

            await _cartRepository.AddCartAsync(cart);

            cartDto.Id = cart.Id;
            return CreatedAtAction(nameof(GetCart), new { id = cartDto.Id }, cartDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _cartRepository.DeleteCartAsync(id);
            return NoContent();
        }
    }
}
