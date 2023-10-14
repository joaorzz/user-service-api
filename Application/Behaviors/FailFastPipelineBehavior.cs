using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class FailFastPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await Task.WhenAll(_validators.Select(v => v.ValidateAsync(request, cancellationToken)));
            return await next();
        }
    }
}
