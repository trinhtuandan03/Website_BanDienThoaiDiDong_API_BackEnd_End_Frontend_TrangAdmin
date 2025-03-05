using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Diagnostics;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Gọi API
                var response = await _httpClient.GetAsync("https://localhost:7108/WeatherForecast");

                if (response.IsSuccessStatusCode)
                {
                    // Giải mã JSON
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var weatherForecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    // Truyền dữ liệu cho view
                    return View(weatherForecasts);
                }
                else
                {
                    _logger.LogError("API trả về mã lỗi: {StatusCode}", response.StatusCode);
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API");
                return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
