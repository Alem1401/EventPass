using EventPass.Application.Commands.SponsorEvents.Create;
using EventPass.Application.Commands.SponsorEvents.Delete;
using EventPass.Application.Commands.SponsorEvents.Update;
using EventPass.Application.Commands.Sponsors.Create;
using EventPass.Application.Commands.Sponsors.Delete;
using EventPass.Application.Commands.Sponsors.Update;
using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Application.Queries.SponsorEvents.GetAll;
using EventPass.Application.Queries.SponsorEvents.GetBySponsorId;
using EventPass.Application.Queries.Sponsors.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorEventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SponsorEventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseSponsorEventDto>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllSponsorEventsQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ResponseSponsorEventDto>>> GetBySponsorId(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetSponsorEventsBySponsorIdQuery { sponsorId = id }, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseSponsorDto>> Create([FromBody] CreateSponsorEventDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new CreateSponsorEventCommand { dto = dto }, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult<ResponseSponsorDto>> Update([FromBody] ResponseSponsorEventDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new UpdateSponsorEventCommand { dto = dto }, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteSponsorEventCommand { Id = id}, cancellationToken);
            if (result == false) return NotFound();
            return NoContent();
        }
    }
}