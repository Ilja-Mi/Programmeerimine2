using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Operations
{
    public class ListOperationsQueryHandler : IRequestHandler<ListOperationsQuery, OperationResult<PagedResult<OperationListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOperationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<OperationListItemDto>>> Handle(ListOperationsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<OperationListItemDto>>();
            result.Value = await _dbContext.Operations
                .AsNoTracking()
                .OrderBy(item => item.Id)
                .Select(item => new OperationListItemDto
                {
                    Id = item.Id,
                    Date = item.Date,
                    Status = item.Status,
                    Cost = item.Cost,
                    CarId = item.CarId,
                    LicensePlate = item.Car.LicensePlate,
                    OperationTypeId = item.OperationTypeId,
                    OperationTypeName = item.OperationType.Name,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.Employee == null ? null : item.Employee.Name
                })
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return result;
        }
    }
}
