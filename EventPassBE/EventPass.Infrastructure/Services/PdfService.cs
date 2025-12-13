using EventPass.Domain.Entities.Tickets;
using EventPass.Domain.Interfaces.Services;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Infrastructure.Services
{
 
    public class PdfService : IPdfService
    {
        
        private readonly EventPassDbContext _context;

        private readonly IQrService _qrService;
        public PdfService(EventPassDbContext context, IQrService qrService)
        {
            _context = context;
            _qrService = qrService;
        }
        public async Task<byte[]> createTicketPdf(int id, CancellationToken ct)
        {
            
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id, ct);
            if (ticket == null)
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");

            var currentType = await _context.TicketTypes.Include(e => e.Event)
                .ThenInclude(e => e.Venue)
                .Include(e => e.Event)
                .ThenInclude(e => e.Performer)
                .Include(e => e.Section)
                .Where(t => t.Id == ticket.TicketTypeID)
                .FirstOrDefaultAsync(ct);
            
            if (currentType == null)
                throw new KeyNotFoundException($"Ticket type with ID {ticket.TicketTypeID} not found.");

            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == ticket.UserID, ct);
            if (currentUser == null)
                throw new KeyNotFoundException($"User with ID {ticket.UserID} not found.");

            var qrBytes = _qrService.GenerateQrCode("youtube.com"); // to be replaced with actual data this is currently placeholder

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.Content().Column(column =>
                    {

                        column.Item().BorderBottom(2).BorderColor(Colors.Blue.Medium).PaddingBottom(10).Column(headerColumn =>
                        {
                            headerColumn.Item().Text("EVENT TICKET").Bold().FontSize(28).FontColor(Colors.Blue.Darken2).AlignCenter();
                            headerColumn.Item().Text("Admit One").FontSize(12).FontColor(Colors.Grey.Darken1).AlignCenter();
                        });

                        column.Item().PaddingTop(20);


                        column.Item().Background(Colors.Blue.Lighten4).Padding(15).Column(eventColumn =>
                        {
                            eventColumn.Item().Text($"{currentType.Event.Name}  {currentType.Event.Venue.Name}").Bold().FontSize(24).FontColor(Colors.Blue.Darken3);
                            eventColumn.Item().Text(currentType.Event.StartDate.ToString("MMMM dd, yyyy")).FontSize(12);
                        });

                        column.Item().PaddingTop(20);


                        column.Item().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(15).Column(guestColumn =>
                        {
                            guestColumn.Item().Text("Guest Information").Bold().FontSize(14).FontColor(Colors.Grey.Darken2);
                            guestColumn.Item().PaddingTop(10).Row(row =>
                            {
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text("Owner").FontSize(10).FontColor(Colors.Grey.Medium);
                                    col.Item().Text($"{currentUser.Name} {currentUser.Surname}").Bold().FontSize(16).FontColor(Colors.Black);
                                });
                            });
                        });

                        column.Item().PaddingTop(15);


                        column.Item().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(15).Column(seatColumn =>
                        {
                            seatColumn.Item().Text("Seating Details").Bold().FontSize(14).FontColor(Colors.Grey.Darken2);
                            seatColumn.Item().PaddingTop(10).Row(row =>
                            {
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text("Section").FontSize(10).FontColor(Colors.Grey.Medium);
                                    col.Item().Text($"{currentType.Section.Name}").Bold().FontSize(18).FontColor(Colors.Black);
                                });
                            
                            });
                        });

                        column.Item().PaddingTop(20);


                        column.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingTop(15).Column(footerColumn =>
                        {
                            footerColumn.Item().Text("Ticket Number").FontSize(10).FontColor(Colors.Grey.Medium).AlignCenter();
                            footerColumn.Item().Text($"{ticket.TicketNumber}").Bold().FontSize(16).FontColor(Colors.Blue.Darken2).AlignCenter();
                        });

                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Column(eventDetails =>
                            {
                                eventDetails.Item().Text("Event details:").Bold();
                                eventDetails.Item().Text($"{currentType.Event.Name} - {currentType.Event.Venue.Name}").FontSize(12);
                                eventDetails.Item().Text(currentType.Event.StartDate.ToString("MMMM dd, yyyy")).FontSize(12);
                            });

                            
                            row.ConstantItem(120).Height(120).AlignRight().Image(qrBytes);
                        });
                    });
                });
            }).GeneratePdf();



        }
    }
}
