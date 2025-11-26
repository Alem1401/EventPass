using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Queries.Sponsors.GetById
{
    public class GetSponsorByIdQuery : IRequest<ResponseSponsorDto>
    {
        public int Id { get; set; }
    }
}
