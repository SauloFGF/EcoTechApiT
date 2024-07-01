using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Controllers
{
    [Authorize]
    public abstract class BaseController(ILogger<BaseController> logger) : ControllerBase
    {
        private readonly ILogger<BaseController> _logger = logger;
    }
}
