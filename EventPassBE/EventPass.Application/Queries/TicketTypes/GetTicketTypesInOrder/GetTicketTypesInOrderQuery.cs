using EventPass.Application.DTOs.TicketDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.TicketTypes.GetTicketTypesInOrder
{
    public class GetTicketTypesInOrderQuery : IRequest<IEnumerable<ResponseTicketTypeDTO>>
    {
        public int EventId { get; set; }

        public string OrderBy { get; set; }
    }
}
