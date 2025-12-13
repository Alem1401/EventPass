using EventPass.Domain.Entities.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Services
{
    public interface IPdfService
    {
        public Task<byte[]> createTicketPdf(int id, CancellationToken ct);
    }
}
