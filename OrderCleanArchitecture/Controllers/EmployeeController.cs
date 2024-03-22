using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderCleanArchitecture.Core.Features.Employes.Commands.Models;
using OrderCleanArchitecture.Core.Features.Employes.Queries.Models;

namespace OrderCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Field
        private readonly IMediator _mediator;
        #endregion
        #region Constructor
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region Handle Functions
        [HttpGet("/Employee/List")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(result);
        }
        [HttpGet("/Employee/{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIDQuery(id));
            return Ok(result);
        }
        [HttpPost("/Employee/Add")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommand addcommand)
        {
            var response = await _mediator.Send(addcommand);
            return Ok(response);
        }
        [HttpPut("/Employee/Update")]
        public async Task<IActionResult> EditEmployee([FromBody] EditEmployeeCommand editcommand)
        {
            var response = await _mediator.Send(editcommand);
            return Ok(response);
        }
        [HttpDelete("/Employee/Delete/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
        #endregion
    }
}