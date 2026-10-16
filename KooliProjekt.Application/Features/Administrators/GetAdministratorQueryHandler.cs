using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Administrators
{
    public class GetAdministratorQueryHandler : IRequestHandler<GetAdministratorQuery, Administrator>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAdministratorQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Administrator> Handle(GetAdministratorQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Administrators.AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
        }
    }
}
