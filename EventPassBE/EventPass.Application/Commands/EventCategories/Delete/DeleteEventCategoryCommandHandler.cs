using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.EventCategories.Delete
{
    public class DeleteEventCategoryCommandHandler : IRequestHandler<DeleteEventCategoryCommand, bool>
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public DeleteEventCategoryCommandHandler(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }

        public async Task<bool> Handle(DeleteEventCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _eventCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category == null)
                return false;

            await _eventCategoryRepository.DeleteAsync(category, cancellationToken);
            return true;
        }
    }
}