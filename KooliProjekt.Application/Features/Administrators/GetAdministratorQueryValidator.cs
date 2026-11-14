using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Administrators
{
    public class GetAdministratorQueryValidator : AbstractValidator<GetAdministratorQuery>
    {
        public GetAdministratorQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
