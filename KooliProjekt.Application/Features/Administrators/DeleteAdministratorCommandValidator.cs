using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Administrators
{
    public class DeleteAdministratorCommandValidator : AbstractValidator<DeleteAdministratorCommand>
    {
        public DeleteAdministratorCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
