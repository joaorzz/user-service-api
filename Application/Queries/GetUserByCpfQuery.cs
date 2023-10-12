using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetUserByCpfQuery : IRequest<UserDTO>
    {
        public string Cpf { get; }

        public GetUserByCpfQuery(string cpf)
        {
            Cpf = cpf;
        }

    }
}
