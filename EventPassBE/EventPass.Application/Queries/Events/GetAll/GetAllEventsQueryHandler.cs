using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.Events.GetAll
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<ResponseEventDto>>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<ResponseEventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAllAsync(cancellationToken);

            return events.Select(e => new ResponseEventDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                BannerURL = e.BannerURL,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Duration = e.Duration,
                MinimumAge = e.MinimumAge,
                PerformerID = e.PerformerID,
                PerformerName = e.Performer?.Name,
                CategoryId = e.CategoryId,
                CategoryName = e.Category?.Name,
                OrganizerID = e.OrganizerID,
                OrganizerName = e.Organizer?.Name
            });
        }
    }
}
