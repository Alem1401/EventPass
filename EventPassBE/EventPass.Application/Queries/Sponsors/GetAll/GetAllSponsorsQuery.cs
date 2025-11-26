using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Queries.Sponsors.GetAll
{
    public class GetAllSponsorsQuery : IRequest<IEnumerable<ResponseSponsorDto>> { }
}