using EventPass.Application.Commands.Orders.Create;
using EventPass.Application.Commands.Orders.Delete;
using EventPass.Application.Queries.Orders.GetById;
using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Application.Queries.Orders.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseOrderDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllOrdersQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOrderDto>> GetById(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery { Id = id }, ct);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseOrderDto>> Create([FromBody] CreateOrderDto newOrder, CancellationToken ct)
        {
            var response = await _mediator.Send(new CreateOrderCommand { dto = newOrder }, ct);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new DeleteOrderQuery { Id = id }, ct);
            if (!result) return NotFound();
            return NoContent();
        }
    }
    
}