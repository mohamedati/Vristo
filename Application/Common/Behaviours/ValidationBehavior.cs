
using Application.Common.Exceptions;
using FluentValidation;
using MediatR;


namespace Application.Common.Behaviours
{
   
        public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
        {
            private readonly IEnumerable<IValidator<TRequest>> _validators;

            public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
            {
                _validators = validators;
            }

        public async Task<TResponse> Handle(
              TRequest request,
              RequestHandlerDelegate<TResponse> next,
              CancellationToken cancellationToken
          )
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var ValidationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var failures = ValidationResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors).ToList();

                // If failures are found, modify the error key if necessary
                if (failures.Any())
                {
                    foreach (var failure in failures)
                    {
                        // Check if the failure PropertyName is empty (which happens when using anonymous objects)
                        if (string.IsNullOrWhiteSpace(failure.PropertyName))
                        {
                            // Set the error key to "otherErrors"
                            failure.PropertyName = "otherErrors";
                            continue;
                        }

                        failure.PropertyName = failure.PropertyName;
                    }

                    throw new Application.Common.Exceptions.ValidationException(failures);
                }
            }
            return await next();
        }
    }

    }

