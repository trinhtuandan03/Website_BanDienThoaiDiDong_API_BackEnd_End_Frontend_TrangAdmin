using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    public class CartDetail
    {
        [Key]
        public int Id { get; set; } // ID chi tiết giỏ hàng

        [Required]
        [ForeignKey("Cart")]
        public int CartId { get; set; } // Liên kết tới giỏ hàng

        public Cart Cart { get; set; } // Navigation property

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; } // Liên kết tới sản phẩm

        public Product Product { get; set; } // Navigation property

        [Required]
        public int Quantity { get; set; } // Số lượng sản phẩm

        [NotMapped]
        public decimal TotalPrice => Product?.Price * Quantity ?? 0; // Tính tổng giá cho sản phẩm này
    }
}
