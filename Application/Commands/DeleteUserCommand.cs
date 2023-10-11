using MediatR;

namespace Application.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; }
    }
}
