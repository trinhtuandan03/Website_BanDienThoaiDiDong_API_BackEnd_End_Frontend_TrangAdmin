using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.DTOs;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.IRepositories;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
   
        // GET: api/ProductApi

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();

            var productDtos = products.Select(product => new ProductDto
            {   
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image1 = product.Image1,
                Image2 = product.Image2,
                Description = product.Description,
                CategoryId = product.CategoryId
            });

            return Ok(productDtos);
        }

        // GET: api/ProductApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image1 = product.Image1,
                Image2 = product.Image2,
                Description = product.Description,
                CategoryId = product.CategoryId
            };

            return Ok(productDto);
        }

        // POST: api/ProductApi
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Image1 = productDto.Image1,
                Image2 = productDto.Image2,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId
            };

            await _productRepository.AddProductAsync(product);

            productDto.Id = product.Id;

            return CreatedAtAction(nameof(GetProduct), new { id = productDto.Id }, productDto);
        }

        [Authorize(Roles = "Admin")]
        // PUT: api/ProductApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Image1 = productDto.Image1;
            existingProduct.Image2 = productDto.Image2;
            existingProduct.Description = productDto.Description;
            existingProduct.CategoryId = productDto.CategoryId;

            await _productRepository.UpdateProductAsync(existingProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
