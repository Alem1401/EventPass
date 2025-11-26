using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Commands.EventCategories.Create
{
    public class CreateEventCategoryCommand : IRequest<EventCategoryResponseDto>
    {
        public CreateEventCategoryDto EventCategoryDto { get; set; }
    }
}