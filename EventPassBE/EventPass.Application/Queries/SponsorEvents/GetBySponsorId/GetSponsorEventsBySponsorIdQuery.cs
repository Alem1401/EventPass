using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Queries.SponsorEvents.GetBySponsorId
{
    public class GetSponsorEventsBySponsorIdQuery: IRequest<IEnumerable<ResponseSponsorEventDto>>
    {
        public int sponsorId { get; set; }
    }
}
