using EventPass.Application.Commands.Sponsors.Create;
using EventPass.Application.Commands.Sponsors.Delete;
using EventPass.Application.Commands.Sponsors.Update;
using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Application.Queries.Sponsors.GetById;
using EventPass.Application.Queries.Sponsors.GetByName;
using EventPass.Application.Queries.Sponsors.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SponsorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseSponsorDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllSponsorsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseSponsorDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetSponsorByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ResponseSponsorDto>>> GetByName([FromQuery] string name, CancellationToken cancellationToken)
        {
            var query = new GetSponsorsByNameQuery { Name = name };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseSponsorDto>> Create([FromBody] CreateSponsorDto createDto, CancellationToken cancellationToken)
        {
            var command = new CreateSponsorCommand { SponsorDto = createDto };
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseSponsorDto>> Update(int id, [FromBody] UpdateSponsorDto updateDto, CancellationToken cancellationToken)
        {
            var command = new UpdateSponsorCommand { Id = id, SponsorDto = updateDto };
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteSponsorCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}