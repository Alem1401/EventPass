using EventPass.Application.Commands.EventCategories.Create;
using EventPass.Application.Commands.EventCategories.Delete;
using EventPass.Application.Commands.EventCategories.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventPass.Application.DTOs.EventDTOs;
using EventPass.Application.Queries.EventCategories.GetAll;
using EventPass.Application.Queries.EventCategories.GetById;
using EventPass.Application.Queries.EventCategories.GetByName;

namespace EventPass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventCategoryResponseDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllEventCategoriesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventCategoryResponseDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetEventCategoryByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<EventCategoryResponseDto>>> GetByName([FromQuery] string name, CancellationToken cancellationToken)
        {
            var query = new GetEventCategoriesByNameQuery { Name = name };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EventCategoryResponseDto>> Create([FromBody] CreateEventCategoryDto createDto, CancellationToken cancellationToken)
        {
            var command = new CreateEventCategoryCommand { EventCategoryDto = createDto };
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventCategoryResponseDto>> Update(int id, [FromBody] UpdateEventCategoryDto updateDto, CancellationToken cancellationToken)
        {
            var command = new UpdateEventCategoryCommand { Id = id, EventCategoryDto = updateDto };
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteEventCategoryCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}