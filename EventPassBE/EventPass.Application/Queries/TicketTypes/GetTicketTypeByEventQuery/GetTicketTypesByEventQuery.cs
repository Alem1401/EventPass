using EventPass.Application.DTOs.TicketDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.TicketTypes.GetTicketTypeByEventQuery
{
    public class GetTicketTypesByEventQuery : IRequest<IEnumerable<ResponseTicketTypeDTO>>
    {
       public int Id { get; set; }
    }
}
