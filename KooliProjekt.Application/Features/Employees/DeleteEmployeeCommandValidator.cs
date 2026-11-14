using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Employees
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
