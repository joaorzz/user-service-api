using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUserReadOnlyService _userManagementService;

        public GetUserByIdQueryHandler(IUserReadOnlyService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userManagementService.GetUserById(request.Id);

            return new UserDTO(user);
        }
    }
}
