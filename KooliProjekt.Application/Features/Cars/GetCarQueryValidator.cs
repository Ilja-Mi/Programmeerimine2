using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Cars
{
    public class GetCarQueryValidator : AbstractValidator<GetCarQuery>
    {
        public GetCarQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
