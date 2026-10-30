using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Operations
{
    public class SaveOperationCommandHandler : IRequestHandler<SaveOperationCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOperationCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveOperationCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (request.Id < 0)
            {
                return result.AddPropertyError("Id", "Id cannot be negative.");
            }

            if (request.Date == default)
            {
                return result.AddPropertyError("Date", "Date is required.");
            }
            if (!System.Enum.IsDefined(typeof(Status), request.Status))
            {
                return result.AddPropertyError("Status", "Unknown status.");
            }
            if (request.Cost.HasValue && request.Cost.Value < 0)
            {
                return result.AddPropertyError("Cost", "Cost cannot be negative.");
            }
            if (!await _dbContext.Cars.AnyAsync(item => item.Id == request.CarId, cancellationToken))
            {
                return result.AddPropertyError("CarId", "Car was not found.");
            }
            if (!await _dbContext.OperationTypes.AnyAsync(item => item.Id == request.OperationTypeId, cancellationToken))
            {
                return result.AddPropertyError("OperationTypeId", "Operation type was not found.");
            }
            if (request.EmployeeId.HasValue &&
                !await _dbContext.Employees.AnyAsync(item => item.Id == request.EmployeeId.Value, cancellationToken))
            {
                return result.AddPropertyError("EmployeeId", "Employee was not found.");
            }

            Operation item;
            if (request.Id == 0)
            {
                item = new Operation();
                _dbContext.Operations.Add(item);
            }
            else
            {
                item = await _dbContext.Operations
                    .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (item == null)
                {
                    return result.AddPropertyError("Id", "Operation was not found.");
                }
            }

            item.Date = request.Date;
            item.Status = request.Status;
            item.Cost = request.Cost;
            item.CarId = request.CarId;
            item.OperationTypeId = request.OperationTypeId;
            item.EmployeeId = request.EmployeeId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
