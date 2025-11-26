using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Entities.Venues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Sections.Create
{
    public class CreateSectionCommand : IRequest<ResponseSectionDto>
    {
        
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int VenueID { get; set; }
        
    }
}
