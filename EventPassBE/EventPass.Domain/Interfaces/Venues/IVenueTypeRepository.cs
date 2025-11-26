using EventPass.Domain.Entities.VenueTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Venues
{
    public interface IVenueTypeRepository
    {
        Task<VenueType?> GetVenueTypeByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<VenueType>> GetAllVenueTypesAsync(CancellationToken ct = default);
        Task AddVenueTypeAsync(VenueType venueType, CancellationToken ct = default);

        Task<bool> DeleteVenueTypeAsync(int id, CancellationToken ct);

        Task<VenueType> UpdateVenueTypeAsync(VenueType venueType, CancellationToken ct);
    }
}
