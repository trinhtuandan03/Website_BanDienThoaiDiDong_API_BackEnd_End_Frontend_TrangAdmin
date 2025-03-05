// File: DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin/Controllers/OrderDetailController.cs
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.DTOs;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly ILogger<OrderDetailController> _logger;
        private readonly HttpClient _httpClient;

        public OrderDetailController(ILogger<OrderDetailController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7108/api/OrderDetailApi");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orderDetails = JsonSerializer.Deserialize<List<OrderDetail>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(orderDetails);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order details.");
            }
            return View(new List<OrderDetail>());
        }

        // GET: OrderDetails/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/OrderDetailApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orderDetail = JsonSerializer.Deserialize<OrderDetail>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(orderDetail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order detail.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        public async Task<IActionResult> Create(OrderDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/OrderDetailApi", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order detail.");
            }
            ModelState.AddModelError("", "Unable to create order detail.");
            return View(model);
        }

        // GET: OrderDetails/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/OrderDetailApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orderDetail = JsonSerializer.Deserialize<OrderDetail>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(orderDetail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order detail for edit.");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderDetails/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, OrderDetail model)
        {
            if (id != model.Id || !ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:7108/api/OrderDetailApi/{id}", content);
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order detail.");
            }
            ModelState.AddModelError("", "Unable to update order detail.");
            return View(model);
        }

        // POST: OrderDetails/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7108/api/OrderDetailApi/{id}");
                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting order detail.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
