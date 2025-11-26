using EventPass.Domain.Entities.CartItems;

namespace EventPass.Domain.Interfaces.Carts
{
    public interface ICartItemsRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<CartItem>> GetAllCartItemsAsync(CancellationToken cancellationToken = default);
        Task<CartItem> AddCartItemAsync(CartItem cartItem, CancellationToken cancellationToken = default);
        Task<bool> DeleteCartItemAsync(int id, CancellationToken cancellationToken = default);
    }
}
