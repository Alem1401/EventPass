using EventPass.Application.Commands.Tickets.Create;
using EventPass.Application.Commands.Tickets.Delete;
using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Application.Queries.Tickets.GetAll;
using EventPass.Application.Queries.Tickets.GetByEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers.Tickets
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        IMediator _mediatr;
        public TicketsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]

        public async Task<ActionResult<ResponseTicketDTO>> put(CreateTicketCommand ticket,CancellationToken ct)
        {
            var result = await _mediatr.Send(ticket,ct);
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> delete(int id,CancellationToken ct)
        {
          
            var result = await _mediatr.Send(new DeleteTicketCommand {TicketId = id },ct);
            if (result == false)
            {
                return NotFound();
            }
            else return NoContent();
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ResponseTicketDTO>>> get(CancellationToken ct) {
        var result = await _mediatr.Send(new GetAllTicketsQuery(), ct);
        return Ok(result);
        }


        [HttpGet("{eventId}")]

        public async Task<ActionResult<IEnumerable<ResponseTicketDTO>>> getByEvent(int eventId,CancellationToken ct)
        {

            var result =await _mediatr.Send(new GetTicketsByEventQuery { EventId = eventId }, ct);
            return Ok(result);



        }


    }
}
