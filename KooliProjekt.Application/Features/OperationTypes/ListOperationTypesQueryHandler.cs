using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class ListOperationTypesQueryHandler : IRequestHandler<ListOperationTypesQuery, OperationResult<PagedResult<OperationTypeListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOperationTypesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<OperationTypeListItemDto>>> Handle(ListOperationTypesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<OperationTypeListItemDto>>();
            result.Value = await _dbContext.OperationTypes
                .AsNoTracking()
                .OrderBy(item => item.Id)
                .Select(item => new OperationTypeListItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    OperationCount = item.Operations.Count
                })
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return result;
        }
    }
}
