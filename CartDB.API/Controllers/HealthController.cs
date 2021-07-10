using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private static readonly ILogger Logger = Log.ForContext<HealthController>();

        public HealthController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Health.Get by {ip}");
            return Ok();
        }
    }
}
