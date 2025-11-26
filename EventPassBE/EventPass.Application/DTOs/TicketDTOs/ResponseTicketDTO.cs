using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.TicketDTOs
{
    public class ResponseTicketDTO
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int ticketNumber { get; set; }
        public int ticketTypeId { get; set; }
    }
}
