using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; } // ID của giỏ hàng

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; } // Liên kết tới người dùng

        public User User { get; set; } // Navigation property

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Thời gian tạo

        public ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>(); // Danh sách sản phẩm trong giỏ hàng

        [NotMapped]
        public decimal TotalPrice => CartDetails.Sum(cd => cd.TotalPrice); // Tính tổng giá trị giỏ hàng

        public string? PaymentMethod { get; set; } // Phương thức thanh toán (nếu có)
    }
}
