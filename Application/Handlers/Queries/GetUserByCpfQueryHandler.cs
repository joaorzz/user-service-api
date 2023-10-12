using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetUserByCpfQueryHandler : IRequestHandler<GetUserByCpfQuery, UserDTO>
    {
        private readonly IUserReadOnlyService _userManagementService;

        public GetUserByCpfQueryHandler(IUserReadOnlyService userManagementService)
        {
            _userManagementService = userManagementService;
        }
        public async Task<UserDTO> Handle(GetUserByCpfQuery request, CancellationToken cancellationToken)
        {
            User user = await _userManagementService.GetUserByCpf(request.Cpf);

            return new UserDTO(user);
        }
    }
}
