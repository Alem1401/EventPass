using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Queries.EventCategories.GetAll
{
    public class GetAllEventCategoriesQuery : IRequest<IEnumerable<EventCategoryResponseDto>> { }
}