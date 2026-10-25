using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, OperationResult<CarDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CarDto>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<CarDto>();
            result.Value = await _dbContext.Cars
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new CarDto
                {
                    Id = item.Id,
                    Manufacturer = item.Manufacturer,
                    Model = item.Model,
                    LicensePlate = item.LicensePlate,
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
