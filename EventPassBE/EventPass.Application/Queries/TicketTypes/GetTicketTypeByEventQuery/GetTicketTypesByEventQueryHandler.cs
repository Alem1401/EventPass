using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;

namespace EventPass.Application.Queries.TicketTypes.GetTicketTypeByEventQuery
{
    public class GetTicketTypesByEventQueryHandler : IRequestHandler<GetTicketTypesByEventQuery, IEnumerable<ResponseTicketTypeDTO>>
    {
        ITicketTypeRepository _repository;

        public GetTicketTypesByEventQueryHandler(ITicketTypeRepository ticketTypeRepository)
        {
            this._repository = ticketTypeRepository;
        }
        public async Task<IEnumerable<ResponseTicketTypeDTO>> Handle(GetTicketTypesByEventQuery request, CancellationToken ct)
        {
           var list = await _repository.GetAllTicketTypesAsync(ct);
            var response = list.Where(t => t.EventID== request.Id)
                .Select(t => new ResponseTicketTypeDTO
                {
                    Id = t.Id,
                    Price = t.Price,
                    TicketsRemaining = t.TicketsRemaining,
                    SectionName = t.Section.Name,
                    EventName = t.Event.Name
                });
            return response;
        }
    }
}
