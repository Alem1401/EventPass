using EventPass.Application.DTOs.PerformerDTOs;
using MediatR;

namespace EventPass.Application.Queries.Performers.GetById
{

    public class GetPerformerByIdQuery : IRequest<PerformerDto>
    {
        public int Id { get; set; }
    }
}