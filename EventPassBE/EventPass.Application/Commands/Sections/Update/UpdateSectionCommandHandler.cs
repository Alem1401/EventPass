using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Interfaces.Venues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Sections.Update
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, ResponseSectionDto>
    {
        ISectionRepository _repository;

        public UpdateSectionCommandHandler(ISectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseSectionDto> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _repository.GetSectionByIdAsync(request.Id, cancellationToken);
            if(section == null)
            {
                return null;
            }
            section.Name = request.Name;
            section.Capacity = request.Capacity;
            var updatedSection = await _repository.UpdateSectionAsync(section, cancellationToken);
            return new ResponseSectionDto
            {
                
                Name = updatedSection.Name,
                Capacity = updatedSection.Capacity,
                Id = updatedSection.Id
            };

        }
    }
}
