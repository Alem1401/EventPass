using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Entities.SponsorEvents;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Commands.SponsorEvents.Create
{
    public class CreateSponsorEventCommandHandler: IRequestHandler<CreateSponsorEventCommand, ResponseSponsorEventDto>
    {
        ISponsorEventRepository _repository;

        public CreateSponsorEventCommandHandler(ISponsorEventRepository repository)
        {
            _repository = repository;
        }   

        public async Task<ResponseSponsorEventDto> Handle(CreateSponsorEventCommand command, CancellationToken cancellationToken)
        {
            var newSponsorEvent = new SponsorEvent
            {
                Tier = command.dto.tier,
                AmountSponsored = command.dto.amountSponsored,
                SponsorID = command.dto.sponsorId,
                EventID = command.dto.eventId
            };

            var response = await _repository.AddSponsorEventAsync(newSponsorEvent, cancellationToken);

            return new ResponseSponsorEventDto
            {
                Id = response.Id,
                tier = response.Tier,
                amountSponsored = response.AmountSponsored,
                sponsorId = response.SponsorID,
                eventId = response.EventID
            };
        }
    }
}
