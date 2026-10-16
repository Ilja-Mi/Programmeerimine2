using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypeQueryHandler : IRequestHandler<GetOperationTypeQuery, OperationType>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationTypeQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationType> Handle(GetOperationTypeQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.OperationTypes.AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
        }
    }
}
