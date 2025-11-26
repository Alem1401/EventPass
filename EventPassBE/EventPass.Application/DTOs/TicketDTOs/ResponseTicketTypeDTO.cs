using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.TicketDTOs
{
    public class ResponseTicketTypeDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int TicketsRemaining { get; set; }
        public string SectionName { get; set; }
       
         public string EventName { get; set; }
    }
}
