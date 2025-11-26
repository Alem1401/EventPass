using EventPass.Domain.Entities.Orders;


namespace EventPass.Domain.Interfaces.Orders
{
    public interface IOrdersRepository
    {
        Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
        Task<Order> AddOrderAsync(Order order, CancellationToken cancellationToken = default);
        Task<bool> DeleteOrderAsync(int id, CancellationToken cancellationToken = default);
    }
}
