using System;
using System.Threading.Tasks;
using CartDB.API.Handlers;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private static readonly ILogger Logger = Log.ForContext<ManufacturerController>();
        private IManufacturerHandler _manufacturerHandler;

        public ManufacturerController(IManufacturerHandler manufacturerHandler)
        {
            this._manufacturerHandler = manufacturerHandler;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllManufacturers()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Manufacturer.GetAllManufacturers by {ip}");

            var manufacturers = await this._manufacturerHandler.GetAllManufacturersAsync();
            return Ok(manufacturers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetManufacturerById(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Manufacturer.GetManufacturerById by {ip}");

            var manufacturer = await this._manufacturerHandler.GetManufacturerByIdAsync(id);
            return Ok(manufacturer);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetManufacturerByName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Manufacturer.GetManufacturerByName by {ip}");

            var manufacturer = await this._manufacturerHandler.GetManufacturerByNameAsync(name);
            return Ok(manufacturer);
        }
    }
}
