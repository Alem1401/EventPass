using EventPass.Application.Commands.VenueTypes.Create;
using EventPass.Application.Commands.VenueTypes.Delete;
using EventPass.Application.Commands.VenueTypes.Update;
using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Application.VenueTypes.Queries;
using EventPass.Domain.Entities.VenueTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VenueTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenueTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<VenueType>> Get(CancellationToken ct) 
        {
            return await _mediator.Send(new GetVenueTypesQuery(), ct); 
        }

        [HttpPost]
        public async Task<VenueType> Post(
     [FromBody] CreateVenueTypeCommand command,
     CancellationToken ct) 
        {
            return await _mediator.Send(command, ct); 
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ResponseVenueTypeDto>> Put([FromBody] UpdateVenueTypeDto dto, int id,CancellationToken ct)
        {
            UpdateVenueTypeCommand command = new UpdateVenueTypeCommand { Name = dto.Name, Id = id };
           var response =  await _mediator.Send(command,ct);
            if (response == null)
            {
                return NotFound();
            }
            else return Ok(response);
        }

        [HttpDelete("{id}")]    

        public async Task<ActionResult> Delete(int id, CancellationToken ct)
        {
            var command = new DeleteVenueTypeCommand { Id = id };
            var result = await _mediator.Send(command, ct);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
