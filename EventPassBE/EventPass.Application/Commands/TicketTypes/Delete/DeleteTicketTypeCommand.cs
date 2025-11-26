using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.TicketTypes.Delete
{
    public class DeleteTicketTypeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
