using EventPass.Application.Commands.Reviews.Create;
using EventPass.Application.Commands.Reviews.Update;
using EventPass.Application.Commands.Reviews.Delete;
using EventPass.Application.DTOs.ReviewDTOs;
using EventPass.Application.Queries.Reviews.GetAll;
using EventPass.Application.Queries.Reviews.GetById;
using EventPass.Application.Queries.Reviews.GetByPerformer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using EventPass.Application.Queries.Reviews.GetByUser;

namespace EventPass.API.Controllers.Reviews
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseReviewDto>>> GetAll()
        {
            var query = new GetAllReviewsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseReviewDto>> GetById(int id)
        {
            var query = new GetReviewByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("performer/{performerId}")]
        public async Task<ActionResult<IEnumerable<ResponseReviewDto>>> GetByPerformer(int performerId)
        {
            var query = new GetReviewsByPerformerQuery { PerformerId = performerId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<IEnumerable<ResponseReviewDto>>> GetByUser(CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            int.TryParse(userId, out var id);
            var result = await _mediator.Send(new GetReviewsByUserIdQuery { UserId = id }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseReviewDto>> Create([FromBody] CreateReviewDto createDto)
        {
            var command = new CreateReviewCommand { ReviewDto = createDto };
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseReviewDto>> Update(int id, [FromBody] UpdateReviewDto updateDto)
        {
            var command = new UpdateReviewCommand { Id = id, ReviewDto = updateDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteReviewCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

    }
}