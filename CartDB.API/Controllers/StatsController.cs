using System;
using System.Threading.Tasks;
using CartDB.API.Handlers;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private static readonly ILogger Logger = Log.ForContext<StatsController>();
        private IStatsHandler _statsHandler;

        public StatsController(IStatsHandler statsHandler)
        {
            this._statsHandler = statsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetDataStats()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Stats.GetDataStats by {ip}");

            var stats = await this._statsHandler.GetDataStatsAsync();
            return Ok(stats);
        }
    }
}
