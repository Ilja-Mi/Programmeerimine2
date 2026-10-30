using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Features.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class EmployeesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id:int?}")]
        public async Task<IActionResult> Get([FromRoute] int? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return NotFound();
            }

            var query = new GetEmployeeQuery { Id = id.Value };
            var result = await _mediator.Send(query, cancellationToken);
            return Result(result);
        }

        [HttpGet("list/{page:int?}/{pageSize:int?}")]
        public async Task<IActionResult> List(
            [FromRoute] int page = 1,
            [FromRoute] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new ListEmployeesQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query, cancellationToken);
            return Result(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SaveEmployeeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Result(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Result(result);
        }
    }
}
