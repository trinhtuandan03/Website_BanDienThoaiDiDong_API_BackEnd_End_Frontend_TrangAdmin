namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
