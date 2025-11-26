using EventPass.Domain.Entities.Organizers;
using EventPass.Domain.Interfaces;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Organizers
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private readonly EventPassDbContext _context;

        public OrganizerRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Organizer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Organizers
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Organizer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Organizers
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Organizer>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Organizers
                .Where(o => o.Name.Contains(name))
                .ToListAsync(cancellationToken);
        }

        public async Task<Organizer> AddAsync(Organizer organizer, CancellationToken cancellationToken = default)
        {
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync(cancellationToken);
            return organizer;
        }

        public async Task<Organizer> UpdateAsync(Organizer organizer, CancellationToken cancellationToken = default)
        {
            _context.Organizers.Update(organizer);
            await _context.SaveChangesAsync(cancellationToken);
            return organizer;
        }

        public async Task DeleteAsync(Organizer organizer, CancellationToken cancellationToken = default)
        {
            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}