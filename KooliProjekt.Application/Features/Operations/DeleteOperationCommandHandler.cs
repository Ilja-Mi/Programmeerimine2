using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Operations
{
    public class DeleteOperationCommandHandler : IRequestHandler<DeleteOperationCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteOperationCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (request.Id <= 0)
            {
                return result.AddPropertyError("Id", "Id must be greater than zero.");
            }

            var item = await _dbContext.Operations
                .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
            if (item == null)
            {
                // Like the teacher's example, deleting a missing record is a successful no-op.
                return result;
            }

            _dbContext.Operations.Remove(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
