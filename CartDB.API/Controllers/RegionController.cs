using System;
using System.Threading.Tasks;
using CartDB.API.Handlers;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ILogger Logger = Log.ForContext<RegionController>();
        private IRegionHandler _regionHandler;

        public RegionController(IRegionHandler regionHandler)
        {
            this._regionHandler = regionHandler;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllRegions()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Region.GetAllRegions by {ip}");

            var regions = await this._regionHandler.GetAllRegionsAsync();
            return Ok(regions);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Region.GetRegionById by {ip}");

            var region = await this._regionHandler.GetRegionByIdAsync(id);
            return Ok(region);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetRegionByName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Region.GetRegionByName by {ip}");

            var region = await this ._regionHandler.GetRegionByNameAsync(name);
            return Ok(region);
        }
    }
}
