// File: DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin/Controllers/BlogsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly HttpClient _httpClient;

        public BlogsController(ILogger<BlogsController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7108/api/BlogsApi");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var blogs = JsonSerializer.Deserialize<List<Blog>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(blogs);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching blogs.");
            }
            return View(new List<Blog>());
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        [HttpPost]
        public async Task<IActionResult> Create(Blog model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/BlogsApi", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Blog created successfully!";
                    return RedirectToAction("Index", "Blogs"); // Ensure correct routing
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating blog.");
            }

            ModelState.AddModelError("", "Unable to create blog. Please try again later.");
            return View(model);
        }

        // GET: Blogs/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/BlogsApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var blog = JsonSerializer.Deserialize<Blog>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(blog);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching blog details.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Blogs/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/BlogsApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var blog = JsonSerializer.Deserialize<Blog>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(blog);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching blog for edit.");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Blogs/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Blog model)
        {
            if (id != model.Id || !ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7108/api/BlogsApi/{id}", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating blog.");
            }
            ModelState.AddModelError("", "Unable to update blog.");
            return View(model);
        }

        // POST: Blogs/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7108/api/BlogsApi/{id}");
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting blog.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
