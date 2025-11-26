using EventPass.Domain.Interfaces.Venues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Sections.Delete
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, bool>
    {
        private readonly ISectionRepository _repostiry;

        public DeleteSectionCommandHandler(ISectionRepository repository)
        {
            _repostiry = repository;
        }
        public async Task<bool> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
           var find = await _repostiry.GetSectionByIdAsync(request.Id, cancellationToken);
            if (find == null)
            {
                return false;
            }
            var result = await _repostiry.DeleteSectionAsync(find, cancellationToken);
            return result;
          
        }
    }
}
