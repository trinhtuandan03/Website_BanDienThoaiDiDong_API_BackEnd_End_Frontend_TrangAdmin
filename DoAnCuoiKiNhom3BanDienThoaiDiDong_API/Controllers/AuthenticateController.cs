using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager; 
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AuthenticateController(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            // Lấy tất cả người dùng từ cơ sở dữ liệu
            var users = await _userManager.Users.ToListAsync();

            // Lấy vai trò cho từng người dùng và định dạng vai trò thành chuỗi
            var userList = new List<object>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    user.Initials,
                    user.PasswordHash,
                    Roles = string.Join(", ", roles) // Nối các vai trò thành chuỗi
                });
            }

            return Ok(new
            {
                Status = true,
                Message = "Lấy danh sách người dùng thành công.",
                Data = userList
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                // Tìm người dùng theo ID
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new
                    {
                        Status = false,
                        Message = "Người dùng không tồn tại."
                    });
                }

                // Lấy vai trò của người dùng
                var roles = await _userManager.GetRolesAsync(user);

                // Trả về thông tin chi tiết người dùng
                return Ok(new
                {
                    Status = true,
                    Message = "Lấy thông tin người dùng thành công.",
                    Data = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.PhoneNumber,
                        user.Initials,
                        user.PasswordHash,
                        Roles = string.Join(", ", roles)
                    }
                });
            }
            catch (Exception ex)
            {
                // Ghi log và trả về lỗi nếu có exception
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Status = false,
                    Message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }


        //---------------------------------------------------------------------
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Status = false,
                    Message
                = "Người dùng đã tồn tại"
                });
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Initials = model.Initials
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Status = false,
                    Message = "Tạo người dùng không thành công"
                });
            // Gán vai trò nếu được cung cấp
            if (!string.IsNullOrEmpty(model.Role))
            {
                if (!await _roleManager.RoleExistsAsync(model.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Role));
                }
                await _userManager.AddToRoleAsync(user, model.Role);
            }
            return Ok(new { Status = true, Message = "Người dùng đã được tạo thành công" });
        }
        //---------------------------------------------------------------------
        [
        HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new
                {
                    Status = false,Message = "Tên người dùng hoặc mật khẩu không hợp lệ" });
                    var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id)
                };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var token = GenerateToken(authClaims);
            return Ok(new { Status = true, Message = "Đã đăng nhập thành công", Token = token });
        }
        //---------------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] RegistrationModel updatedUser)
        {
            try
            {
                // Tìm người dùng theo ID
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new
                    {
                        Status = false,
                        Message = "Người dùng không tồn tại."
                    });
                }

                // Cập nhật thông tin người dùng
                user.UserName = updatedUser.Username ?? user.UserName;
                user.Email = updatedUser.Email ?? user.Email;
                user.PhoneNumber = updatedUser.PhoneNumber ?? user.PhoneNumber;
                user.Initials = updatedUser.Initials ?? user.Initials;

                // Thay đổi mật khẩu nếu được cung cấp
                if (!string.IsNullOrEmpty(updatedUser.CurrentPassword) && !string.IsNullOrEmpty(updatedUser.Password))
                {
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, updatedUser.CurrentPassword, updatedUser.Password);
                    if (!changePasswordResult.Succeeded)
                    {
                        return BadRequest(new
                        {
                            Status = false,
                            Message = "Không thể thay đổi mật khẩu.",
                            Errors = changePasswordResult.Errors.Select(e => e.Description)
                        });
                    }
                }

                // Cập nhật vai trò nếu được cung cấp
                if (!string.IsNullOrEmpty(updatedUser.Role))
                {
                    // Lấy vai trò hiện tại của người dùng
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    // Tách các vai trò mới từ chuỗi và thêm vai trò nếu cần
                    var roles = updatedUser.Role.Split(",").Select(r => r.Trim()).ToList();
                    foreach (var role in roles)
                    {
                        if (!await _roleManager.RoleExistsAsync(role))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }

                    var addRoleResult = await _userManager.AddToRolesAsync(user, roles);
                    if (!addRoleResult.Succeeded)
                    {
                        return BadRequest(new
                        {
                            Status = false,
                            Message = "Không thể cập nhật vai trò của người dùng.",
                            Errors = addRoleResult.Errors.Select(e => e.Description)
                        });
                    }
                }

                // Lưu các thay đổi
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    return BadRequest(new
                    {
                        Status = false,
                        Message = "Cập nhật thông tin người dùng không thành công.",
                        Errors = updateResult.Errors.Select(e => e.Description)
                    });
                }

                // Trả về phản hồi sau khi cập nhật thành công
                return Ok(new
                {
                    Status = true,
                    Message = "Cập nhật thông tin người dùng thành công.",
                    Data = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.PhoneNumber,
                        user.Initials,
                        Roles = string.Join(", ", await _userManager.GetRolesAsync(user))
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Status = false,
                    Message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }



        //---------------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Status = false, Message = "Người dùng không tồn tại." });

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Status = false,
                    Message = "Xóa người dùng không thành công."
                });

            return Ok(new { Status = true, Message = "Người dùng đã được xóa thành công." });
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWTKey");
            var authSigningKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires =
            DateTime.UtcNow.AddHours(Convert.ToDouble(jwtSettings["TokenExpiryTimeInHour"])),
                Issuer = jwtSettings["ValidIssuer"],
                Audience = jwtSettings["ValidAudience"],
                SigningCredentials = new SigningCredentials(authSigningKey,
            SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        // Gửi OTP (send-otp để thử nghiệm trên Swagger: để kiểm tra trạng thái xác thực hoặc tương tác khác.)
        //[HttpPost("send-otp")]
        //public async Task<IActionResult> SendOtp([FromBody] OtpRequestModel model)
        //{
        //    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
        //    if (user == null)
        //        return BadRequest(new { Status = false, Message = "Số điện thoại chưa được đăng ký." });

        //    var otpCode = new Random().Next(100000, 999999).ToString();
        //    var otpRecord = new OtpRecord
        //    {
        //        PhoneNumber = model.PhoneNumber,
        //        Otp = otpCode,
        //        Expiry = DateTime.UtcNow.AddMinutes(5),
        //        UserId = user.Id
        //    };

        //    _context.OtpRecords.Add(otpRecord);
        //    await _context.SaveChangesAsync();

        //    Console.WriteLine($"OTP for {model.PhoneNumber}: {otpCode}");
        //    return Ok(new { Status = true, Message = "OTP đã được gửi thành công." });
        //}


        // Gửi OTP
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequestModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
            if (user == null)
                return BadRequest(new { Status = false, Message = "Số điện thoại chưa được đăng ký." });

            var otpCode = new Random().Next(100000, 999999).ToString();
            var otpRecord = new OtpRecord
            {
                PhoneNumber = model.PhoneNumber,
                Otp = otpCode,
                Expiry = DateTime.UtcNow.AddMinutes(5),
                UserId = user.Id
            };

            _context.OtpRecords.Add(otpRecord);
            await _context.SaveChangesAsync();

            Console.WriteLine($"OTP for {model.PhoneNumber}: {otpCode}");
            return Ok(new { Status = true, Message = "OTP đã được gửi thành công." });
        }


        // Xác nhận OTP (Client (Flutter) gửi yêu cầu để bắt đầu xác thực số điện thoại bằng Firebase SDK.)
        //[HttpPost("verify-otp")]
        //public async Task<IActionResult> VerifyOtp([FromBody] OtpVerificationModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(new { Status = false, Message = "Thông tin không hợp lệ." });

        //    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
        //    if (user == null)
        //        return BadRequest(new { Status = false, Message = "Số điện thoại chưa được đăng ký." });

        //    try
        //    {
        //        // Firebase xác minh mã OTP
        //        var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(model.Otp);

        //        if (decodedToken != null && decodedToken.Claims.TryGetValue("phone_number", out var phoneNumber))
        //        {
        //            if (phoneNumber.ToString() == model.PhoneNumber)
        //            {
        //                return Ok(new { Status = true, Message = "OTP đã được xác minh thành công." });
        //            }
        //        }

        //        return BadRequest(new { Status = false, Message = "OTP không hợp lệ." });
        //    }
        //    catch (FirebaseAuthException ex)
        //    {
        //        return BadRequest(new { Status = false, Message = $"Lỗi xác minh OTP: {ex.Message}" });
        //    }
        //}

        // Xác nhận OTP
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerificationModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
            if (user == null)
                return BadRequest(new { Status = false, Message = "Số điện thoại chưa được đăng ký." });

            var otpRecord = await _context.OtpRecords
                .FirstOrDefaultAsync(o => o.PhoneNumber == model.PhoneNumber && o.UserId == user.Id && o.Otp == model.Otp);

            if (otpRecord == null || otpRecord.Expiry < DateTime.UtcNow)
                return BadRequest(new { Status = false, Message = "OTP không hợp lệ hoặc đã hết hạn." });

            _context.OtpRecords.Remove(otpRecord);
            await _context.SaveChangesAsync();

            return Ok(new { Status = true, Message = "OTP đã được xác minh thành công." });
        }
    }
}
