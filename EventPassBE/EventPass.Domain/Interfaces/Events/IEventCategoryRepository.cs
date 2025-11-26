using EventPass.Domain.Entities.EventCategories;

namespace EventPass.Domain.Interfaces
{
    public interface IEventCategoryRepository
    {
        Task<EventCategory> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<EventCategory>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<EventCategory>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<EventCategory> AddAsync(EventCategory eventCategory, CancellationToken cancellationToken = default);
        Task<EventCategory> UpdateAsync(EventCategory eventCategory, CancellationToken cancellationToken = default);
        Task DeleteAsync(EventCategory eventCategory, CancellationToken cancellationToken = default);
    }
}