using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.EventCategories.Update
{
    public class UpdateEventCategoryCommandHandler : IRequestHandler<UpdateEventCategoryCommand, EventCategoryResponseDto>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public UpdateEventCategoryCommandHandler(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }

        public async Task<EventCategoryResponseDto> Handle(UpdateEventCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _eventCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingCategory == null)
                return null;

            existingCategory.Name = request.EventCategoryDto.Name;
            existingCategory.Description = request.EventCategoryDto.Description;
            existingCategory.IconUrl = request.EventCategoryDto.IconUrl;

            var updatedCategory = await _eventCategoryRepository.UpdateAsync(existingCategory, cancellationToken);

            return new EventCategoryResponseDto
            {
                ID = updatedCategory.ID,
                Name = updatedCategory.Name,
                Description = updatedCategory.Description,
                IconUrl = updatedCategory.IconUrl,
                EventCount = updatedCategory.Events?.Count ?? 0
            };
        }
    }
}