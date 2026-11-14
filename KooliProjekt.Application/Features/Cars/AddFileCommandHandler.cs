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
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, OperationResult<string>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileClient _files;
        public AddFileCommandHandler(ApplicationDbContext db, IFileClient files) { _db = db; _files = files; }
        public async Task<OperationResult<string>> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            if (!await _db.Cars.AnyAsync(x => x.Id == request.Id, cancellationToken)) return null;
            var result = new OperationResult<string>();
            var store = FileStore.ForCar(request.Id);
            var name = Guid.NewGuid().ToString("N") + Path.GetExtension(request.FileName).ToLowerInvariant();
            await _files.Save(name, store, request.InputStream);
            result.Value = name;
            return result;
        }
    }
}
