using System.ComponentModel.DataAnnotations;
using EcoTech.Controllers.ViewModels;
using EcoTech.Repositories.Interfaces;
using Infrastructure.Encrypt;
using Infrastructure.Validators;

namespace EcoTech.Controllers.Validators
{
    public class AuthValidator(AuthViewModel instance, IClientUserRepository repository) : Validator<AuthViewModel>(instance)
    {
        public async override Task AddValidations(CancellationToken cancellationToken)
        {
            await AddErrorAsync(AnyAndPasswordPassAsync, cancellationToken);
        }

        private async Task<ValidationResult?> AnyAndPasswordPassAsync(CancellationToken cancellationToken)
        {
            if (!await repository.AnyAsync(_instace.UserName, cancellationToken))
                return new ValidationResult("Usuario nao encontrado ou senha incorreta.");
            else
            {
                var user = await repository.GetAsync(_instace.UserName, cancellationToken);

                if (!PasswordHasher.VerifyPassword(password: instance.Password, hashedPassword: user.Password))
                    return new ValidationResult("Senha incorreta, tente novamente");
            }

            return null;
        }
    }
}
