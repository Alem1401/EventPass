using EventPass.Application.DTOs.SponsorDTOs;
using MediatR;

namespace EventPass.Application.Commands.SponsorEvents.Create
{
    public class CreateSponsorEventCommand: IRequest<ResponseSponsorEventDto>
    {
        public CreateSponsorEventDto dto {  get; set; }
    }
}
