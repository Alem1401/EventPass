using EventPass.Application.DTOs.TicketDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.TicketTypes.Create
{
    public class CreateTicketTypeCommand : IRequest<ResponseTicketTypeDTO>
    {
        public decimal Price { get; set; }
        public int TicketsRemaining { get; set; }
        public int SectionID { get; set; }
       
        public int EventID { get; set; }
    }
}
