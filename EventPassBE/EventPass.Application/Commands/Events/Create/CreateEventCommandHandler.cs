using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Entities.Events;
using EventPass.Domain.Interfaces;
using MediatR;
using System.Threading;

namespace EventPass.Application.Commands.Events.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ResponseEventDto>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ResponseEventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = new Event
            {
                Name = request.EventDto.Name,
                Description = request.EventDto.Description,
                BannerURL = request.EventDto.BannerURL,
                StartDate = request.EventDto.StartDate,
                EndDate = request.EventDto.EndDate,
                Duration = request.EventDto.Duration,
                MinimumAge = request.EventDto.MinimumAge,
                PerformerID = request.EventDto.PerformerID,
                CategoryId = request.EventDto.CategoryId,
                OrganizerID = request.EventDto.OrganizerID
    };

    var createdEvent = await _eventRepository.AddAsync(@event, cancellationToken);

            return new ResponseEventDto
            {
                Id = createdEvent.Id,
                Name = createdEvent.Name,
                Description = createdEvent.Description,
                BannerURL = createdEvent.BannerURL,
                StartDate = createdEvent.StartDate,
                EndDate = createdEvent.EndDate,
                Duration = createdEvent.Duration,
                MinimumAge = createdEvent.MinimumAge,
                PerformerID = createdEvent.PerformerID,
                CategoryId = createdEvent.CategoryId,
                OrganizerID = createdEvent.OrganizerID
};
        }
    }
}