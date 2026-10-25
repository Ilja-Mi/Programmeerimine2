using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationQueryHandler : IRequestHandler<GetOperationQuery, OperationResult<OperationDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOperationQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OperationDto>> Handle(GetOperationQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<OperationDto>();
            result.Value = await _dbContext.Operations
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new OperationDto
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
                    EmployeeName = item.Employee == null ? null : item.Employee.Name,
                    Manufacturer = item.Car.Manufacturer,
                    Model = item.Car.Model,
                    OperationTypeDescription = item.OperationType.Description
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
