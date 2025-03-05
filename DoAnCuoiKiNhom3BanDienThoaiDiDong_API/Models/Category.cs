using System;
using System.Collections.Generic;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; } // Relationship: A category can have many products
    }
}
