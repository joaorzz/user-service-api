using Application.Behaviors;
using FluentValidation;
using Moq;
using Tests.Application.Behaviors.Mock;
using Xunit;

namespace Tests.Application.Behaviors
{
    public class FailFastPipelineBehaviorTest
    {
        [Fact]
        public async Task Handle_WhenValidationPasses_ShouldCallNext()
        {
            // Arrange
            List<IValidator<MyRequestMock>> validators = new List<IValidator<MyRequestMock>>
            {
                new Mock<IValidator<MyRequestMock>>().Object,
                new Mock<IValidator<MyRequestMock>>().Object,
            };
            FailFastPipelineBehavior<MyRequestMock, MyResponseMock> behavior = new FailFastPipelineBehavior<MyRequestMock, MyResponseMock>(validators);
            MyRequestMock request = new MyRequestMock();

            // Act
            MyResponseMock response = await behavior.Handle(request, () => Task.FromResult(new MyResponseMock()), CancellationToken.None);

            // Ensure that the next delegate was called
            Assert.NotNull(response);
        }
    }
}
