using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Employees
{
    public class ListEmployeesQueryHandler : IRequestHandler<ListEmployeesQuery, OperationResult<PagedResult<EmployeeListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListEmployeesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<EmployeeListItemDto>>> Handle(ListEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<EmployeeListItemDto>>();
            result.Value = await _dbContext.Employees
                .AsNoTracking()
                .OrderBy(item => item.Id)
                .Select(item => new EmployeeListItemDto
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
