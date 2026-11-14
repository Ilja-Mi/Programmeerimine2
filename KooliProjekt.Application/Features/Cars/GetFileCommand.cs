using System.IO;
using MediatR;
using KooliProjekt.Application.Infrastructure.Results;
namespace KooliProjekt.Application.Features.Cars
{
    public class GetFileCommand : IRequest<OperationResult<byte[]>>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}
