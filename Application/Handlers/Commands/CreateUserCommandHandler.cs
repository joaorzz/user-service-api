using Application.Commands;
using Domain.Entities;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserWritableService _userWritableService;

        public CreateUserCommandHandler(IUserWritableService userWritableService)
        {
            _userWritableService = userWritableService;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User(request.Name, request.Address, request.CEP, request.Email, request.Cpf, request.Phone, request.City, request.State);

            await _userWritableService.CreateUser(user);
        }
    }
}
