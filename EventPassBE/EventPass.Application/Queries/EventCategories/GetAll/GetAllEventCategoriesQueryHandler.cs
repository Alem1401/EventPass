using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.EventCategories.GetAll
{
    public class GetAllEventCategoriesQueryHandler : IRequestHandler<GetAllEventCategoriesQuery, IEnumerable<EventCategoryResponseDto>>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public GetAllEventCategoriesQueryHandler(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }

        public async Task<IEnumerable<EventCategoryResponseDto>> Handle(GetAllEventCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _eventCategoryRepository.GetAllAsync(cancellationToken);

            return categories.Select(ec => new EventCategoryResponseDto
            {
                ID = ec.ID,
                Name = ec.Name,
                Description = ec.Description,
                IconUrl = ec.IconUrl,
                EventCount = ec.Events?.Count ?? 0
            });
        }
    }
}