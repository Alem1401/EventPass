using EventPass.Application.Commands.Performers;
using EventPass.Application.DTOs.PerformerDTOs;
using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Interfaces.Performers;
using MediatR;

namespace EventPass.Application.Handlers.Performers
{
    public class UpdatePerformerCommandHandler : IRequestHandler<UpdatePerformerCommand, PerformerDto>
    {
        private readonly IPerformerRepository _performerRepository;

        public UpdatePerformerCommandHandler(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }

        public async Task<PerformerDto> Handle(UpdatePerformerCommand request, CancellationToken cancellationToken)
        {
            var existingPerformer = await _performerRepository.GetPerformerByIdAsync(request.Id);

            if (existingPerformer == null)
                return null;

            existingPerformer.Name = request.PerformerDto.Name;
            existingPerformer.ImageURL = request.PerformerDto.ImageURL;
            existingPerformer.Website = request.PerformerDto.Website;

           
            existingPerformer.SocialMedia = request.PerformerDto.SocialMedia.Select(sm => new PerformerSocialMedia
            {
                Link = sm.Link
            }).ToList();

            var updatedPerformer = await _performerRepository.UpdatePerformerAsync(existingPerformer);

            return new PerformerDto
            {
                Id = updatedPerformer.Id,
                Name = updatedPerformer.Name,
                ImageURL = updatedPerformer.ImageURL,
                Website = updatedPerformer.Website,
                SocialMedia = updatedPerformer.SocialMedia.Select(sm => new ResponseSocialMediaDto
                {
                    Id = sm.Id,
                    Link = sm.Link
                }).ToList()
            };
        }
    }
}