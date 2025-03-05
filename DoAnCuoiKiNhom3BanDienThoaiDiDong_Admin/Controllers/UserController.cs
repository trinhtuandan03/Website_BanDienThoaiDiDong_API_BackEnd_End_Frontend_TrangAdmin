using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.ViewModel;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly HttpClient _httpClient;

        public UserController(ILogger<UserController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // Hiển thị danh sách người dùng
        public async Task<IActionResult> Index()
        {
            try
            {
                // Gửi yêu cầu GET đến API
                var response = await _httpClient.GetAsync("https://localhost:7108/api/Authenticate/users");

                if (response.IsSuccessStatusCode)
                {
                    // Chuyển JSON phản hồi thành đối tượng
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<User>>>(jsonString,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (apiResponse?.Status == true && apiResponse.Data != null)
                    {
                        // Trả dữ liệu danh sách người dùng tới View
                        return View(apiResponse.Data);
                    }

                    // Nếu phản hồi không hợp lệ
                    _logger.LogError("Lỗi API: {Message}", apiResponse?.Message ?? "Không rõ lỗi.");
                    return View("Error");
                }

                _logger.LogError("API trả về mã lỗi: {StatusCode}", response.StatusCode);
                return View("Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API lấy danh sách người dùng.");
                return View("Error");
            }
        }
        //------------------------------------------------------------------------------------------------------------
        // Hiển thị chi tiết người dùng
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                // Gửi yêu cầu GET đến API để lấy chi tiết người dùng
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/Authenticate/{id}");

                if (response.IsSuccessStatusCode)
                {
                    // Chuyển đổi JSON phản hồi thành đối tượng
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<User>>(jsonString,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (apiResponse?.Status == true && apiResponse.Data != null)
                    {
                        // Trả dữ liệu chi tiết người dùng tới View
                        return View(apiResponse.Data);
                    }

                    // Nếu phản hồi không hợp lệ
                    _logger.LogError("API trả về lỗi: {Message}", apiResponse?.Message ?? "Không rõ lỗi.");
                }
                else
                {
                    _logger.LogError("API trả về mã lỗi: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API lấy chi tiết người dùng.");
            }

            // Trả về View Error nếu xảy ra lỗi
            return View("Error");
        }



        //------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                // Gửi yêu cầu GET đến API để lấy thông tin người dùng
                var response = await _httpClient.GetAsync($"https://localhost:7108/api/Authenticate/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<User>>(jsonString,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (apiResponse?.Status == true && apiResponse.Data != null)
                    {
                        return View(apiResponse.Data);
                    }

                    _logger.LogError("API trả về lỗi: {Message}", apiResponse?.Message ?? "Không rõ lỗi.");
                }
                else
                {
                    _logger.LogError("API trả về mã lỗi: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API lấy thông tin người dùng.");
            }

            return View("Error");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, User model, string currentPassword, string newPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(new
                {
                    model.UserName,
                    model.Email,
                    model.PhoneNumber,
                    model.Initials,
                    Role = model.Role,
                    CurrentPassword = currentPassword,
                    Password = newPassword // Mật khẩu mới nếu cần
                }), Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"https://localhost:7108/api/Authenticate/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("API trả về lỗi: {StatusCode}, Nội dung: {Response}", response.StatusCode, responseContent);
                ModelState.AddModelError("", "Cập nhật thông tin người dùng không thành công.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API cập nhật thông tin người dùng.");
                ModelState.AddModelError("", "Đã xảy ra lỗi.");
            }

            return View(model);
        }





        //-------------------------------------------------------------------
        public IActionResult Register()
        {
            ViewBag.HideMenuAndFooter = true;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/Authenticate/register", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonString);

                    ViewBag.Message = apiResponse.Message;
                    return RedirectToAction("Login");
                }
                else
                {
                    _logger.LogError("Đăng ký thất bại: {StatusCode}", response.StatusCode);
                    ModelState.AddModelError("", "Đăng ký không thành công.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API đăng ký");
                ModelState.AddModelError("", "Đã xảy ra lỗi.");
            }

            return View(model);
        }
        //-------------------------------------------------------------------------------------------
        public IActionResult Login()
        {
            ViewBag.HideMenuAndFooter = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7108/api/Authenticate/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonString);

                    // Thiết lập claims để xác thực
                    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, model.Username),
        new Claim(ClaimTypes.Role, apiResponse.Role ?? "User")
    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    _logger.LogInformation("Đăng nhập thành công: {Message}", apiResponse.Message);

                    // Chuyển hướng đến Home/Index
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _logger.LogError("Đăng nhập thất bại: {StatusCode}", response.StatusCode);
                    ModelState.AddModelError("", "Đăng nhập không thành công.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gọi API đăng nhập");
                ModelState.AddModelError("", "Đã xảy ra lỗi.");
            }

            return View(model);
        }

        //----------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Xóa cookie xác thực
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                _logger.LogInformation("Người dùng đã đăng xuất thành công.");

                // Chuyển hướng đến trang Đăng nhập
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi đăng xuất");
                ModelState.AddModelError("", "Đã xảy ra lỗi khi đăng xuất.");
            }

            return RedirectToAction("Index", "Home");
        }

    }
}