using EventPass.Domain.Entities.SponsorEvents;

namespace EventPass.Domain.Interfaces.Sponsors
{
    public interface ISponsorEventRepository
    {
        Task<IEnumerable<SponsorEvent>> GetSponsorEventBySponsorIdAsync(int id, CancellationToken cancellationToken = default);
        Task<SponsorEvent> GetSponsorEventByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<SponsorEvent>> GetAllSponsorEventsAsync(CancellationToken cancellationToken = default);
        Task<SponsorEvent> AddSponsorEventAsync(SponsorEvent sponsorEvent, CancellationToken cancellationToken = default);
        Task<SponsorEvent> UpdateSponsorEventAsync(SponsorEvent sponsorEvent, CancellationToken cancellationToken = default);
        Task<bool> DeleteSponsorEventAsync(int id, CancellationToken cancellationToken = default);
    }
}
