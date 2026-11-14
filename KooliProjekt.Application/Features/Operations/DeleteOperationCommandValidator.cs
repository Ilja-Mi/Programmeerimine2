using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Operations
{
    public class DeleteOperationCommandValidator : AbstractValidator<DeleteOperationCommand>
    {
        public DeleteOperationCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
