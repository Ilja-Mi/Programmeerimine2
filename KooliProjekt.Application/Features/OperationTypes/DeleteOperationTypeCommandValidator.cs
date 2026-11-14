using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.OperationTypes
{
    public class DeleteOperationTypeCommandValidator : AbstractValidator<DeleteOperationTypeCommand>
    {
        public DeleteOperationTypeCommandValidator(ApplicationDbContext db)
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Id).MustAsync((id, ct) => db.Operations.AllAsync(o => o.OperationTypeId != id, ct)).WithMessage("This operation type is used by an operation.");
        }
    }
}
