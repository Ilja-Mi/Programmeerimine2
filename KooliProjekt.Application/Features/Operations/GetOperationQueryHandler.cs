using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationQueryHandler : IRequestHandler<GetOperationQuery, Operation>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Operation> Handle(GetOperationQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Operations.AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
        }
    }
}
