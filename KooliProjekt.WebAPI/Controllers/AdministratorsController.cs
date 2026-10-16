using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Features.Administrators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class AdministratorsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AdministratorsController(IMediator mediator)
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

            var query = new GetAdministratorQuery { Id = id.Value };
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var query = new ListAdministratorsQuery();
            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }
    }
}
