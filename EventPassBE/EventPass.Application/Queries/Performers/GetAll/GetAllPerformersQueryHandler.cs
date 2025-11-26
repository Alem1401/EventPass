using EventPass.Application.DTOs.PerformerDTOs;
using EventPass.Domain.Interfaces.Performers;
using MediatR;

namespace EventPass.Application.Queries.Performers.GetAll
{
    public class GetAllPerformersQueryHandler : IRequestHandler<GetAllPerformersQuery, IEnumerable<PerformerDto>>
    {
        private readonly IPerformerRepository _performerRepository;

        public GetAllPerformersQueryHandler(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }

        public async Task<IEnumerable<PerformerDto>> Handle(GetAllPerformersQuery request, CancellationToken cancellationToken)
        {
            var performers = await _performerRepository.GetAllPerformersAsync();
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