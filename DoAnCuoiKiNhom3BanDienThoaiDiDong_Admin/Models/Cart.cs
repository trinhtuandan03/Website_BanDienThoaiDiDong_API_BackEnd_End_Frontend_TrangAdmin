namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; } // To display user name if needed
        public DateTime CreatedAt { get; set; }
        public ICollection<CartDetail>? CartDetails { get; set; }
        public decimal TotalPrice { get; set; }
        public string? PaymentMethod { get; set; }
    }
    public class CartDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
