using EventPass.Domain.Entities.Orders;
using EventPass.Domain.Interfaces.Orders;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrdersRepository
    {
        private readonly EventPassDbContext _context;
        IOrderItemsRepository _itemsRepository;

        public OrderRepository(EventPassDbContext context, IOrderItemsRepository itemsRepository)
        {
            _context = context;
            _itemsRepository = itemsRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken ct)
        {
            var orders = await _context.Orders.ToListAsync(ct);
            foreach (var order in orders)
            {
                order.TotalAmount = await _itemsRepository.GetTotalAmountByOrderId(order.Id, ct);
            }
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id, ct);
        }

        public async Task<Order> AddOrderAsync(Order order, CancellationToken ct)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteOrderAsync(int id, CancellationToken ct)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id, ct);
            if (order == null) return false;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
