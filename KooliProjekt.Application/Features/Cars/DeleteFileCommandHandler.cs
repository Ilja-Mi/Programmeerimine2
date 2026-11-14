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
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, OperationResult>
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileClient _files;
        public DeleteFileCommandHandler(ApplicationDbContext db, IFileClient files) { _db = db; _files = files; }
        public async Task<OperationResult> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            if (!await _db.Cars.AnyAsync(x => x.Id == request.Id, cancellationToken)) return null;
            var result = new OperationResult();
            var store = FileStore.ForCar(request.Id);
            if (!await _files.Delete(request.FileName, store)) return null;
            return result;
        }
    }
}
