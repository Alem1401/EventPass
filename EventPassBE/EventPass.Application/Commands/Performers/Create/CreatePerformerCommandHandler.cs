using EventPass.Application.Commands.Performers;
using EventPass.Application.DTOs.PerformerDTOs;
using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Interfaces.Performers;
using MediatR;

namespace EventPass.Application.Handlers.Performers
{
    public class CreatePerformerCommandHandler : IRequestHandler<CreatePerformerCommand, PerformerDto>
    {
        private readonly IPerformerRepository _performerRepository;

        public CreatePerformerCommandHandler(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }

        public async Task<PerformerDto> Handle(CreatePerformerCommand request, CancellationToken cancellationToken)
        {
            var performer = new Performer
            {
                Name = request.PerformerDto.Name,
                ImageURL = request.PerformerDto.ImageURL,
                Website = request.PerformerDto.Website,
                SocialMedia = request.PerformerDto.SocialMedia.Select(sm => new PerformerSocialMedia
                {
                    Link = sm.Link
                }).ToList()
            };

            var createdPerformer = await _performerRepository.AddPerformerAsync(performer);

            return new PerformerDto
            {
                Id = createdPerformer.Id,
                Name = createdPerformer.Name,
                ImageURL = createdPerformer.ImageURL,
                Website = createdPerformer.Website,
                SocialMedia = createdPerformer.SocialMedia.Select(sm => new ResponseSocialMediaDto
                {
                    Id = sm.Id,
                    Link = sm.Link
                }).ToList()
            };
        }
    }
}