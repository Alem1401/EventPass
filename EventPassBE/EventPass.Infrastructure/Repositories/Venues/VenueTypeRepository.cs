using EventPass.Domain.Entities.VenueTypes;
using EventPass.Domain.Interfaces.Venues;
using Microsoft.EntityFrameworkCore;
using EventPass.Infrastructure.Persistence;

namespace EventPass.Infrastructure.Repositories.Venues
{
    public class VenueTypeRepository : IVenueTypeRepository
    {
        private readonly EventPassDbContext _context;

        public VenueTypeRepository(EventPassDbContext context)
        {
            _context = context;
        }



        public async Task AddVenueTypeAsync(VenueType venueType, CancellationToken ct = default)
        {
            await _context.VenueTypes.AddAsync(venueType, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<VenueType>> GetAllVenueTypesAsync(CancellationToken ct = default)
        {
            return await _context.VenueTypes.ToListAsync(ct);
        }

        public async Task<VenueType?> GetVenueTypeByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.VenueTypes.FindAsync(id, ct);
        }
        public async Task<VenueType> UpdateVenueTypeAsync(VenueType venueType, CancellationToken ct)
        {
            _context.VenueTypes.Update(venueType);
            await _context.SaveChangesAsync(ct);
            return venueType;
        }

        public async Task<bool> DeleteVenueTypeAsync(int id, CancellationToken ct)
        {
            var toDelete = await _context.VenueTypes.FirstOrDefaultAsync(vt => vt.Id == id, ct);
            if (toDelete == null)
            {
                return false;
            }
            else
            {
                _context.VenueTypes.Remove(toDelete);
                await _context.SaveChangesAsync(ct);
                return true;
            }
        }



    }
}
