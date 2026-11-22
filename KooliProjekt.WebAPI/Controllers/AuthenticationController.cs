using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace KooliProjekt.WebAPI.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator) { _mediator = mediator; }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand command, CancellationToken cancellationToken)
            => Result(await _mediator.Send(command, cancellationToken));
    }
}
