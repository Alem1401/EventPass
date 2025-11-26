using EventPass.Domain.Entities.Payments;
using EventPass.Domain.Interfaces.Orders;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Orders
{
    public class PaymentRepository : IPaymentsRepository
    {
        private readonly EventPassDbContext _context;

        public PaymentRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPaymentAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(cancellationToken);
            return payment;
        }

        public async Task<bool> DeletePaymentAsync(int id, CancellationToken cancellationToken = default)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
            if (payment == null) return false;
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Payments.Include(p => p.Order).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Payments.Include(p => p.Order).Where(p => p.Order.UserID == id).ToListAsync();
        }
    }
}
