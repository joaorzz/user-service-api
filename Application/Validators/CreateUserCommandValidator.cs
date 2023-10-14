using Application.Commands;
using Domain.Exceptions;
using FluentValidation;

namespace Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidatorTemplate<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            base.RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(request => request).NotNull();
            RuleFor(request => request.Name).Length(6, 255).NotNull();
            RuleFor(request => request.Address).Length(10, 255).NotNull();
            RuleFor(request => request.CEP).Length(8, 10).NotNull().Must(BeNumeric);
            RuleFor(request => request.Phone).Length(10, 15).NotNull().Must(BeNumeric);
            RuleFor(request => request.City).MaximumLength(255).NotEmpty().NotNull();
            RuleFor(request => request.State).Length(2).NotEmpty().NotNull();
        }

        protected override void CreateException(CreateUserCommand instance)
        {
            throw new BadRequestException();
        }

        private bool BeNumeric(string input)
        {
            const string regex = "^[0-9]*$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, regex);
        }
    }
}
