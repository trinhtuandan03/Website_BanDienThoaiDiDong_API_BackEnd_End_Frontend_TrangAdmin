using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.IRepositories;
using DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Models;

namespace DoAnCuoiKiNhom3BanDienThoaiDiDong_API.Repositories
{
    public class CartDetailRepository : ICartDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public CartDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartDetail>> GetCartDetailsAsync()
        {
            return await _context.CartDetails.Include(cd => cd.Product).ToListAsync();
        }

        public async Task<CartDetail> GetCartDetailByIdAsync(int id)
        {
            return await _context.CartDetails
                .Include(cd => cd.Product)
                .FirstOrDefaultAsync(cd => cd.Id == id);
        }

        public async Task AddCartDetailAsync(CartDetail cartDetail)
        {
            _context.CartDetails.Add(cartDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartDetailAsync(CartDetail cartDetail)
        {
            _context.Entry(cartDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartDetailAsync(int id)
        {
            var cartDetail = await _context.CartDetails.FindAsync(id);
            if (cartDetail != null)
            {
                _context.CartDetails.Remove(cartDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CartDetail>> GetCartDetailsByUserIdAsync(string userId)
        {
            return await _context.CartDetails
                .Include(cd => cd.Product)
                .Include(cd => cd.Cart) // Bao gồm thông tin giỏ hàng
                .Where(cd => cd.Cart.UserId == userId) // Lọc theo UserId từ Cart
                .ToListAsync();
        }

        public async Task ClearCartByUserIdAsync(string userId)
        {
            // Lọc theo UserId từ Cart
            var cartDetails = _context.CartDetails
                .Include(cd => cd.Cart) // Bao gồm thông tin Cart để truy cập UserId
                .Where(cd => cd.Cart.UserId == userId);

            _context.CartDetails.RemoveRange(cartDetails);
            await _context.SaveChangesAsync();
        }
    }
}
