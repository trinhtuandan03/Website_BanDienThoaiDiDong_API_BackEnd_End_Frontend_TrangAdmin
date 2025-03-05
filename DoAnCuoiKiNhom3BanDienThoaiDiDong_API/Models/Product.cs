using System;
using System.Collections.Generic;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Image1 { get; set; }
    public string? Image2 { get; set; }
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; } // Navigation property
    // New fields for timestamps
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default to current time
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Default to current time

}