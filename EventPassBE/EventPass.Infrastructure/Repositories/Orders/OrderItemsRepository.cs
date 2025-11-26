using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Entities.Orders;
using EventPass.Domain.Interfaces.Orders;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Orders
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly EventPassDbContext _context;

        public OrderItemsRepository(EventPassDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync(CancellationToken ct)
        {
            return await _context.OrderItems.ToListAsync(ct);
        }
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.OrderItems.Where(oi => oi.OrderID == id).ToListAsync(cancellationToken);
        }
        public async Task<OrderItem> AddOrderItemAsync(OrderItem order, CancellationToken cancellationToken = default)
        {
            _context.OrderItems.Add(order);
            var modifyOrder = _context.Orders.First(o => o.Id == order.OrderID);
            modifyOrder.TotalAmount += order.PriceAtPurchase;
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<bool> DeleteOrderItemAsync(int id, CancellationToken cancellationToken = default)
        {
            var orderItem = _context.OrderItems.FirstOrDefault(oi => oi.Id == id);
            if (orderItem == null) { return false; }
            var modifyOrder = _context.Orders.First(o => o.Id == orderItem.OrderID);
            modifyOrder.TotalAmount -= orderItem.PriceAtPurchase;
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetTotalAmountByOrderId(int id, CancellationToken cancellationToken = default)
        {

            return _context.OrderItems.Where(oi => oi.OrderID == id).Sum(oi => oi.PriceAtPurchase);
        }
    }
}
