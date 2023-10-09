using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; }
        public string Address { get; }
        public string CEP { get; }
        public string Email { get; }
        public string Cpf { get; }
        public string Phone { get; }
        public string City { get; }
        public string State { get; }

        public CreateUserCommand(string name, string address, string cep, string email, string cpf, string phone, string city, string state)
        {
            Name = name;
            Address = address;
            CEP = cep;
            Email = email;
            Cpf = cpf;
            Phone = phone;
            City = city;
            State = state;
        }
    }
}
