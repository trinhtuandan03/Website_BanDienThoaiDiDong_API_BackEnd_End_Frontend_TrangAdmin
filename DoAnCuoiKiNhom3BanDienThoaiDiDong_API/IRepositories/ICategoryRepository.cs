using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;
namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
