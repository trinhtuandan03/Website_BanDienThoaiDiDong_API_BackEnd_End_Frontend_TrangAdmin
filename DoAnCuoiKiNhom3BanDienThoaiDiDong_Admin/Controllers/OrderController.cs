// File: DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin/Controllers/OrderController.cs
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.DTOs;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly HttpClient _httpClient;

        public OrderController(ILogger<OrderController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7108/api/OrderApi");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orders = JsonSerializer.Deserialize<List<Order>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(orders);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching orders.");
            }
            return View(new List<Order>());
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/OrderApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var order = JsonSerializer.Deserialize<Order>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(order);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order details.");
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/OrderApi", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order.");
            }
            ModelState.AddModelError("", "Unable to create order.");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/OrderApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var order = JsonSerializer.Deserialize<Order>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(order);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order for edit.");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Order model)
        {
            if (id != model.Id || !ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7108/api/OrderApi/{id}", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order.");
            }
            ModelState.AddModelError("", "Unable to update order.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7108/api/OrderApi/{id}");
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting order.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
