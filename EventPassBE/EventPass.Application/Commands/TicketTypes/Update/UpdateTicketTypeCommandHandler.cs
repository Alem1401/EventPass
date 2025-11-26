using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.TicketTypes.Update
{
    public class UpdateTicketTypeCommandHandler : IRequestHandler<UpdateTicketTypeCommand,ResponseTicketTypeDTO>
    {
        public ITicketTypeRepository _repository;

        public UpdateTicketTypeCommandHandler(ITicketTypeRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResponseTicketTypeDTO> Handle(UpdateTicketTypeCommand request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllTicketTypesAsync(cancellationToken);
            var toUpdate = list.FirstOrDefault(t => t.Id == request.Id);
            if (toUpdate == null) {
                return null;
            }

            toUpdate.Price = request.updateTicket.Price;
            toUpdate.TicketsRemaining = request.updateTicket.TicketsRemaining;
            toUpdate.SectionID = request.updateTicket.SectionID;
            var response = await _repository.UpdateTicketTypeAsync(toUpdate, cancellationToken);
            return new ResponseTicketTypeDTO
            {
                Id = response.Id,
                Price = response.Price,
                TicketsRemaining = response.TicketsRemaining,
                EventName = response.Event.Name,
                SectionName = response.Section.Name,
               
            };
        }
    }
}
