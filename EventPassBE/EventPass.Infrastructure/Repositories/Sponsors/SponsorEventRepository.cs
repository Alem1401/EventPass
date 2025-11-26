using EventPass.Domain.Entities.SponsorEvents;
using EventPass.Domain.Interfaces.Sponsors;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Sponsors
{
    public class SponsorEventRepository: ISponsorEventRepository
    {
        private readonly EventPassDbContext _context;

        public SponsorEventRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<SponsorEvent> AddSponsorEventAsync(SponsorEvent sponsorEvent, CancellationToken cancellationToken = default)
        {
            _context.SponsorEvents.Add(sponsorEvent);
            await _context.SaveChangesAsync(cancellationToken);
            return sponsorEvent;
        }

        public async Task<bool> DeleteSponsorEventAsync(int id, CancellationToken cancellationToken = default)
        {
            var sponsorEvent = _context.SponsorEvents.FirstOrDefault(sp => sp.Id == id);
            if (sponsorEvent == null) return false;
            _context.SponsorEvents.Remove(sponsorEvent);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<SponsorEvent> GetSponsorEventByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.SponsorEvents.FirstOrDefaultAsync(se => se.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<SponsorEvent>> GetAllSponsorEventsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SponsorEvents.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<SponsorEvent>> GetSponsorEventBySponsorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.SponsorEvents.Where(se => se.SponsorID == id).ToListAsync(cancellationToken);
        }

        public async Task<SponsorEvent> UpdateSponsorEventAsync(SponsorEvent sponsorEvent, CancellationToken cancellationToken = default)
        {
            _context.SponsorEvents.Update(sponsorEvent);
            await _context.SaveChangesAsync(cancellationToken);
            var updated = _context.SponsorEvents.FirstOrDefault(se => se.Id == sponsorEvent.Id);
            if (updated == null) return null;
            return updated;
        }
    }
}
