using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.EventCategories.GetById
{
    public class GetEventCategoryByIdQueryHandler : IRequestHandler<GetEventCategoryByIdQuery, EventCategoryResponseDto>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public GetEventCategoryByIdQueryHandler(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }

        public async Task<EventCategoryResponseDto> Handle(GetEventCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _eventCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category == null)
                return null;

            return new EventCategoryResponseDto
            {
                ID = category.ID,
                Name = category.Name,
                Description = category.Description,
                IconUrl = category.IconUrl,
                EventCount = category.Events?.Count ?? 0
            };
        }
    }
}