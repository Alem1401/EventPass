using EventPass.Domain.Entities.TicketTypes;
using EventPass.Domain.Interfaces.Tickets;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Infrastructure.Repositories.Tickets
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        public EventPassDbContext _context;

        public TicketTypeRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<TicketType> AddTicketTypeAsync(TicketType ticketType, CancellationToken ct)
        {
            _context.TicketTypes.AddAsync(ticketType);
            await _context.SaveChangesAsync(ct);


            return await _context.TicketTypes
              .Include(t => t.Event)
                .Include(t => t.Section)
                .FirstOrDefaultAsync(t => t.Id == ticketType.Id, ct);
        }


        public async Task<bool> DeleteTicketTypeAsync(TicketType ticketType, CancellationToken ct)
        {
            _context.TicketTypes.Remove(ticketType);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<IEnumerable<TicketType>> GetAllTicketTypesAsync(CancellationToken ct)
        {
            return await _context.TicketTypes.Include(t => t.Event).Include(t => t.Section).ToListAsync(ct);
        }

        public async Task<TicketType> GetTicketTypeByIdAsync(int id, CancellationToken ct)
        {
            return await _context.TicketTypes.FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public async Task<TicketType> UpdateTicketTypeAsync(TicketType ticketType, CancellationToken ct)
        {
            _context.TicketTypes.Update(ticketType);
            await _context.SaveChangesAsync(ct);

            return await _context.TicketTypes
                .Include(t => t.Event)
                .Include(t => t.Section)
                .FirstOrDefaultAsync(t => t.Id == ticketType.Id, ct);
        }

        public async Task<bool> HasRelatedTicketsAsync(int ticketTypeId, CancellationToken ct)
        {
            return await _context.Tickets.AnyAsync(t => t.TicketTypeID == ticketTypeId, ct);
        }
    }
}
