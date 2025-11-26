using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Queries.Events.GetById
{
    public class GetEventByIdQuery : IRequest<ResponseEventDto>
    {
        public int Id { get; set; }
    }
}