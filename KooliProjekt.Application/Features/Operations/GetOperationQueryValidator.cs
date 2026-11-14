using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationQueryValidator : AbstractValidator<GetOperationQuery>
    {
        public GetOperationQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
