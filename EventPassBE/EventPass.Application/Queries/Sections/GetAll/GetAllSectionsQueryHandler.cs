using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Interfaces.Venues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Sections.GetAll
{
    public class GetAllSectionsQueryHandler : IRequestHandler<GetAllSectionsQuery, IEnumerable<ResponseSectionDto>>
    {
        private readonly ISectionRepository _repository;

        public GetAllSectionsQueryHandler(ISectionRepository repository)
        {
            _repository = repository;
        }   

        public async Task<IEnumerable<ResponseSectionDto>> Handle(GetAllSectionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllSectionsAsync(cancellationToken);
            return result.Select(section => new ResponseSectionDto
            {
                Name = section.Name,
                Capacity = section.Capacity,
                Id = section.Id
            });
        }
    }
}
