using System.IO;
using MediatR;
using KooliProjekt.Application.Infrastructure.Results;
namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteFileCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}
