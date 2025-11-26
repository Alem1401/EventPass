using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Commands.Sponsors.Create
{
    public class CreateSponsorCommand : IRequest<ResponseSponsorDto>
    {
        public CreateSponsorDto SponsorDto { get; set; }
    }
}