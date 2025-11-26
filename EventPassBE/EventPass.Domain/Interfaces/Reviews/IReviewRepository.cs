using EventPass.Domain.Entities.Performers;

namespace EventPass.Domain.Interfaces.Reviews
{
    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Review>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Review>> GetByPerformerIdAsync(int performerId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Review>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<Review> AddAsync(Review review, CancellationToken cancellationToken = default);
        Task<Review> UpdateAsync(Review review, CancellationToken cancellationToken = default);
        Task DeleteAsync(Review review, CancellationToken cancellationToken = default);
    }
}