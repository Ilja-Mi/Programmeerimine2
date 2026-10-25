using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Administrators
{
    public class ListAdministratorsQueryHandler : IRequestHandler<ListAdministratorsQuery, OperationResult<PagedResult<AdministratorListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListAdministratorsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<AdministratorListItemDto>>> Handle(ListAdministratorsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<AdministratorListItemDto>>();
            result.Value = await _dbContext.Administrators
                .AsNoTracking()
                .OrderBy(item => item.Id)
                .Select(item => new AdministratorListItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Username = item.Username,
                    OperationCount = item.Operations.Count
                })
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return result;
        }
    }
}
