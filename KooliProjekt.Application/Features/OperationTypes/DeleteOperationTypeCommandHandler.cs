using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class DeleteOperationTypeCommandHandler : IRequestHandler<DeleteOperationTypeCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteOperationTypeCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (request.Id <= 0)
            {
                return result.AddPropertyError("Id", "Id must be greater than zero.");
            }

            var item = await _dbContext.OperationTypes
                .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
            if (item == null)
            {
                // Like the teacher's example, deleting a missing record is a successful no-op.
                return result;
            }

            if (await _dbContext.Operations.AnyAsync(operation => operation.OperationTypeId == request.Id, cancellationToken))
            {
                return result.AddPropertyError("Id", "This operation type is used by existing operations.");
            }

            _dbContext.OperationTypes.Remove(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
