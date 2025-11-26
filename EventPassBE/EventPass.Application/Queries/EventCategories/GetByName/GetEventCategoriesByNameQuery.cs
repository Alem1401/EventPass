using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Queries.EventCategories.GetByName
{
    public class GetEventCategoriesByNameQuery : IRequest<IEnumerable<EventCategoryResponseDto>>
    {
        public string Name { get; set; }
    }
}