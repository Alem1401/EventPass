using EventPass.Application.Commands.CartItems.Create;
using EventPass.Application.Commands.CartItems.Delete;
using EventPass.Application.Commands.Carts.Delete;
using EventPass.Application.DTOs.CartDTOs;
using EventPass.Application.Queries.CartItems.GetAll;
using EventPass.Application.Queries.CartItems.GetByCartId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCartItemDto>>> GetAll(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllCartItemsQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ResponseCartItemDto>>> GetByCartId(int id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetCartItemsByCartIdQuery { cartId = id}, ct));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseCartItemDto>> Create([FromBody] CreateCartItemDto dto, CancellationToken ct)
        {
            var result = await _mediator.Send(new CreateCartItemCommand { dto = dto }, ct);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken ct)
        {
            var response = await _mediator.Send(new DeleteCartItemCommand { Id = id }, ct);
            if (response == false) return NotFound();
            return NoContent();
        }
    }
}