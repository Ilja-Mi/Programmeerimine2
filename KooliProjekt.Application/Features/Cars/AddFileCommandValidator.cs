using FluentValidation;
using KooliProjekt.Application.Infrastructure.Files;
namespace KooliProjekt.Application.Features.Cars
{
    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        public AddFileCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.FileName).Must(FileRules.ImageName).WithMessage("Use a safe jpg, jpeg, png, gif or webp filename (max 150 characters).");
            RuleFor(x => x.InputStream).Must(FileRules.ValidStream).WithMessage("Provide a readable image from 1 byte to 10 MiB.");
        }
    }
}
