using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class SaveOperationTypeCommandHandler : IRequestHandler<SaveOperationTypeCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOperationTypeCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (request.Id < 0)
            {
                return result.AddPropertyError("Id", "Id cannot be negative.");
            }

            OperationType item;
            if (request.Id == 0)
            {
                item = new OperationType();
                _dbContext.OperationTypes.Add(item);
            }
            else
            {
                item = await _dbContext.OperationTypes
                    .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (item == null)
                {
                    return result.AddPropertyError("Id", "OperationType was not found.");
                }
            }

            item.Name = request.Name;
            item.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
