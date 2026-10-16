using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class ListOperationTypesQueryHandler : IRequestHandler<ListOperationTypesQuery, IEnumerable<OperationType>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOperationTypesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OperationType>> Handle(ListOperationTypesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.OperationTypes.AsNoTracking()
                .OrderBy(item => item.Id).ToListAsync(cancellationToken);
        }
    }
}
