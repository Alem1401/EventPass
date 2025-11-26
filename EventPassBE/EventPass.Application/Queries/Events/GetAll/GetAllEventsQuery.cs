using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Queries.Events.GetAll
{
   public class GetEventsQuery : IRequest<IEnumerable<ResponseEventDto>> { }
}
