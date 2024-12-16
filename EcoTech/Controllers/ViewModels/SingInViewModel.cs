using System.ComponentModel.DataAnnotations;

namespace EcoTech.Controllers.ViewModels
{
    public class SingInViewModel
    {
        [Required(ErrorMessage = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password")]
        public string CreatePassword { get; set; }

        [Required(ErrorMessage = "PasswordConfirm")]
        public string PasswordConfirmed { get; set; }
    }
}
