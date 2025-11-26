using EventPass.Domain.Entities.Tickets;

namespace EventPass.Domain.Interfaces.Tickets
{
    public interface ITicketRepository
    {
        Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct);
        Task<Ticket> UpdateTicketAsync(Ticket ticket, CancellationToken ct);
        Task<Ticket> GetTicketByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync(CancellationToken ct);
        Task<bool> DeleteTicketAsync(Ticket ticket, CancellationToken ct);
    }
}
