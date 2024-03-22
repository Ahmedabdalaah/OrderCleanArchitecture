using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderCleanArchitecture.Core.Features.Category.Commands.Models;
using OrderCleanArchitecture.Core.Features.Category.Queries.Models;

namespace OrderCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/Category/List")]
        public async Task<ActionResult> GetAllCategory()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }
        [HttpGet("/Category/{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIDQuery(id));
            return Ok(result);
        }
        [HttpPost("/Category/Add")]
        public async Task<ActionResult> AddCategory([FromBody] AddCategoryCommands commands)
        {
            var response = await _mediator.Send(commands);
            return Ok(response);
        }
    }
}
