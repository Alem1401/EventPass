using EventPass.Application.DTOs.TicketDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.TicketTypes.Update
{
    public class UpdateTicketTypeCommand : IRequest<ResponseTicketTypeDTO>
    {
        public int Id { get; set; }

        public UpdateTicketTypeDTO updateTicket{ get; set; }
    }
}
