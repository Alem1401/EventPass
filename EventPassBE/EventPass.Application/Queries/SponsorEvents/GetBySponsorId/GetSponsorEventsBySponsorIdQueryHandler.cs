using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Queries.SponsorEvents.GetBySponsorId
{
    public class GetSponsorEventsBySponsorIdQueryHandler: IRequestHandler<GetSponsorEventsBySponsorIdQuery, IEnumerable<ResponseSponsorEventDto>>
    {
        ISponsorEventRepository _repository;

        public GetSponsorEventsBySponsorIdQueryHandler(ISponsorEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseSponsorEventDto>> Handle(GetSponsorEventsBySponsorIdQuery query, CancellationToken cancellationToken)
        {
            var sponsorEvents = await _repository.GetSponsorEventBySponsorIdAsync(query.sponsorId, cancellationToken);
            if (sponsorEvents == null) return null;
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
