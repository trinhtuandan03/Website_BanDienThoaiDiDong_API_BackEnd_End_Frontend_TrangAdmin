// File: DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin/Controllers/CartDetailsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class CartDetailsController : Controller
    {
        private readonly ILogger<CartDetailsController> _logger;
        private readonly HttpClient _httpClient;

        public CartDetailsController(ILogger<CartDetailsController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: CartDetails
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7108/api/CartDetailsApi");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var cartDetails = JsonSerializer.Deserialize<List<CartDetail>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(cartDetails);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cart details.");
            }
            return View(new List<CartDetail>());
        }

        // GET: CartDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartDetails/Create
        [HttpPost]
        public async Task<IActionResult> Create(CartDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/CartDetailsApi", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cart detail.");
            }
            ModelState.AddModelError("", "Unable to create cart detail.");
            return View(model);
        }

        // GET: CartDetails/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/CartDetailsApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var cartDetail = JsonSerializer.Deserialize<CartDetail>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(cartDetail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cart detail.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CartDetails/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/CartDetailsApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var cartDetail = JsonSerializer.Deserialize<CartDetail>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(cartDetail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cart detail for edit.");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CartDetails/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CartDetail model)
        {
            if (id != model.Id || !ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7108/api/CartDetailsApi/{id}", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cart detail.");
            }
            ModelState.AddModelError("", "Unable to update cart detail.");
            return View(model);
        }

        // POST: CartDetails/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7108/api/CartDetailsApi/{id}");
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting cart detail.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
