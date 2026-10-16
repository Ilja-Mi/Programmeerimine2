using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Administrators
{
    public class ListAdministratorsQueryHandler : IRequestHandler<ListAdministratorsQuery, IEnumerable<Administrator>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListAdministratorsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Administrator>> Handle(ListAdministratorsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Administrators.AsNoTracking()
                .OrderBy(item => item.Id).ToListAsync(cancellationToken);
        }
    }
}
