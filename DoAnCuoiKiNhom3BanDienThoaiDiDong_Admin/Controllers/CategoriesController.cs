using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly HttpClient _httpClient;

        public CategoriesController(ILogger<CategoriesController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }



        // GET: Categories/List
        public async Task<IActionResult> Index()
        {
            try
            {
                // Gọi API để lấy danh sách danh mục
                var response = await _httpClient.GetAsync("https://localhost:7108/api/CategoriesApi");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var categories = JsonSerializer.Deserialize<List<Category>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return View(categories); // Truyền danh sách danh mục vào View
                }

                _logger.LogError("API trả về lỗi: {StatusCode}", response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API lấy danh sách danh mục.");
            }

            return View(new List<Category>()); // Trả về danh sách rỗng nếu có lỗi
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/CategoriesApi", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.LogError("Failed to create category: {StatusCode}", response.StatusCode);
                    ModelState.AddModelError("", "Unable to create category.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category");
                ModelState.AddModelError("", "An error occurred.");
            }

            return View(model);
        }

        // GET: Categories/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/CategoriesApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var category = JsonSerializer.Deserialize<Category>(jsonString);
                    return View(category);
                }
                else
                {
                    _logger.LogError("Failed to fetch category for edit: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching category for edit");
            }

            return RedirectToAction("Index");
        }

        // POST: Categories/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7108/api/CategoriesApi/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.LogError("Failed to update category: {StatusCode}", response.StatusCode);
                    ModelState.AddModelError("", "Unable to update category.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category");
                ModelState.AddModelError("", "An error occurred.");
            }

            return View(model);
        }

        // POST: Categories/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7108/api/CategoriesApi/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.LogError("Failed to delete category: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting category");
            }

            return RedirectToAction("Index");
        }
    }
}
