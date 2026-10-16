using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Operations
{
    public class ListOperationsQueryHandler : IRequestHandler<ListOperationsQuery, IEnumerable<Operation>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOperationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Operation>> Handle(ListOperationsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Operations.AsNoTracking()
                .OrderBy(item => item.Id).ToListAsync(cancellationToken);
        }
    }
}
