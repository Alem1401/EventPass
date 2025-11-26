using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.Events.Update
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ResponseEventDto>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ResponseEventDto> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingEvent == null)
                return null;

            existingEvent.Name = request.EventDto.Name;
            existingEvent.Description = request.EventDto.Description;
            existingEvent.BannerURL = request.EventDto.BannerURL;
            existingEvent.StartDate = request.EventDto.StartDate;
            existingEvent.EndDate = request.EventDto.EndDate;
            existingEvent.Duration = request.EventDto.Duration;
            existingEvent.MinimumAge = request.EventDto.MinimumAge;
            existingEvent.PerformerID = request.EventDto.PerformerID;
            existingEvent.CategoryId = request.EventDto.CategoryId;
            existingEvent.OrganizerID = request.EventDto.OrganizerID;

            var updatedEvent = await _eventRepository.UpdateAsync(existingEvent, cancellationToken);

            return new ResponseEventDto
            {
                Id = updatedEvent.Id,
                Name = updatedEvent.Name,
                Description = updatedEvent.Description,
                BannerURL = updatedEvent.BannerURL,
                StartDate = updatedEvent.StartDate,
                EndDate = updatedEvent.EndDate,
                Duration = updatedEvent.Duration,
                MinimumAge = updatedEvent.MinimumAge,
                PerformerID = updatedEvent.PerformerID,
                PerformerName = updatedEvent.Performer?.Name,
                CategoryId = updatedEvent.CategoryId,
                CategoryName = updatedEvent.Category?.Name,
                OrganizerID = updatedEvent.OrganizerID,
                OrganizerName = updatedEvent.Organizer?.Name
            };
        }
    }
}