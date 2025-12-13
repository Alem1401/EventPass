using EventPass.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Tickets.GetTicketPdf
{
    public class GetTicketPdfQueryHandler : IRequestHandler<GetTicketPdfQuery, byte[]>
    { 
        private readonly IPdfService _pdfService;
        public GetTicketPdfQueryHandler(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }
        public async Task<byte[]> Handle(GetTicketPdfQuery request, CancellationToken cancellationToken)
        {
            var pdf  =await _pdfService.createTicketPdf(request.Id,cancellationToken);
            return pdf;
        }   
    }
}
