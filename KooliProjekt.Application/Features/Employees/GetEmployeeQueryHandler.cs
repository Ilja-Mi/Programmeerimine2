using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Employees
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, OperationResult<EmployeeDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetEmployeeQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<EmployeeDto>();
            result.Value = await _dbContext.Employees
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new EmployeeDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Username = item.Username,
                    Operations = item.Operations.OrderByDescending(operation => operation.Date)
                        .ThenByDescending(operation => operation.Id)
                        .Select(operation => new OperationListItemDto
                        {
                            Id = operation.Id,
                            Date = operation.Date,
                            Status = operation.Status,
                            Cost = operation.Cost,
                            CarId = operation.CarId,
                            LicensePlate = operation.Car.LicensePlate,
                            OperationTypeId = operation.OperationTypeId,
                            OperationTypeName = operation.OperationType.Name,
                            EmployeeId = operation.EmployeeId,
                            EmployeeName = operation.Employee == null ? null : operation.Employee.Name
                        }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
