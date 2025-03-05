using System.ComponentModel.DataAnnotations;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    //model để nhận thông tin số điện thoại:
    public class OtpRequestModel
    {
        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
