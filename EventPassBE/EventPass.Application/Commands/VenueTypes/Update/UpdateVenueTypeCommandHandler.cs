using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Entities.VenueTypes;
using EventPass.Domain.Interfaces;
using MediatR;
using System;
using EventPass.Domain.Interfaces.Venues;

namespace EventPass.Application.Commands.VenueTypes.Update
{
    public class UpdateVenueTypeCommandHandler : IRequestHandler<UpdateVenueTypeCommand, ResponseVenueTypeDto>
    {
        IVenueTypeRepository _repository;

        public UpdateVenueTypeCommandHandler(IVenueTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseVenueTypeDto> Handle(UpdateVenueTypeCommand request, CancellationToken cancellationToken)
        {
            
            var toUpdate = await _repository.GetVenueTypeByIdAsync(request.Id);

           
            if (toUpdate == null)
            {
                return null; 
            }

            
            toUpdate.Name = request.Name;

   
            await _repository.UpdateVenueTypeAsync(toUpdate, cancellationToken);


            ResponseVenueTypeDto response = new ResponseVenueTypeDto { Name = toUpdate.Name,Id = toUpdate.Id};
         
            return response;
        }
    }
}
