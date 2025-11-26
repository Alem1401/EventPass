using EventPass.Domain.Entities.Performers;

namespace EventPass.Domain.Interfaces.Performers
{
    public interface IPerformerRepository
    {
        Task<Performer> GetPerformerByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Performer>> GetAllPerformersAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Performer>> GetPerformerByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Performer> AddPerformerAsync(Performer performer, CancellationToken cancellationToken = default);
        Task<Performer> UpdatePerformerAsync(Performer performer, CancellationToken cancellationToken = default);
        Task DeletePerformerAsync(Performer performer, CancellationToken cancellationToken = default);
    }
}