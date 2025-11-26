using EventPass.Domain.Entities.Venues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Venues
{
    public interface ISectionRepository
    {
        public Task<Section> AddSectionAsync(Section section, CancellationToken ct);

        public Task<Section> UpdateSectionAsync(Section section, CancellationToken ct);

        public Task<IEnumerable<Section>> GetAllSectionsAsync(CancellationToken ct);

        public Task<Section?> GetSectionByIdAsync(int id, CancellationToken ct);

        public Task<bool> DeleteSectionAsync(Section section, CancellationToken ct);

        public Task<IEnumerable<Section>> GetSectionsByVenueAsync(int venueId, CancellationToken ct);

    }
}
