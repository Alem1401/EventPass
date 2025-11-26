using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Commands.EventCategories.Update
{
    public class UpdateEventCategoryCommand : IRequest<EventCategoryResponseDto>
    {
        public int Id { get; set; }
        public UpdateEventCategoryDto EventCategoryDto { get; set; }
    }
}