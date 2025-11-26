using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Commands.SponsorEvents.Update
{
    public class UpdateSponsorEventCommand: IRequest<ResponseSponsorEventDto>
    {
        public ResponseSponsorEventDto dto { get; set; }
    }
}
