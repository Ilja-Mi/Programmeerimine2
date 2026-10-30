using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using KooliProjekt.Application.Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Administrators
{
    public class SaveAdministratorCommandHandler : IRequestHandler<SaveAdministratorCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveAdministratorCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveAdministratorCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            if (request.Id < 0)
            {
                return result.AddPropertyError("Id", "Id cannot be negative.");
            }

            if (request.Id == 0 && string.IsNullOrWhiteSpace(request.Password))
            {
                return result.AddPropertyError("Password", "Password is required for a new employee.");
            }

            Administrator item;
            if (request.Id == 0)
            {
                item = new Administrator();
                _dbContext.Administrators.Add(item);
            }
            else
            {
                item = await _dbContext.Administrators
                    .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (item == null)
                {
                    return result.AddPropertyError("Id", "Administrator was not found.");
                }
            }

            item.Name = request.Name;
            item.Username = request.Username;
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                item.Password = PasswordHash.Create(request.Password);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
