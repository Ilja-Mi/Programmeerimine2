using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.OperationTypes
{
    public class SaveOperationTypeCommandValidator : AbstractValidator<SaveOperationTypeCommand>
    {
        public SaveOperationTypeCommandValidator(ApplicationDbContext db)
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Id).MustAsync((id, ct) => db.OperationTypes.AnyAsync(x => x.Id == id, ct)).When(x => x.Id > 0).WithMessage("Record does not exist.");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
