using EventPass.Domain.Entities.Venues;
using EventPass.Domain.Interfaces.Venues;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace EventPass.Infrastructure.Repositories.Venues
{
    public class VenueRepository : IVenueRepository
    {
        EventPassDbContext _context;
        public VenueRepository(EventPassDbContext context)
        {
            _context = context;
        }
        public async Task<Venue> AddVenueAsync(Venue venue, CancellationToken ct)
        {

            if (await _context.Venues.AnyAsync(v => v.Name == venue.Name, ct))
            {
                throw new InvalidOperationException("Venue with this name already exists");
            }

            _context.Venues.Add(venue);
            await _context.SaveChangesAsync(ct);

            return await _context.Venues
                .Include(v => v.VenueType)
                .FirstOrDefaultAsync(v => v.Id == venue.Id, ct);
        }

        public async Task<bool> DeleteVenueAsync(Venue venue, CancellationToken ct)
        {
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync(ct);
            return true;

        }

        public async Task<IEnumerable<Venue>> GetAllVenuesAsync(CancellationToken ct)
        {
            return await _context.Venues.Include(v => v.VenueType).ToListAsync(ct);
        }

        public async Task<Venue> GetVenueByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Venues
                 .Include(v => v.VenueType)
              .FirstOrDefaultAsync(v => v.Id == id, ct);
        }

        public async Task<Venue> UpdateVenueAsync(Venue venue, CancellationToken ct)
        {
            _context.Venues.Update(venue);
            await _context.SaveChangesAsync(ct);
            return venue;
        }



    }
}
