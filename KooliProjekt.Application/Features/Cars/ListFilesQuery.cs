using System.IO;
using MediatR;
using KooliProjekt.Application.Infrastructure.Results;
namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesQuery : IRequest<OperationResult<string[]>>
    {
        public int Id { get; set; }
    }
}
