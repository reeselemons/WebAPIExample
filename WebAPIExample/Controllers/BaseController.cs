using Microsoft.AspNetCore.Mvc;

namespace WebAPIExample.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly ILogger<LoginController> _logger;
        public BaseController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
    }
}
