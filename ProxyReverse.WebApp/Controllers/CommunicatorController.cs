using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models;
using ProxyReverse.Web.Services.Models;

namespace ProxyReverse.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommunicatorController : ControllerBase
    {
        private readonly ILogger<CommunicatorController> _logger;

        public CommunicatorController(ILogger<CommunicatorController> logger, ITunnelRequestHandler tunnelRequestHandler)
        {
            _logger = logger;
            TunnelRequestHandler = tunnelRequestHandler;
        }

        public ITunnelRequestHandler TunnelRequestHandler { get; }

        [HttpGet]
        public IActionResult Post([FromBody] TunelRequest tunelRequest)
        {
            TunnelRequestHandler.CreateTunnel();
            return Ok();
        }


    }
}
