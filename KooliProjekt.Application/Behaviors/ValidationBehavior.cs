using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> where TResponse : OperationResult, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, 
                                            RequestHandlerDelegate<TResponse> next,
                                            CancellationToken cancellationToken)
        {
            var response = new TResponse();
            var context = new ValidationContext<TRequest>(request);
            
            // Validators may share the scoped DbContext: execute them sequentially.
            var validationFailures = new List<FluentValidation.Results.ValidationResult>();
            foreach (var validator in _validators)
                validationFailures.Add(await validator.ValidateAsync(context, cancellationToken));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .ToList();

            if (errors.Any())
            {
                foreach(var error in errors)
                {
                    response.AddPropertyError(error.PropertyName, error.ErrorMessage);
                }

                return response;
            }

            return await next();
        }
    }
}
