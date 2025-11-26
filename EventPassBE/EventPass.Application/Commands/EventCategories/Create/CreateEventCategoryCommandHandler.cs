using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Entities.EventCategories;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.EventCategories.Create
{
    public class CreateEventCategoryCommandHandler : IRequestHandler<CreateEventCategoryCommand, EventCategoryResponseDto>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public CreateEventCategoryCommandHandler(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }

        public async Task<EventCategoryResponseDto> Handle(CreateEventCategoryCommand request, CancellationToken cancellationToken)
        {
            var eventCategory = new EventCategory
            {
                Name = request.EventCategoryDto.Name,
                Description = request.EventCategoryDto.Description,
                IconUrl = request.EventCategoryDto.IconUrl
            };

            var createdCategory = await _eventCategoryRepository.AddAsync(eventCategory, cancellationToken);

            return new EventCategoryResponseDto
            {
                ID = createdCategory.ID,
                Name = createdCategory.Name,
                Description = createdCategory.Description,
                IconUrl = createdCategory.IconUrl,
                EventCount = 0
            };
        }
    }
}