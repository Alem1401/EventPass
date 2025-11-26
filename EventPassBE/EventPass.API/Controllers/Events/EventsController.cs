using EventPass.Application.Commands.Events.Create;
using EventPass.Application.Commands.Events.Delete;
using EventPass.Application.Commands.Events.Update;
using EventPass.Application.DTOs.EventDTOs;
using EventPass.Application.Queries.Events.GetAll;
using EventPass.Application.Queries.Events.GetById;
using EventPass.Application.Queries.Events.GetByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseEventDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetEventsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseEventDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetEventByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ResponseEventDto>>> GetByName([FromQuery] string name, CancellationToken cancellationToken)
        {
            var query = new GetEventsByNameQuery { Name = name };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseEventDto>> Create([FromBody] CreateEventDto createDto, CancellationToken cancellationToken)
        {
            var command = new CreateEventCommand { EventDto = createDto };
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseEventDto>> Update(int id, [FromBody] UpdateEventDto updateDto, CancellationToken cancellationToken)
        {
            var command = new UpdateEventCommand { Id = id, EventDto = updateDto };
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteEventCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}