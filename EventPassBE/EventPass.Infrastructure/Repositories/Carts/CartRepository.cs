using EventPass.Domain.Entities.Carts;
using EventPass.Domain.Interfaces.Carts;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Carts
{
    public class CartRepository : ICartsRepository
    {
        private readonly EventPassDbContext _context;

        public CartRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddCartAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task<bool> DeleteCartAsync(int id, CancellationToken cancellationToken = default)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cart == null) return false;
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Cart>> GetAllCartsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Carts.ToListAsync(cancellationToken);
        }

        public async Task<Cart> GetCartByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userId, cancellationToken);
        }
    }
}
