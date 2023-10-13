using Application.Commands;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserWritableService _userWritableService;
        private ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserWritableService userWritableService, ILogger<DeleteUserCommandHandler> logger)
        {
            _userWritableService = userWritableService;
            _logger = logger;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userWritableService.DeleteUser(request.Id);

            _logger.LogInformation($"User with id {request.Id} was deleted.");
        }
    }
}
