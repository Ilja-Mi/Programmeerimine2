using FluentValidation;
using KooliProjekt.Application.Infrastructure.Files;
namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteFileCommandValidator : AbstractValidator<DeleteFileCommand>
    {
        public DeleteFileCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.FileName).Must(FileRules.ImageName).WithMessage("Use a safe jpg, jpeg, png, gif or webp filename (max 150 characters).");
        }
    }
}
