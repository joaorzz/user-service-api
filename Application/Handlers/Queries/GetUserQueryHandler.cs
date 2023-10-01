using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UsersResultDTO>
    {
        private readonly IUserReadOnlyService _userManagementService;

        public GetUserQueryHandler(IUserReadOnlyService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<UsersResultDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            List<User> users = await _userManagementService.GetAllUsers();

            return new UsersResultDTO(users);
        }
    }
}
