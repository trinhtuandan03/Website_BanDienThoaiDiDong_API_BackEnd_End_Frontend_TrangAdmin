using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
        //User = IdentityUser + string Inititals
    }
}
