using FluentValidation;
using MediatR;


namespace TodoApi.Application.Behavior;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = await Task
                .WhenAll(_validators
                    .Select(v => v.ValidateAsync(context, cancellationToken)))
                .ContinueWith(task => task.Result.SelectMany(result => result.Errors)
                    .Where(failure => failure != null).ToList(), cancellationToken);

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }
        return await next();
    }
}