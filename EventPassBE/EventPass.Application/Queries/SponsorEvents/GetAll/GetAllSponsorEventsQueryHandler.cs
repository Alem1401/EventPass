using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Queries.SponsorEvents.GetAll
{
    public class GetAllSponsorEventsQueryHandler: IRequestHandler<GetAllSponsorEventsQuery, IEnumerable<ResponseSponsorEventDto>>
    {
        ISponsorEventRepository _respository;

        public GetAllSponsorEventsQueryHandler(ISponsorEventRepository respository)
        {
            _respository = respository;
        }

        public async Task<IEnumerable<ResponseSponsorEventDto>> Handle(GetAllSponsorEventsQuery query, CancellationToken cancellationToken)
        {
            var sponsorEvents = await _respository.GetAllSponsorEventsAsync(cancellationToken);
            if(sponsorEvents == null)  return null;
            return sponsorEvents.Select(se => new ResponseSponsorEventDto
            {
                Id = se.Id,
                tier = se.Tier,
                amountSponsored = se.AmountSponsored,
                sponsorId = (int)se.SponsorID,
                eventId = (int)se.EventID
            });
        }
    }
}
