using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Queries.Sponsors.GetByName
{
    public class GetSponsorsByNameQuery : IRequest<IEnumerable<ResponseSponsorDto>>
    {
        public string Name { get; set; }
    }
}
