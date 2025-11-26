using EventPass.Application.Commands.OrderItems.Create;
using EventPass.Application.Commands.OrderItems.Delete;
using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Application.Queries.OrderItems.GetAll;
using EventPass.Application.Queries.OrderItems.GetByOrderId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseOrderItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllOrderItemsQuery(), cancellationToken);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ResponseOrderDto>>> GetByOrderId(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderItemsByOrderIdQuery { orderId = id }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseOrderDto>> Create([FromBody] CreateOrderItemDto item, CancellationToken ct)
        {
            var result = await _mediator.Send(new CreateOrderItemCommand { dto = item }, ct);
            return Ok(result);  
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new DeleteOrderItemCommand { Id = id }, ct);
            return Ok(result);
        }
    }

}