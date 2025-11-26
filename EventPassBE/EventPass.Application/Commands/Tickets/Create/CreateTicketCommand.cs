using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Entities.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Tickets.Create
{
    public class CreateTicketCommand : IRequest<ResponseTicketDTO>
    {
        public int UserId { get; set; }
        public int TicketTypeId { get; set; }

    }
}
