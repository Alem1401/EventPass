using EventPass.Domain.Entities.TicketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Tickets
{
    public interface ITicketTypeRepository
    {
        Task<TicketType> AddTicketTypeAsync(TicketType ticketType, CancellationToken ct);
        Task<TicketType> UpdateTicketTypeAsync(TicketType ticketType, CancellationToken ct);

        Task<TicketType> GetTicketTypeByIdAsync(int id, CancellationToken ct);

        Task<IEnumerable<TicketType>> GetAllTicketTypesAsync(CancellationToken ct);

        Task<bool> DeleteTicketTypeAsync(TicketType ticketType, CancellationToken ct);

        public Task<bool> HasRelatedTicketsAsync(int ticketTypeId, CancellationToken ct);

    }
}
