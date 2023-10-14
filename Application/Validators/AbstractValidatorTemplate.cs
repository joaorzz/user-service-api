using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators
{
    public abstract class AbstractValidatorTemplate<T> : AbstractValidator<T>, IValidator<T>
    {
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
        {
            ValidationResult validationResult = await base.ValidateAsync(context, cancellation);

            if (!validationResult.IsValid)
            {
                CreateException(context.InstanceToValidate);
            }

            return validationResult;
        }

        protected abstract void CreateException(T instance);
    }
}
