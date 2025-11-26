using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Entities.VenueTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.VenueTypes.Update
{
    public class UpdateVenueTypeCommand : IRequest<ResponseVenueTypeDto>
    {

        public int Id { get; set; }
      public string Name { get; set; }
    }
}
