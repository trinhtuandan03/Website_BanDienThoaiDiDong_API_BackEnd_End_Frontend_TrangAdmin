// File: DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin/Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductController> _logger;

        public ProductController(HttpClient httpClient, ILogger<ProductController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }



        // Hiển thị danh sách người dùng
        // GET: Product
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7108/api/ProductApi");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var products = JsonSerializer.Deserialize<List<Product>>(jsonString,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(products);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching products from API.");
            }
            return View(new List<Product>());
        }

        // Updated ProductController.cs
        public IActionResult Create()
        {
            // Prepares the view for adding a new product
            return View();
        }

        // POST: Blogs/Create
        [HttpPost]
        public async Task<IActionResult> Create(Blog model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                // Serializes the blog model and sends it to the API
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/BlogsApi", content);

                // If the response is successful, redirects to the blog list
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Blog created successfully!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Logs the error
                _logger.LogError(ex, "Error creating blog.");
            }

            // Adds a generic error message if the process fails
            ModelState.AddModelError("", "Unable to create blog. Please try again later.");
            return View(model);
        }


        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/ProductApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var product = JsonSerializer.Deserialize<Product>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product details.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/ProductApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var product = JsonSerializer.Deserialize<Product>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product for edit.");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product model)
        {
            if (id != model.Id || !ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7108/api/ProductApi/{id}", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product.");
            }
            ModelState.AddModelError("", "Unable to update product.");
            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7108/api/ProductApi/{id}");
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
