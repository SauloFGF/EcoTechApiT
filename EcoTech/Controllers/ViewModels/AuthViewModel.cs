using System.ComponentModel.DataAnnotations;

namespace EcoTech.Controllers.ViewModels
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "O campo Email/CPF é obrigatório")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        public required string Password { get; set; }
    }
}
