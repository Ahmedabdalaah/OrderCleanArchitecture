using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderCleanArchitecture.Core.Features.Orders.Command.Models;
using OrderCleanArchitecture.Core.Features.Orders.Queries.Models;

namespace OrderCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/Order/List")]
        public async Task<IActionResult> GetAllOrder()
        {
            var response = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(response);
        }
        [HttpGet("/Order/{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(response);
        }
        [HttpPost("/Order/Add")]
        public async Task<ActionResult> AddOrder([FromBody] AddOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("/Order/Update")]
        public async Task<IActionResult> EditOrder([FromBody] EditOrderCommands command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("/Order/Delete/{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteOrderCommand(id));
            return Ok(response);
        }
    }
}
