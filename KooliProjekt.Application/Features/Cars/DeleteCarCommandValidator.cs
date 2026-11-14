using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
    {
        public DeleteCarCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
