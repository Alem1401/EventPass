using MediatR;

namespace EventPass.Application.Commands.EventCategories.Delete
{
    public class DeleteEventCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}