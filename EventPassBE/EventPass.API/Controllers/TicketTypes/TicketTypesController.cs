using EventPass.Application.Commands.TicketTypes.Create;
using EventPass.Application.Commands.TicketTypes.Delete;
using EventPass.Application.Commands.TicketTypes.Update;
using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Application.Queries.TicketTypes.GetAll;
using EventPass.Application.Queries.TicketTypes.GetTicketTypesInOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers.TicketTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypesController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TicketTypesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]

        public async Task<ActionResult<ResponseTicketTypeDTO>> post(CreateTicketTypeCommand ticketType, CancellationToken ct)
        {
            var result = await _mediatr.Send(ticketType, ct);
            if (result == null)
            {
                return BadRequest("Could not create ticket type");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ResponseTicketTypeDTO>>> Get(CancellationToken ct)
        {
            var result = await _mediatr.Send(new GetAllTicketTypesQuery(), ct);
            return Ok(result);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult<ResponseTicketTypeDTO>> Put(int id, [FromBody] UpdateTicketTypeDTO updateTicketTypeDto, CancellationToken ct)
        {
            var command = new UpdateTicketTypeCommand
            {
                Id = id,
                updateTicket = updateTicketTypeDto
            };

            var result = await _mediatr.Send(command, ct);
            if (result == null)
            {
                return NotFound($"Ticket type with ID {id} not found.");
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id, CancellationToken ct)
        {
            try
            {
                var result = await _mediatr.Send(new DeleteTicketTypeCommand { Id = id }, ct);
                return result ? NoContent() : NotFound();
            }
            catch (InvalidOperationException)
            {
                return NotFound($"Ticket type with ID {id} not found.");
            }
        }

        [HttpGet("ByEvent/{id}")]

        public async Task<ActionResult<IEnumerable<ResponseTicketTypeDTO>>> GetByEvent(int id, CancellationToken ct)
        {
            var result = await _mediatr.Send(new Application.Queries.TicketTypes.GetTicketTypeByEventQuery.GetTicketTypesByEventQuery { Id = id }, ct);
            return Ok(result);
        }

        [HttpGet("ByEvent/{id}/order")]

        public async Task<ActionResult<IEnumerable<ResponseTicketTypeDTO>>> GetByEventOrdered(int id, [FromQuery] string orderBy, CancellationToken ct)
        {
       

            var result = await _mediatr.Send(new GetTicketTypesInOrderQuery { EventId = id, OrderBy = orderBy}, ct);
            return Ok(result);
        }

    }
}
