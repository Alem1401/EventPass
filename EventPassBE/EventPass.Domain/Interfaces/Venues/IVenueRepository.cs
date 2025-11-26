using EventPass.Domain.Entities.Venues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Venues
{
    public interface IVenueRepository
    {
        Task<Venue> AddVenueAsync(Venue venue, CancellationToken ct);
        Task<Venue> UpdateVenueAsync(Venue venue, CancellationToken ct);

        Task<Venue> GetVenueByIdAsync(int id, CancellationToken ct);

        Task<IEnumerable<Venue>> GetAllVenuesAsync(CancellationToken ct);

        Task<bool> DeleteVenueAsync(Venue venue, CancellationToken ct);

    }
}
