using EventPass.Domain.Entities.Venues;
using EventPass.Domain.Interfaces.Venues;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Infrastructure.Repositories.Venues
{
    public class SectionRepository : ISectionRepository
    {
        EventPassDbContext _context;

        public SectionRepository(EventPassDbContext context)
        {
            _context = context;
        }
        public async Task<Section> AddSectionAsync(Section section, CancellationToken ct)
        {
            _context.Sections.Add(section);
            await _context.SaveChangesAsync(ct);

            return await _context.Sections
        .Include(s => s.Venue)
        .FirstOrDefaultAsync(s => s.Id == section.Id, ct);
        }

        public async Task<bool> DeleteSectionAsync(Section section, CancellationToken ct)
        {
            _context.Sections.Remove(section);
            _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<IEnumerable<Section>> GetAllSectionsAsync(CancellationToken ct)
        {
            return await _context.Sections.Include(s => s.Venue).ToListAsync(ct);
        }

        public async Task<Section?> GetSectionByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Sections.Include(s => s.Venue).FirstOrDefaultAsync(s => s.Id == id, ct);
        }

        public async Task<IEnumerable<Section>> GetSectionsByVenueAsync(int venueId, CancellationToken ct)
        {
            return await _context.Sections.Where(s => s.VenueID == venueId).Include(s => s.Venue).ToListAsync(ct);
        }

        public async Task<Section> UpdateSectionAsync(Section section, CancellationToken ct)
        {
            _context.Sections.Update(section);
            await _context.SaveChangesAsync(ct);


            return await _context.Sections
                .Include(s => s.Venue)
                .FirstOrDefaultAsync(s => s.Id == section.Id, ct);
        }



    }
}
