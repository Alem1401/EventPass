using EventPass.Application.Commands.Carts.Create;
using EventPass.Application.Commands.Carts.Delete;
using EventPass.Application.DTOs.CartDTOs;
using EventPass.Application.Queries.Carts.GetAll;
using EventPass.Application.Queries.Carts.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventPass.API.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseCartDto>> GetAll(CancellationToken ct)
        {
            return await _mediator.Send(new GetAllCartsQuery(), ct);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<ResponseCartDto>> GetByUserId(CancellationToken ct)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier)
                  ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            int.TryParse(userIdClaim, out var id);
            var response = await _mediator.Send(new GetCartByUserIdQuery { userId = id }, ct);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseCartDto>> Create([FromBody] CreateCartDto userId, CancellationToken ct)
        {
            var result = await _mediator.Send(new CreateCartCommand { dto = userId}, ct);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteCartCommand { Id = id }, ct);
            if (response == false) return NotFound();
            return NoContent();
        }
    }
}