using EventPass.Application.DTOs.PerformerDTOs;
using EventPass.Application.DTOs.PerformerDTOs;
using MediatR;

namespace EventPass.Application.Commands.Performers
{
    public class CreatePerformerCommand : IRequest<PerformerDto>
    {
        public CreatePerformerDto PerformerDto { get; set; }
    }
}