using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Entities.Venues;
using EventPass.Domain.Interfaces.Venues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Sections.Create
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, ResponseSectionDto>
    {
        ISectionRepository _repository;

        public CreateSectionCommandHandler(ISectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseSectionDto> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var newSection = new Section
            {
                Capacity = request.Capacity,
                Name = request.Name,
                VenueID = (int)request.VenueID
            };

            var allSections = await _repository.GetSectionsByVenueAsync(request.VenueID,cancellationToken);
            if (allSections.Any(s => s.Name == newSection.Name))
            {
                return null;
            }

            var createdSection = await _repository.AddSectionAsync(newSection, cancellationToken);

            var responseDto = new ResponseSectionDto
            {
                Name = createdSection.Name,
                Capacity = createdSection.Capacity,
                Id = createdSection.Id
            };

            return responseDto;
        }

    }
}
