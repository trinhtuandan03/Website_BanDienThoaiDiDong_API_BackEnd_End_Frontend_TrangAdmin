using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    //model để nhận thông tin số điện thoại:
    public class OtpRecord
    {
        [Key]
        public int Id { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Otp { get; set; } = string.Empty;

        public DateTime Expiry { get; set; } = DateTime.UtcNow.AddMinutes(5);

        // Khóa ngoại tới AspNetUsers
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

    }
}
