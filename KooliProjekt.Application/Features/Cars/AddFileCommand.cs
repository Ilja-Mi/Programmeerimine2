using System.IO;
using MediatR;
using KooliProjekt.Application.Infrastructure.Results;
namespace KooliProjekt.Application.Features.Cars
{
    public class AddFileCommand : IRequest<OperationResult<string>>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Stream InputStream { get; set; }
    }
}
