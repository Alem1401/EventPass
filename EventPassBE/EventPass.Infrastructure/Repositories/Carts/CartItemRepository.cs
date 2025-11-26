using EventPass.Domain.Entities.CartItems;
using EventPass.Domain.Interfaces.Carts;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Carts
{
    public class CartItemRepository: ICartItemsRepository
    {
        private readonly EventPassDbContext _context;

        public CartItemRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem> AddCartItemAsync(CartItem cartItem, CancellationToken cancellationToken = default)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
            return cartItem;
        }

        public async Task<bool> DeleteCartItemAsync(int id, CancellationToken cancellationToken = default)
        {
            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.Id == id);
            if (cartItem == null) return false;
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.CartItems.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.CartItems.Where(ci => ci.CartId == id).ToListAsync(cancellationToken);
        }
    }
}
