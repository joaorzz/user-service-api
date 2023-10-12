namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }

        public User() { }

        public User(string name, string address, string cep, string email, string cpf, string phone, string city, string state)
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
