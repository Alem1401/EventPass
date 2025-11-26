using EventPass.Application.Commands.Venues.Create;
using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Entities.TicketTypes;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.TicketTypes.Create
{
    public class CreateTicketTypeHandler : IRequestHandler<CreateTicketTypeCommand, ResponseTicketTypeDTO>
    {
        ITicketTypeRepository _repository;

        public CreateTicketTypeHandler(ITicketTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseTicketTypeDTO> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
        {
           


            var exists = (await _repository.GetAllTicketTypesAsync(cancellationToken))
                 .Any(t => t.EventID == request.EventID && t.SectionID == request.SectionID);

            if (exists)
                throw new InvalidOperationException("Ticket type for this section and event already exists."); 

            var newTicketType = new TicketType
            {
                Price = request.Price,
                TicketsRemaining = request.TicketsRemaining,
                SectionID = request.SectionID,
                EventID = request.EventID
            };

            var saved = await _repository.AddTicketTypeAsync(newTicketType, cancellationToken);

            return new ResponseTicketTypeDTO
            {
                Id = saved.Id,
                Price = saved.Price,
                TicketsRemaining = saved.TicketsRemaining,
                SectionName = saved.Section?.Name,
          
                EventName = saved.Event?.Name
            };
        }
    }
}