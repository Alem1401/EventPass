using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Commands.SponsorEvents.Delete
{
    public class DeleteSponsorEventCommandHandler: IRequestHandler<DeleteSponsorEventCommand, bool>
    {
        ISponsorEventRepository _repository;

        public DeleteSponsorEventCommandHandler(ISponsorEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteSponsorEventCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteSponsorEventAsync(command.Id, cancellationToken);
        }
    }
}
