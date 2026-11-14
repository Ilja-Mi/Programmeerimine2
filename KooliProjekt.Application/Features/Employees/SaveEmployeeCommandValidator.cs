using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Employees
{
    public class SaveEmployeeCommandValidator : AbstractValidator<SaveEmployeeCommand>
    {
        public SaveEmployeeCommandValidator(ApplicationDbContext db)
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Id).MustAsync((id, ct) => db.Employees.AnyAsync(x => x.Id == id, ct)).When(x => x.Id > 0).WithMessage("Record does not exist.");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Username).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().When(x => x.Id == 0);
            RuleFor(x => x.Password).MaximumLength(255);
            RuleFor(x => x.Password).NotEmpty().When(x => x.Password != null && x.Password.Length > 0);
            RuleFor(x => x.Username).MustAsync((command, value, ct) => db.Employees.AllAsync(e => e.Id == command.Id || e.Username != value, ct)).WithMessage("Username is already used.");
        }
    }
}
