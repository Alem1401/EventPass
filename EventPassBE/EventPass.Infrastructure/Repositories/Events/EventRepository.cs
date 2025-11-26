using EventPass.Domain.Entities.Events;
using EventPass.Domain.Interfaces;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Events
{
    public class EventRepository : IEventRepository
    {
        private readonly EventPassDbContext _context;

        public EventRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Event> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Events
                .Include(e => e.Performer)
                .Include(e => e.Category)
                .Include(e => e.Organizer)
                .Include(e => e.Sponsors)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Event>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Events
                .Include(e => e.Performer)
                .Include(e => e.Category)
                .Include(e => e.Organizer)
                .Include(e => e.Sponsors)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Event>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Events
                .Include(e => e.Performer)
                .Include(e => e.Category)
                .Include(e => e.Organizer)
                .Include(e => e.Sponsors)
                .Where(e => e.Name.Contains(name))
                .ToListAsync(cancellationToken);
        }

        public async Task<Event> AddAsync(Event @event, CancellationToken cancellationToken = default)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync(cancellationToken);
            return @event;
        }

        public async Task<Event> UpdateAsync(Event @event, CancellationToken cancellationToken = default)
        {
            _context.Events.Update(@event);
            await _context.SaveChangesAsync(cancellationToken);
            return @event;
        }

        public async Task DeleteAsync(Event @event, CancellationToken cancellationToken = default)
        {
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}