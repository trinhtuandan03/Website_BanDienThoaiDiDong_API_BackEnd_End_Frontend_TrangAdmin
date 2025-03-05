using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } // ID của đơn hàng

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; } // Liên kết tới người dùng

        public User User { get; set; } // Navigation property

        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Ngày tạo đơn hàng

        [Required]
        public string OrderStatus { get; set; } = "Pending"; // Trạng thái đơn hàng (Pending, Shipped, Delivered, etc.)

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); // Chi tiết sản phẩm trong đơn hàng

        [Required]
        public decimal TotalPrice { get; set; } // Tổng giá trị đơn hàng

        public string PaymentMethod { get; set; } // Phương thức thanh toán

        public string? ShippingAddress { get; set; } // Địa chỉ giao hàng (nếu có)
    }

    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; } // ID chi tiết đơn hàng

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; } // Liên kết tới đơn hàng

        public Order Order { get; set; } // Navigation property

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; } // Liên kết tới sản phẩm

        public Product Product { get; set; } // Navigation property

        [Required]
        public int Quantity { get; set; } // Số lượng sản phẩm

        [Required]
        public decimal Price { get; set; } // Giá của sản phẩm
    }
}
