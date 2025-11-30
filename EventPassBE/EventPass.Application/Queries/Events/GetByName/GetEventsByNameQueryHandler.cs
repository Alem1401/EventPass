using EventPass.Application.DTOs.EventDTOs;
using EventPass.Application.Queries.Events.GetByName;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.Events.GetEventsByName
{
    public class GetEventsByNameQueryHandler : IRequestHandler<GetEventsByNameQuery, IEnumerable<ResponseEventDto>>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsByNameQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<ResponseEventDto>> Handle(GetEventsByNameQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetByNameAsync(request.Name, cancellationToken);

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
                PerformerID = (int)e.PerformerID,
                PerformerName = e.Performer?.Name,
                CategoryId = (int)e.CategoryId,
                CategoryName = e.Category?.Name,
                OrganizerID =  (int)e.OrganizerID,
                OrganizerName = e.Organizer?.Name,
                VenueId = (int)e.VenueId
            });
        }
    }
}