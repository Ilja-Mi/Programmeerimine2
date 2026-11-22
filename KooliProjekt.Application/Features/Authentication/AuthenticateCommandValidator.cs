using FluentValidation;
namespace KooliProjekt.Application.Features.Authentication
{
    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(255);
        }
    }
}
