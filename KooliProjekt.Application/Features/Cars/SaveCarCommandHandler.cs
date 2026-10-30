using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarCommandHandler : IRequestHandler<SaveCarCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCarCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveCarCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (request.Id < 0)
            {
                return result.AddPropertyError("Id", "Id cannot be negative.");
            }

            Car item;
            if (request.Id == 0)
            {
                item = new Car();
                _dbContext.Cars.Add(item);
            }
            else
            {
                item = await _dbContext.Cars
                    .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (item == null)
                {
                    return result.AddPropertyError("Id", "Car was not found.");
                }
            }

            item.Manufacturer = request.Manufacturer;
            item.Model = request.Model;
            item.LicensePlate = request.LicensePlate;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
