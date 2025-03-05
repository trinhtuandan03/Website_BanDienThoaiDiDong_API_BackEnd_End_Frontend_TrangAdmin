using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models
{
    public class RegistrationModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Initials { get; set; }
        public string Password { get; set; }
        public string CurrentPassword { get; set; } // Mật khẩu hiện tại
        public string Role { get; set; }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }

    [Table("User")]
    public class User
    {
        public string Id { get; set; } // ID người dùng
        public string UserName { get; set; } // Tên đăng nhập
        public string Email { get; set; } // Email người dùng
        public string PhoneNumber { get; set; } // Số điện thoại
        public string Initials { get; set; } // Tên viết tắt
        public string Password { get; set; } // Mật khẩu đã mã hóa
        public string Role { get; set; } // Các vai trò dưới dạng chuỗi
    }
    public class ApiResponse<T>
    {
        public bool Status { get; set; } // Trạng thái thành công hay không
        public string Message { get; set; } // Thông điệp phản hồi
        public T Data { get; set; } // Dữ liệu trả về
    }

}
