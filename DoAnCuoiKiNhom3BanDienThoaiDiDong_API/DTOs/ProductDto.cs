namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
