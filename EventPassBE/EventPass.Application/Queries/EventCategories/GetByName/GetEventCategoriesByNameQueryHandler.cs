using EventPass.Application.DTOs.EventDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.EventCategories.GetByName
{
    public class GetEventCategoriesByNameQueryHandler : IRequestHandler<GetEventCategoriesByNameQuery, IEnumerable<EventCategoryResponseDto>>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public GetEventCategoriesByNameQueryHandler(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }

        public async Task<IEnumerable<EventCategoryResponseDto>> Handle(GetEventCategoriesByNameQuery request, CancellationToken cancellationToken)
        {
            var categories = await _eventCategoryRepository.GetByNameAsync(request.Name, cancellationToken);

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