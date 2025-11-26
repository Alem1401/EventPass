using EventPass.Domain.Entities.Carts;

namespace EventPass.Domain.Interfaces.Carts
{
    public interface ICartsRepository
    {
        Task<Cart> GetCartByUserIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Cart>> GetAllCartsAsync(CancellationToken cancellationToken = default);
        Task<Cart> AddCartAsync(Cart cart, CancellationToken cancellationToken = default);
        Task<bool> DeleteCartAsync(int id, CancellationToken cancellationToken = default);
    }
}
