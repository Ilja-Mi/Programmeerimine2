using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypeQueryHandler : IRequestHandler<GetOperationTypeQuery, OperationResult<OperationTypeDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationTypeQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OperationTypeDto>> Handle(GetOperationTypeQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<OperationTypeDto>();
            result.Value = await _dbContext.OperationTypes
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new OperationTypeDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
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
