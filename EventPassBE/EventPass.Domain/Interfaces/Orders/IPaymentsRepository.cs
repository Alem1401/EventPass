using EventPass.Domain.Entities.Payments;

namespace EventPass.Domain.Interfaces.Orders
{
    public interface IPaymentsRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken = default);
        Task<Payment> AddPaymentAsync(Payment payment, CancellationToken cancellationToken = default);
        Task<bool> DeletePaymentAsync(int id, CancellationToken cancellationToken = default);
    }
}
