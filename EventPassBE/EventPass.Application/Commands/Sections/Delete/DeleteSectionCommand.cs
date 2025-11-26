using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Sections.Delete
{
    public class DeleteSectionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
