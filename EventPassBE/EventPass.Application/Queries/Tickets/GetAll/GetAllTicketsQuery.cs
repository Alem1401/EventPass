using EventPass.Application.DTOs.TicketDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Tickets.GetAll
{
    public class GetAllTicketsQuery : IRequest<IEnumerable<ResponseTicketDTO>>
    {
    }
}
