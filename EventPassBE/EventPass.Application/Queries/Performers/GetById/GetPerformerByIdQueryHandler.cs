using EventPass.Application.DTOs.PerformerDTOs;
using EventPass.Domain.Interfaces.Performers;
using MediatR;

namespace EventPass.Application.Queries.Performers.GetById
{
    public class GetPerformerByIdQueryHandler : IRequestHandler<GetPerformerByIdQuery, PerformerDto>
    {
        private readonly IPerformerRepository _performerRepository;

        public GetPerformerByIdQueryHandler(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }

        public async Task<PerformerDto> Handle(GetPerformerByIdQuery request, CancellationToken cancellationToken)
        {
            var performer = await _performerRepository.GetPerformerByIdAsync(request.Id);

            if (performer == null)
                return null;

            return new PerformerDto
            {
                Id = performer.Id,
                Name = performer.Name,
                ImageURL = performer.ImageURL,
                Website = performer.Website,
                SocialMedia = performer.SocialMedia.Select(sm => new ResponseSocialMediaDto
                {
                    Id = sm.Id,
                    Link = sm.Link
                }).ToList()
            };
        }
    }
}