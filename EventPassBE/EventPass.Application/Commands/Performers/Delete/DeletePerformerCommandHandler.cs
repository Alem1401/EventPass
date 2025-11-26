using EventPass.Application.Commands.Performers;
using EventPass.Domain.Interfaces.Performers;
using MediatR;

namespace EventPass.Application.Handlers.Performers
{
    public class DeletePerformerCommandHandler : IRequestHandler<DeletePerformerCommand, bool>
    {
        private readonly IPerformerRepository _performerRepository;

        public DeletePerformerCommandHandler(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }

        public async Task<bool> Handle(DeletePerformerCommand request, CancellationToken cancellationToken)
        {
            var performer = await _performerRepository.GetPerformerByIdAsync(request.Id);

            if (performer == null)
                return false;

            await _performerRepository.DeletePerformerAsync(performer);
            return true;
        }
    }
}