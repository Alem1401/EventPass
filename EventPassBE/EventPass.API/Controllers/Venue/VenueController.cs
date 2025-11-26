using EventPass.Application.Commands.Venues.Create;
using EventPass.Application.Commands.Venues.Delete;
using EventPass.Application.Commands.Venues.Update;
using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Application.Queries.Venues.GetAll;
using EventPass.Application.Queries.Venues.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers.Venue
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        IMediator _mediatr;

        public VenueController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]

        public async Task<ActionResult<int>> post([FromBody] CreateVenueCommand createVenue, CancellationToken ct)
        {
            var response = await _mediatr.Send(createVenue, ct);
            return Ok(response);
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<ResponseVenueDto>>> getAll(CancellationToken ct)
        {

            return await _mediatr.Send(new GetAllVenuesQuery(),ct);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<ResponseVenueDto>> getById(int id, CancellationToken ct)
        {
            var response = await _mediatr.Send(new GetVenueByIdQuery { Id = id }, ct);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult<ResponseVenueDto>> put(int id , [FromBody] UpdateVenueDto uVenueDto,CancellationToken ct)
        {
           var response = await _mediatr.Send(new UpdateVenueCommand{ updateVenueDto = uVenueDto, Id = id },ct);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id, CancellationToken ct)
        {
          var response = await _mediatr.Send(new DeleteVenueCommand { Id = id }, ct);
            if (!response)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }


    }
}
