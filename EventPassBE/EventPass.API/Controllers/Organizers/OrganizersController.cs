using EventPass.Application.Commands.Organizers.Create;
using EventPass.Application.Commands.Organizers.Delete;
using EventPass.Application.Commands.Organizers.Update;
using EventPass.Application.DTOs.OrganizerDTOs;
using EventPass.Application.Queries.Organizers.GetAll;
using EventPass.Application.Queries.Organizers.GetById;
using EventPass.Application.Queries.Organizers.GetByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganizersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizerResponseDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetOrganizersQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizerResponseDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrganizerByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<OrganizerResponseDto>>> GetByName([FromQuery] string name, CancellationToken cancellationToken)
        {
            var query = new GetOrganizersByNameQuery { Name = name };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OrganizerResponseDto>> Create([FromBody] CreateOrganizerDto createDto, CancellationToken cancellationToken)
        {
            var command = new CreateOrganizerCommand { OrganizerDto = createDto };
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrganizerResponseDto>> Update(int id, [FromBody] UpdateOrganizerDto updateDto, CancellationToken cancellationToken)
        {
            var command = new UpdateOrganizerCommand { Id = id, OrganizerDto = updateDto };
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteOrganizerCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}