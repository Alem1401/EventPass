using EventPass.Domain.Entities.OrderItems;

namespace EventPass.Domain.Interfaces.Orders
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync(CancellationToken cancellationToken = default);
        Task<OrderItem> AddOrderItemAsync(OrderItem order, CancellationToken cancellationToken = default);
        Task<bool> DeleteOrderItemAsync(int id, CancellationToken cancellationToken = default);
        Task<decimal> GetTotalAmountByOrderId(int id , CancellationToken cancellationToken = default);
    }
}
