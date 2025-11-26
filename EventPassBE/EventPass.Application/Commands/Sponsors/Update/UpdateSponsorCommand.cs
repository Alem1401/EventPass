using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Commands.Sponsors.Update
{
    public class UpdateSponsorCommand : IRequest<ResponseSponsorDto>
    {
        public int Id { get; set; }
        public UpdateSponsorDto SponsorDto { get; set; }
    }
}