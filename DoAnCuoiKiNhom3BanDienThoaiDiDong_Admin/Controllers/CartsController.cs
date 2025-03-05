// File: DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin/Controllers/CartsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class CartsController : Controller
    {
        private readonly ILogger<CartsController> _logger;
        private readonly HttpClient _httpClient;

        public CartsController(ILogger<CartsController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7108/api/CartsApi");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var carts = JsonSerializer.Deserialize<List<Cart>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(carts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching carts.");
            }
            return View(new List<Cart>());
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        [HttpPost]
        public async Task<IActionResult> Create(Cart model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/CartsApi", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cart.");
            }
            ModelState.AddModelError("", "Unable to create cart.");
            return View(model);
        }

        // GET: Carts/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/CartsApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var cart = JsonSerializer.Deserialize<Cart>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(cart);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cart details.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Carts/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/CartsApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var cart = JsonSerializer.Deserialize<Cart>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(cart);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cart for edit.");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Carts/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cart model)
        {
            if (id != model.Id || !ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7108/api/CartsApi/{id}", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cart.");
            }
            ModelState.AddModelError("", "Unable to update cart.");
            return View(model);
        }

        // POST: Carts/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7108/api/CartsApi/{id}");
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting cart.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
