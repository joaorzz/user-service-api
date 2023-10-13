using Application.Commands;
using Application.Validators;
using FluentValidation;
using Xunit;

namespace Tests.Application.Validators
{
    public class CreateUserCommandValidatorTest
    {
        [Fact]
        public void Validate_ValidRequest_ShouldNotThrowException()
        {
            // Arrange
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            CreateUserCommand createUserCommand = new CreateUserCommand("ValidName", "ValidAddress", "1234567890", "validmail@mailtest.com", "1234567890", "1547896541", "ValidCity", "ST");

            // Act
            Action validationAction = () => validator.ValidateAndThrow(createUserCommand);

            // Assert
            Assert.Null(Record.Exception(validationAction));
        }

        [Fact]
        public void Validate_RequestWithEmptyName_ShouldThrowException()
        {
            // Arrange
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            CreateUserCommand createUserCommand = new CreateUserCommand("", "ValidAddress", "1234567890", "validmail@mailtest.com", "1234567890", "1547896545", "ValidCity", "ST");

            // Act
            Action validationAction = () => validator.ValidateAndThrow(createUserCommand);

            // Assert
            Assert.Throws<ValidationException>(validationAction);
        }
    }
}
