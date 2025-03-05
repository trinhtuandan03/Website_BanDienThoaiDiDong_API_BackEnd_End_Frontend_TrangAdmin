using System;
using System.Collections.Generic;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? AuthorId { get; set; }
        public User? Author { get; set; } // Navigation property for User
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ImageUrl { get; set; }
        public string? Category { get; set; } // Optional blog categorization
    }
}
