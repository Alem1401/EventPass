using EventPass.Application.Commands.Sections.Create;
using EventPass.Application.Commands.Sections.Delete;
using EventPass.Application.Commands.Sections.Update;
using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Application.Queries.Sections.GetAll;
using EventPass.Application.Queries.Sections.GetSectionsByVenue;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EventPass.API.Controllers.Section
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {

        private readonly IMediator _mediatr;

        public SectionController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseSectionDto>>> Get(CancellationToken ct)
        {
            var result = await _mediatr.Send(new GetAllSectionsQuery(), ct);
            return Ok(result);
        }

        [HttpGet("venue/{venueId}")]

        public async Task<ActionResult<IEnumerable<ResponseSectionDto>>> getSectionsByVenue(int venueId,CancellationToken ct)
        {

            var result = await _mediatr.Send(new GetSectionsByVenueQuery { VenueId=venueId}, ct);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody]CreateSectionCommand section, CancellationToken ct)
        {
            var result = await _mediatr.Send(section, ct);
            if (result == null)
            {
                return BadRequest("Could not create section");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ResponseSectionDto>> put(UpdateSectionDto dto, int id, CancellationToken ct)
        {
            var response = await _mediatr.Send(new UpdateSectionCommand
            {
                Id = id,
                Name = dto.Name,
                Capacity = dto.Capacity
            }, ct);
            if (response == null)
            {
                return BadRequest();
            }
            else return Ok(response);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> delete(int id, CancellationToken ct)
        {
            var response = await _mediatr.Send(new DeleteSectionCommand
            {
                Id = id
            }, ct);
            if (response == false)
            {
                return NotFound();
            }
            else return NoContent();

        }
    }
}