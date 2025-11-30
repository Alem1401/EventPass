using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Commands.SponsorEvents.Update
{
    public class UpdateSponsorEventCommandHandler: IRequestHandler<UpdateSponsorEventCommand, ResponseSponsorEventDto>
    {
        ISponsorEventRepository _repository;

        public UpdateSponsorEventCommandHandler(ISponsorEventRepository repository)
        {
            _repository = repository;   
        }

        public async Task<ResponseSponsorEventDto> Handle(UpdateSponsorEventCommand command, CancellationToken cancellationToken)
        {
            var sponsorEvent = await _repository.GetSponsorEventByIdAsync(command.dto.Id, cancellationToken);

            sponsorEvent.Tier = command.dto.tier;
            sponsorEvent.AmountSponsored = command.dto.amountSponsored;
            sponsorEvent.EventID = command.dto.eventId;
            sponsorEvent.SponsorID = command.dto.sponsorId;

            var response = await _repository.UpdateSponsorEventAsync(sponsorEvent, cancellationToken);
            return new ResponseSponsorEventDto
            {
                Id = response.Id,
                tier = response.Tier,
                amountSponsored = response.AmountSponsored,
                sponsorId = (int)response.SponsorID,
                eventId = (int)response.EventID
            };
        }
    }
}
