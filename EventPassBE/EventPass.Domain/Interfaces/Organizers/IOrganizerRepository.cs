using EventPass.Domain.Entities.Organizers;

namespace EventPass.Domain.Interfaces
{
    public interface IOrganizerRepository
    {
        Task<Organizer> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Organizer>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Organizer>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Organizer> AddAsync(Organizer organizer, CancellationToken cancellationToken = default);
        Task<Organizer> UpdateAsync(Organizer organizer, CancellationToken cancellationToken = default);
        Task DeleteAsync(Organizer organizer, CancellationToken cancellationToken = default);
    }
}