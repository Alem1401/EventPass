using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Interfaces.Performers;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Performers
{
    public class PerformerRepository : IPerformerRepository
    {
        private readonly EventPassDbContext _context;

        public PerformerRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Performer> GetPerformerByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Performers
                .Include(p => p.SocialMedia)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Performer>> GetAllPerformersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Performers
                .Include(p => p.SocialMedia)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Performer>> GetPerformerByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Performers
                .Include(p => p.SocialMedia)
                .Where(p => p.Name.Contains(name))
                .ToListAsync(cancellationToken);
        }

        public async Task<Performer> AddPerformerAsync(Performer performer, CancellationToken cancellationToken = default)
        {
            _context.Performers.Add(performer);
            await _context.SaveChangesAsync(cancellationToken);
            return performer;
        }

        public async Task<Performer> UpdatePerformerAsync(Performer performer, CancellationToken cancellationToken = default)
        {
            _context.Performers.Update(performer);
            await _context.SaveChangesAsync(cancellationToken);
            return performer;
        }

        public async Task DeletePerformerAsync(Performer performer, CancellationToken cancellationToken = default)
        {
            _context.Performers.Remove(performer);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}