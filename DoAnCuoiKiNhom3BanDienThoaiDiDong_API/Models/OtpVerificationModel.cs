using System.ComponentModel.DataAnnotations;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    //model để nhận thông tin xác thực OTP:
    public class OtpVerificationModel
    {
        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Otp { get; set; } = string.Empty;
    }
}
