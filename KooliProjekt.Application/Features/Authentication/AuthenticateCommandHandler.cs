using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Authentication;
using KooliProjekt.Application.Authentication.Jwt;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Authentication
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, OperationResult<string>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly JwtTokenBuilder _tokenBuilder;
        public AuthenticateCommandHandler(ApplicationDbContext dbContext, JwtTokenBuilder tokenBuilder)
        { _dbContext = dbContext; _tokenBuilder = tokenBuilder; }
        public async Task<OperationResult<string>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();
            var user = await _dbContext.Employees.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Username == request.UserName, cancellationToken);
            if (user == null || !PasswordHelper.Verify(request.Password, user.Password))
                return result.AddError("Invalid username or password.");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Name, user.Username)
            };
            if (user.IsAdmin) claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            result.Value = _tokenBuilder.GenerateToken(claims.ToArray());
            return result;
        }
    }
}
