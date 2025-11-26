using EventPass.Domain.Entities.Events;

namespace EventPass.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Event>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Event>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Event> AddAsync(Event @event, CancellationToken cancellationToken = default);
        Task<Event> UpdateAsync(Event @event, CancellationToken cancellationToken = default);
        Task DeleteAsync(Event @event, CancellationToken cancellationToken = default);
        }
    }