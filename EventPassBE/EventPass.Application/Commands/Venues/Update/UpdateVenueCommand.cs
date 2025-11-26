using EventPass.Application.DTOs.VenueDTOs;
using MediatR;

namespace EventPass.Application.Commands.Venues.Update
{
    public class UpdateVenueCommand : IRequest<ResponseVenueDto>
    {
        public int Id { get; set; } 
        public UpdateVenueDto updateVenueDto { get; set; }
    }
}
