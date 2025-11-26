using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Queries.SponsorEvents.GetAll
{
    public class GetAllSponsorEventsQuery: IRequest<IEnumerable<ResponseSponsorEventDto>>
    {
    }
}
