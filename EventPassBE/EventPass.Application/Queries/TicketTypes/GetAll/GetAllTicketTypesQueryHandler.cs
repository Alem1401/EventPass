using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.TicketTypes.GetAll
{
    public class GetAllTicketTypesQueryHandler : IRequestHandler<GetAllTicketTypesQuery,IEnumerable<ResponseTicketTypeDTO>>
    {
        ITicketTypeRepository _repositry;


        public GetAllTicketTypesQueryHandler(ITicketTypeRepository repositry) 
        {
            _repositry = repositry;
        }

        public async Task<IEnumerable<ResponseTicketTypeDTO>> Handle(GetAllTicketTypesQuery request, CancellationToken cancellationToken)
        {
            var list = await _repositry.GetAllTicketTypesAsync(cancellationToken);
            return list.Select(tt => new ResponseTicketTypeDTO
            {
                Id = tt.Id,
                EventName = tt.Event.Name,
                 SectionName = tt.Section.Name,
                Price = tt.Price,
                TicketsRemaining = tt.TicketsRemaining
            });
        }
    }
}
