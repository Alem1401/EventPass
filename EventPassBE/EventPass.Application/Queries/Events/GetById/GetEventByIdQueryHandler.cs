using EventPass.Application.DTOs.EventDTOs;
using EventPass.Application.Queries.Events.GetById;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.Events.BetById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, ResponseEventDto>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ResponseEventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id, cancellationToken);

            if (@event == null)
                return null;

            return new ResponseEventDto
            {
                Id = @event.Id,
                Name = @event.Name,
                Description = @event.Description,
                BannerURL = @event.BannerURL,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                Duration = @event.Duration,
                MinimumAge = @event.MinimumAge,
                PerformerID = @event.PerformerID,
                PerformerName = @event.Performer?.Name,
                CategoryId = @event.CategoryId,
                CategoryName = @event.Category?.Name,
                OrganizerID = @event.OrganizerID,
                OrganizerName = @event.Organizer?.Name
            };
        }
    }
}