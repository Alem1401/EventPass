using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Tickets.GetTicketPdf
{
    public record GetTicketPdfQuery(int Id) : IRequest<byte[]>;
}
