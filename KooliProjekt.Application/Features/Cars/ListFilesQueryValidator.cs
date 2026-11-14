using FluentValidation;
using KooliProjekt.Application.Infrastructure.Files;
namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesQueryValidator : AbstractValidator<ListFilesQuery>
    {
        public ListFilesQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
