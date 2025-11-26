using EventPass.Domain.Entities.EventCategories;
using EventPass.Domain.Interfaces;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Events
{
    public class EventCategoryRepository : IEventCategoryRepository
    {
        private readonly EventPassDbContext _context;

        public EventCategoryRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<EventCategory> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.EventCategories
                .Include(ec => ec.Events)
                .FirstOrDefaultAsync(ec => ec.ID == id, cancellationToken);
        }

        public async Task<IEnumerable<EventCategory>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.EventCategories
                .Include(ec => ec.Events)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<EventCategory>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.EventCategories
                .Include(ec => ec.Events)
                .Where(ec => ec.Name.Contains(name))
                .ToListAsync(cancellationToken);
        }

        public async Task<EventCategory> AddAsync(EventCategory eventCategory, CancellationToken cancellationToken = default)
        {
            _context.EventCategories.Add(eventCategory);
            await _context.SaveChangesAsync(cancellationToken);
            return eventCategory;
        }

        public async Task<EventCategory> UpdateAsync(EventCategory eventCategory, CancellationToken cancellationToken = default)
        {
            _context.EventCategories.Update(eventCategory);
            await _context.SaveChangesAsync(cancellationToken);
            return eventCategory;
        }

        public async Task DeleteAsync(EventCategory eventCategory, CancellationToken cancellationToken = default)
        {
            _context.EventCategories.Remove(eventCategory);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}