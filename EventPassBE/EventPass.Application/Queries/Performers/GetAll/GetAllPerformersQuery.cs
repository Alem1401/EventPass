using EventPass.Application.DTOs.PerformerDTOs;
using MediatR;

namespace EventPass.Application.Queries.Performers.GetAll
{
    public class GetAllPerformersQuery : IRequest<IEnumerable<PerformerDto>> { }
}