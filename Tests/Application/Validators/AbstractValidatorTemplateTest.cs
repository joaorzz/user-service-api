using Application.Validators;
using FluentValidation;
using FluentValidation.Results;
using Xunit;

namespace Tests.Application.Validators
{
    public class AbstractValidatorTemplateTest
    {
        [Fact]
        public async Task ValidateAsync_WhenValidationSuccess()
        {
            // Arrange
            TestValidator validator = new TestValidator();
            const string value = "test";

            // Act
            ValidationResult validationResult = await validator.ValidateAsync(value, CancellationToken.None);

            // Assert
            Assert.True(validationResult.IsValid);
            Assert.Empty(validationResult.Errors);
        }

        [Fact]
        public async Task ValidateAsync_WhenValidationFails_CallsCreateException()
        {
            // Arrange
            TestValidator validator = new TestValidator();
            string value = string.Empty;

            // Act
            Task result = validator.ValidateAsync(value, CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => result);
        }

        private class TestValidator : AbstractValidatorTemplate<string>
        {
            public TestValidator()
            {
                RuleFor(value => value).NotEmpty();
            }

            protected override void CreateException(string instance)
            {
                throw new Exception("test failed");
            }
        }
    }
}
