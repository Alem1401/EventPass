using EventPass.Application.Commands.Payments.Create;
using EventPass.Application.Commands.Payments.Delete;
using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Application.Queries.Payments.GetAll;
using EventPass.Application.Queries.Payments.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventPass.API.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsePaymentDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllPaymentsQuery(), cancellationToken);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<IEnumerable<ResponsePaymentDto>>> GetByUserId(CancellationToken cancellationToken)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier)
                  ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (!int.TryParse(userIdClaim, out var id)) return NotFound(new {Message = "Ne valja"});
            else return Ok(await _mediator.Send(new GetPaymentsByUserIdQuery { userId = id }, cancellationToken));
        }


        [HttpPost]
        public async Task<ActionResult<ResponseOrderDto>> Create([FromBody] CreatePaymentDto newPayment, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreatePaymentCommand { dto = newPayment }, ct);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id, CancellationToken cancellation)
        {
            return await _mediator.Send(new DeletePaymentCommand { Id = id }, cancellation); 
        }
    }

}