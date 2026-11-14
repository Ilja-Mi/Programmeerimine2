using System.IO;
using Microsoft.AspNetCore.Http;
using KooliProjekt.Application.Infrastructure.Files;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Features.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class CarsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
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

            var query = new GetCarQuery { Id = id.Value };
            var result = await _mediator.Send(query, cancellationToken);
            return Result(result);
        }

        [HttpGet("list/{page:int?}/{pageSize:int?}")]
        public async Task<IActionResult> List(
            [FromRoute] int page = 1,
            [FromRoute] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new ListCarsQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query, cancellationToken);
            return Result(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SaveCarCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Result(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Result(result);
        }
        [HttpPost("{id:int}/files")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(11 * 1024 * 1024)]
        public async Task<IActionResult> AddFile(int id, [FromForm] CarFileUpload upload, CancellationToken cancellationToken)
        {
            var file = upload?.File;
            if (file == null || file.Length == 0 || file.Length > FileRules.MaxBytes)
                return BadRequest("Provide an image from 1 byte to 10 MiB.");
            using var stream = new MemoryStream();
            using (var input = file.OpenReadStream()) await input.CopyToAsync(stream, cancellationToken);
            stream.Position = 0;
            return Result(await _mediator.Send(new AddFileCommand
            { Id = id, FileName = file.FileName, InputStream = stream }, cancellationToken));
        }

        [HttpGet("{id:int}/files")]
        public async Task<IActionResult> ListFiles(int id, CancellationToken cancellationToken)
            => Result(await _mediator.Send(new ListFilesQuery { Id = id }, cancellationToken));

        [HttpGet("{id:int}/files/{fileName}")]
        public async Task<IActionResult> GetFile(int id, string fileName, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetFileCommand { Id = id, FileName = fileName }, cancellationToken);
            if (result == null || result.HasErrors || result.Value == null) return Result(result);
            return File(result.Value, FileRules.ContentType(fileName), fileName);
        }

        [HttpDelete("{id:int}/files/{fileName}")]
        public async Task<IActionResult> DeleteFile(int id, string fileName, CancellationToken cancellationToken)
            => Result(await _mediator.Send(new DeleteFileCommand { Id = id, FileName = fileName }, cancellationToken));
    }
}
