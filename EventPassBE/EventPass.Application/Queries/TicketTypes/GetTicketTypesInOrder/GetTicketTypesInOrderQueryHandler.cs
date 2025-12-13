using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.TicketTypes.GetTicketTypesInOrder
{
    public class GetTicketTypesInOrderQueryHandler : IRequestHandler<GetTicketTypesInOrderQuery, IEnumerable<ResponseTicketTypeDTO>>
    {
        ITicketTypeRepository _repository;

        public GetTicketTypesInOrderQueryHandler(ITicketTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ResponseTicketTypeDTO>> Handle(GetTicketTypesInOrderQuery request, CancellationToken cancellationToken)
        {
            var ticketTypes = await _repository.GetAllTicketTypesAsync(cancellationToken);
            var filteredTicketTypes = ticketTypes.Where(tt => tt.EventID == request.EventId);

            var orderBy = request.OrderBy?.ToLower();

            if (orderBy == "price-high-low")
            {
                filteredTicketTypes = filteredTicketTypes.OrderByDescending(tt => tt.Price);
            }
            else if (orderBy == "price-low-high")
            {
                filteredTicketTypes = filteredTicketTypes.OrderBy(tt => tt.Price);
            }
            else if (orderBy == "available-high-low")
            {
                filteredTicketTypes = filteredTicketTypes.OrderByDescending(tt => tt.TicketsRemaining);
            }
            else if (orderBy == "available-low-high")
            {
                filteredTicketTypes = filteredTicketTypes.OrderBy(tt => tt.TicketsRemaining);
            }
            else if (orderBy == "name-az")
            {
                filteredTicketTypes = filteredTicketTypes.OrderBy(tt => tt.Section.Name);
            }
            else if (orderBy == "name-za")
            {
                filteredTicketTypes = filteredTicketTypes.OrderByDescending(tt => tt.Section.Name);
            }

            return filteredTicketTypes.Select(tt => new ResponseTicketTypeDTO
            {
                Id = tt.Id,
                Price = tt.Price,
                TicketsRemaining = tt.TicketsRemaining,
                SectionName = tt.Section.Name,
                EventName = tt.Event.Name
            });
        }
    }
}
