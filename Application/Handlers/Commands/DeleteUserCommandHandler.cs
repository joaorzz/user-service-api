using Application.Commands;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserWritableService _userWritableService;

        public DeleteUserCommandHandler(IUserWritableService userWritableService)
        {
            _userWritableService = userWritableService;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userWritableService.DeleteUser(request.Id);
        }
    }
}
