using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Interfaces.Reviews;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Performers
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EventPassDbContext _context;

        public ReviewRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Review> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Reviews
                .Include(r => r.Performer)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Review>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Reviews
                .Include(r => r.Performer)
                .Include(r => r.User)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Review>> GetByPerformerIdAsync(int performerId, CancellationToken cancellationToken = default)
        {
            return await _context.Reviews
                .Include(r => r.Performer)
                .Include(r => r.User)
                .Where(r => r.PerformerID == performerId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Review>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _context.Reviews
                .Include(r => r.Performer)
                .Include(r => r.User)
                .Where(r => r.UserID == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<Review> AddAsync(Review review, CancellationToken cancellationToken = default)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(cancellationToken);
            return review;
        }

        public async Task<Review> UpdateAsync(Review review, CancellationToken cancellationToken = default)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync(cancellationToken);
            return review;
        }

        public async Task DeleteAsync(Review review, CancellationToken cancellationToken = default)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}