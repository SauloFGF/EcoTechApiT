using EcoTech.Models;
using Infrastructure.Encrypt;

namespace Infrastructure.Models
{
    public abstract class BaseUserModel : BaseModel
    {
        protected BaseUserModel(string cpf, string password)
        {
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Password = password ?? throw new ArgumentNullException(nameof(password));

            GeneratePassword(Password);

        }

        public string Cpf { get; protected set; }
        public string Password { get; protected set; }

        public virtual void GeneratePassword(string password)
        {
            Password = PasswordHasher.HashPassword(password);
        }
    }
}
