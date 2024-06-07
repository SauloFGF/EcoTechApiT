using Microsoft.AspNetCore.Components;

namespace EcoTech.Controllers
{
    [Route("api/app/auth-client")]
    public class AuthController(ILogger<BaseController> logger): BaseController(logger)
    {

    }
}
