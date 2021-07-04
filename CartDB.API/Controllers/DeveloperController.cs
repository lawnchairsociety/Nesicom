using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CartDB.API.Models;
using Serilog;
using System.Collections.Generic;
using CartDB.API.Handlers;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly ILogger Logger = Log.ForContext<DeveloperController>();
        private IDeveloperHandler _developerHandler;

        public DeveloperController(IDeveloperHandler developerHandler)
        {
            this._developerHandler = developerHandler;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllDevelopers()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Developer.GetAllDevelopers by {ip}");

            var developers = await this._developerHandler.GetAllDevelopersAsync();
            return Ok(developers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetDeveloperById(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Developer.GetDeveloperById by {ip}");

            var developer = await this._developerHandler.GetDeveloperByIdAsync(id);
            return Ok(developer);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetDeveloperByName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Developer.GetDeveloperByName by {ip}");

            var developer = await this._developerHandler.GetDeveloperByNameAsync(name);
            return Ok(developer);
        }
    }
}
