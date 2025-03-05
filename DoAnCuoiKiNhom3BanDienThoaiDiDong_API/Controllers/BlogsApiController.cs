using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.DTOs;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.IRepositories;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsApiController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogsApiController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // GET: api/BlogsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDto>>> GetBlogs()
        {
            var blogs = await _blogRepository.GetBlogsAsync();

            var blogDtos = blogs.Select(blog => new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                AuthorId = blog.AuthorId,
                ImageUrl = blog.ImageUrl,
                Category = blog.Category
            });

            return Ok(blogs);
        }

        // GET: api/BlogsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDto>> GetBlog(int id)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            var blogDto = new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                AuthorId = blog.AuthorId,
                ImageUrl = blog.ImageUrl,
                Category = blog.Category
            };

            return Ok(blog);
        }

        // PUT: api/BlogsApi/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<BlogDto>> PutBlog(int id, BlogDto blogDto)
        {
            var existingBlog = await _blogRepository.GetBlogByIdAsync(id);

            if (existingBlog == null)
            {
                return NotFound();
            }

            existingBlog.Title = blogDto.Title;
            existingBlog.Content = blogDto.Content;
            existingBlog.AuthorId = blogDto.AuthorId;
            existingBlog.ImageUrl = blogDto.ImageUrl;
            existingBlog.Category = blogDto.Category;

            await _blogRepository.UpdateBlogAsync(existingBlog);

            return Ok(blogDto);
        }


        // POST: api/BlogsApi
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<BlogDto>> PostBlog(BlogDto blogDto)
        {
            var blog = new Blog
            {
                Title = blogDto.Title,
                Content = blogDto.Content,
                AuthorId = blogDto.AuthorId,
                ImageUrl = blogDto.ImageUrl,
                Category = blogDto.Category,
                CreatedAt = DateTime.UtcNow
            };

            await _blogRepository.AddBlogAsync(blog);

            blogDto.Id = blog.Id; // Gán ID sau khi lưu vào DB
            return CreatedAtAction(nameof(GetBlog), new { id = blogDto.Id }, blogDto);
        }


        // DELETE: api/BlogsApi/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogRepository.DeleteBlogAsync(id);
            return NoContent();
        }
    }
}
