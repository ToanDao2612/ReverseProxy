using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProxyReverse.Web.Core.InternalyImplementedServices;
using ProxyReverse.Web.DependencyInjection;
using ProxyReverse.WebApi.Models;

namespace ProxyReverse.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TunnelController : ControllerBase
    {
        private readonly ILogger<TunnelController> _logger;

        public TunnelController(ILogger<TunnelController> logger, ITunnelRequestHandler tunnelRequestHandler)
        {
            _logger = logger;
            TunnelRequestHandler = tunnelRequestHandler;
        }

        public ITunnelRequestHandler TunnelRequestHandler { get; }

        [HttpGet]
        public IActionResult Post([FromBody] TunelRequest tunelRequest)
        {
            TunnelRequestHandler.CreateTunnel(new Web.Core.DataTransferObjects.HttpTunelRequest()
            {
                Port = 4400,
            });
            return Ok();
        }
    }
}
