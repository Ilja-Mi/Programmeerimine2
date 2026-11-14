using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
namespace KooliProjekt.Application.Features.Cars
{
    public class GetFileCommandHandler : IRequestHandler<GetFileCommand, OperationResult<byte[]>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileClient _files;
        public GetFileCommandHandler(ApplicationDbContext db, IFileClient files) { _db = db; _files = files; }
        public async Task<OperationResult<byte[]>> Handle(GetFileCommand request, CancellationToken cancellationToken)
        {
            if (!await _db.Cars.AnyAsync(x => x.Id == request.Id, cancellationToken)) return null;
            var result = new OperationResult<byte[]>();
            var store = FileStore.ForCar(request.Id);
            result.Value = await _files.Get(request.FileName, store);
            return result;
        }
    }
}
