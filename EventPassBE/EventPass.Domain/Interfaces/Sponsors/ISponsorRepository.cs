using EventPass.Domain.Entities.Sponsors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Sponsors
{
    public interface ISponsorRepository
    {
        Task<Sponsor> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Sponsor>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Sponsor>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Sponsor> AddAsync(Sponsor sponsor, CancellationToken cancellationToken = default);
        Task<Sponsor> UpdateAsync(Sponsor sponsor, CancellationToken cancellationToken = default);
        Task DeleteAsync(Sponsor sponsor, CancellationToken cancellationToken = default);
    }
}
