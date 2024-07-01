using EcoTech.Controllers.ViewModels;
using Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace EcoTech.Controllers
{
    [Route("api/app/auth-client")]
    public class AuthController(ILogger<BaseController> logger): BaseController(logger)
    {
        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthViewModel viewModel, CancellationToken cancellationToken)
        {

        }
    }
}
