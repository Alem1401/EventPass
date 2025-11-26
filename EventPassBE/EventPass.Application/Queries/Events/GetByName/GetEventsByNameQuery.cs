using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Queries.Events.GetByName
{
    public class GetEventsByNameQuery : IRequest<IEnumerable<ResponseEventDto>>
    {
        public string Name { get; set; }
    }
}
