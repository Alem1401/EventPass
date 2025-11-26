using EventPass.Application.DTOs.PerformerDTOs;
using MediatR;

namespace EventPass.Application.Commands.Performers
{
    public class UpdatePerformerCommand : IRequest<PerformerDto>
    {
        public int Id { get; set; }
        public UpdatePerformerDto PerformerDto { get; set; }
    }
}