using EventPass.Application.DTOs.VenueDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Sections.Update
{
    public class UpdateSectionCommand : IRequest<ResponseSectionDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
