using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.TicketDTOs
{
    public class UpdateTicketTypeDTO
    {
       
        public decimal Price { get; set; }
        public int TicketsRemaining { get; set; }
        public int SectionID { get; set; }
       
        public int EventID { get; set; }
    }
}
