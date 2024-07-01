using Infrastructure.Models;

namespace EcoTech.Models
{
    public class ClientUser(string name, string lastName, string cpf, string email, string password) : BaseUserModel(cpf, password)
    {
        public string Name { get; protected set; } = name ?? throw new ArgumentNullException(nameof(name));
        public string LastName { get; protected set; } = lastName ?? throw new ArgumentNullException(nameof(lastName));
        public CContact Contact { get; protected set; } = new CContact(email: email, phone1: null, phone2: null);
        public CAddress? Address { get; protected set; }

        public void Update(string name, string lastName, string cpf)
        {
            Name = name;
            LastName = lastName;
            Cpf = cpf;
        }

        public void AddOrUpdateContact(string email, string phone1, string phone2)
            => Contact = new CContact(email, phone1, phone2);

        public void AddOrUpdateAddress(string street, string neigborhood, string number, string city, string state, string country)
            => Address = new CAddress(street, neigborhood, number, city, state, country);
    }

    public class CAddress(string street, string neighborhood, string number, string city, string state, string country)
    {
        public string Street { get; private set; } = street;
        public string Neighborhood { get; private set; } = neighborhood;
        public string Number { get; private set; } = number;
        public string City { get; private set; } = city;
        public string State { get; private set; } = state;
        public string Country { get; private set; } = country;
    }

    public class CContact(string email, string? phone1, string? phone2)
    {
        public string Email { get; private set; } = email;
        public string Phone1 { get; private set; } = phone1;
        public string Phone2 { get; private set; } = phone2;
    }
}
