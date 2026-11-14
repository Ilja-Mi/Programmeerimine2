using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarCommandValidator : AbstractValidator<SaveCarCommand>
    {
        public SaveCarCommandValidator(ApplicationDbContext db)
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Id).MustAsync((id, ct) => db.Cars.AnyAsync(x => x.Id == id, ct)).When(x => x.Id > 0).WithMessage("Record does not exist.");
            RuleFor(x => x.Manufacturer).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Model).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LicensePlate).NotEmpty().MaximumLength(20);
        }
    }
}
