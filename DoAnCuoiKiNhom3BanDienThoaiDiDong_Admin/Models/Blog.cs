namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? AuthorId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Product>? Products { get; set; } // List of related products
    }
}
