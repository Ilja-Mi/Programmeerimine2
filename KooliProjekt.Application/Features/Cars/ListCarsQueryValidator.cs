using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Cars
{
    public class ListCarsQueryValidator : AbstractValidator<ListCarsQuery>
    {
        public ListCarsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
            RuleFor(x => x).Must(x => x.Page < 1 || x.PageSize < 1 || (long)(x.Page - 1) * x.PageSize <= int.MaxValue).WithMessage("Page offset is too large.");
        }
    }
}
