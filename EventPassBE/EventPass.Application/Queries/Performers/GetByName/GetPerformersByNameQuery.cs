using EventPass.Application.DTOs;
using EventPass.Application.DTOs.PerformerDTOs;
using MediatR;

namespace EventPass.Application.Queries.Performers.GetByName
{
    public class GetPerformersByNameQuery : IRequest<IEnumerable<PerformerDto>>
    {
        public string Name { get; set; }
    }
}