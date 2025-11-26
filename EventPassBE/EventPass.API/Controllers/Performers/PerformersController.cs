using EventPass.Application.Commands.Performers;
using EventPass.Application.DTOs.PerformerDTOs;
using EventPass.Application.Queries.Performers.GetById;
using EventPass.Application.Queries.Performers.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PerformersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/performers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformerDto>>> GetAll()
        {
            var query = new GetAllPerformersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/performers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PerformerDto>> GetById(int id)
        {
            var query = new GetPerformerByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // POST: api/performers
        [HttpPost]
        public async Task<ActionResult<PerformerDto>> Create([FromBody] CreatePerformerDto createDto)
        {
            var command = new CreatePerformerCommand { PerformerDto = createDto };
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/performers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PerformerDto>> Update(int id, [FromBody] UpdatePerformerDto updateDto)
        {
            var command = new UpdatePerformerCommand
            {
                Id = id,
                PerformerDto = updateDto
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // DELETE: api/performers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePerformerCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}