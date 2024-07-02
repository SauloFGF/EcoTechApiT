using EcoTech.Controllers.ViewModels;
using Infrastructure.Controllers;
using Infrastructure.Encrypt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoTech.Controllers
{
    [Route("api/app/auth-client")]
    public class AuthController(ILogger<BaseController> logger, JwtSettings jwtSettings) : BaseController(logger)
    {
        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthViewModel viewModel, CancellationToken cancellationToken)
        {
            string token = TokenEx.GenerateToken(jwtSettings);

            return Ok(new { AccessToken = token });
        }
    }
}
