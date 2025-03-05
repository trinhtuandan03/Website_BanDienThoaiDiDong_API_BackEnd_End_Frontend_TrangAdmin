using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.ViewModel
{
    public class UserViewModels
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Initials { get; set; }
        public string Roles { get; set; } // Vai trò dưới dạng chuỗi, ví dụ: "Admin, User"
    }
}
