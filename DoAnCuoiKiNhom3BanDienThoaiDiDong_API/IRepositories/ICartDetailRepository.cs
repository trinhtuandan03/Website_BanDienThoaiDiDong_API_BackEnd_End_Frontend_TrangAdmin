using System.Collections.Generic;
using System.Threading.Tasks;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.IRepositories
{
    public interface ICartDetailRepository
    {
        Task<IEnumerable<CartDetail>> GetCartDetailsAsync();
        Task<CartDetail> GetCartDetailByIdAsync(int id);
        Task AddCartDetailAsync(CartDetail cartDetail);
        Task UpdateCartDetailAsync(CartDetail cartDetail);
        Task DeleteCartDetailAsync(int id);
        Task<IEnumerable<CartDetail>> GetCartDetailsByUserIdAsync(string userId);
        Task ClearCartByUserIdAsync(string userId);

    }
}
