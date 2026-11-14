using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Operations
{
    public class SaveOperationCommandValidator : AbstractValidator<SaveOperationCommand>
    {
        public SaveOperationCommandValidator(ApplicationDbContext db)
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Id).MustAsync((id, ct) => db.Operations.AnyAsync(x => x.Id == id, ct)).When(x => x.Id > 0).WithMessage("Record does not exist.");
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.Cost).GreaterThanOrEqualTo(0m);
            RuleFor(x => x.CarId).Cascade(CascadeMode.Stop).GreaterThan(0).MustAsync((id, ct) => db.Cars.AnyAsync(e => e.Id == id, ct)).WithMessage("Related record does not exist.");
            RuleFor(x => x.OperationTypeId).Cascade(CascadeMode.Stop).GreaterThan(0).MustAsync((id, ct) => db.OperationTypes.AnyAsync(e => e.Id == id, ct)).WithMessage("Related record does not exist.");
            RuleFor(x => x.EmployeeId).Cascade(CascadeMode.Stop).GreaterThan(0).MustAsync((id, ct) => db.Employees.AnyAsync(e => e.Id == id, ct)).WithMessage("Related record does not exist.").When(x => x.EmployeeId.HasValue);
        }
    }
}
