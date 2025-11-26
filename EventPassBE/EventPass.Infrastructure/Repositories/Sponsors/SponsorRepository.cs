using EventPass.Domain.Entities.Sponsors;
using EventPass.Domain.Interfaces.Sponsors;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Sponsors
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly EventPassDbContext _context;

        public SponsorRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Sponsor> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Sponsors
                .Include(s => s.Events)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Sponsor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sponsors
                .Include(s => s.Events)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Sponsor>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Sponsors
                .Include(s => s.Events)
                .Where(s => s.Name.Contains(name))
                .ToListAsync(cancellationToken);
        }

        public async Task<Sponsor> AddAsync(Sponsor sponsor, CancellationToken cancellationToken = default)
        {
            _context.Sponsors.Add(sponsor);
            await _context.SaveChangesAsync(cancellationToken);
            return sponsor;
        }

        public async Task<Sponsor> UpdateAsync(Sponsor sponsor, CancellationToken cancellationToken = default)
        {
            _context.Sponsors.Update(sponsor);
            await _context.SaveChangesAsync(cancellationToken);
            return sponsor;
        }

        public async Task DeleteAsync(Sponsor sponsor, CancellationToken cancellationToken = default)
        {
            _context.Sponsors.Remove(sponsor);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}