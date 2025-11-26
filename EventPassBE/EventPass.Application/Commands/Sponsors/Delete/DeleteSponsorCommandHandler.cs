using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Commands.Sponsors.Delete
{
    public class DeleteSponsorCommandHandler : IRequestHandler<DeleteSponsorCommand, bool>
    {
        private readonly ISponsorRepository _sponsorRepository;

        public DeleteSponsorCommandHandler(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<bool> Handle(DeleteSponsorCommand request, CancellationToken cancellationToken)
        {
            var sponsor = await _sponsorRepository.GetByIdAsync(request.Id, cancellationToken);

            if (sponsor == null)
                return false;

            await _sponsorRepository.DeleteAsync(sponsor, cancellationToken);
            return true;
        }
    }
}