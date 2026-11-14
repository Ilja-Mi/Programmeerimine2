using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypeQueryValidator : AbstractValidator<GetOperationTypeQuery>
    {
        public GetOperationTypeQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
