using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Queries.EventCategories.GetById
{
    public class GetEventCategoryByIdQuery : IRequest<EventCategoryResponseDto>
    {
        public int Id { get; set; }
    }
}