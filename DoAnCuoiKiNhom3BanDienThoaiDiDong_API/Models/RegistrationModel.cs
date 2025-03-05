using System.ComponentModel.DataAnnotations;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string? CurrentPassword { get; set; } // Mật khẩu hiện tại

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Initials { get; set; }
        public string? Role { get; set; } // Optional - assign a role if needed

    }
}
