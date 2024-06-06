using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoTech.Controllers
{
    [Authorize]
    public abstract class BaseController(ILogger<BaseController> logger) : ControllerBase
    {
        private readonly ILogger<BaseController> _logger = logger;
    }
}
