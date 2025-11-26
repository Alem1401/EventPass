using EventPass.Application.DTOs;
using EventPass.Application.DTOs.PerformerDTOs;
using EventPass.Domain.Interfaces.Performers;
using MediatR;

namespace EventPass.Application.Queries.Performers.GetByName
{
    public class GetPerformersByNameQueryHandler : IRequestHandler<GetPerformersByNameQuery, IEnumerable<PerformerDto>>
    {
        private readonly IPerformerRepository _performerRepository;

        public GetPerformersByNameQueryHandler(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }

        public async Task<IEnumerable<PerformerDto>> Handle(GetPerformersByNameQuery request, CancellationToken cancellationToken)
        {
            var performers = await _performerRepository.GetPerformerByNameAsync(request.Name, cancellationToken);
            return performers.Select(p => new PerformerDto
            {
                Id = p.Id,
                Name = p.Name,
                ImageURL = p.ImageURL,
                Website = p.Website,
                SocialMedia = p.SocialMedia.Select(sm => new ResponseSocialMediaDto
                {
                    Id = sm.Id,
                    Link = sm.Link
                }).ToList()
            });
        }
    }
}