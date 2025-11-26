using EventPass.Domain.Entities.Tickets;
using EventPass.Domain.Interfaces.Tickets;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace EventPass.Infrastructure.Repositories.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        public EventPassDbContext _context;

        public TicketRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync(ct);
            return ticket;

        }

        public async Task<bool> DeleteTicketAsync(Ticket ticket, CancellationToken ct)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync(CancellationToken ct)
        {
            return await _context.Tickets.Include(t => t.TicketType).ToListAsync(ct);
        }

        public async Task<Ticket> GetTicketByIdAsync(int id, CancellationToken ct)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id, ct);
            return ticket;
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket ticket, CancellationToken ct)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync(ct);
            return ticket;
        }
    }
}
