using System;
using System.Threading.Tasks;
using CartDB.API.Handlers;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartridgeController : ControllerBase
    {
        private static readonly ILogger Logger = Log.ForContext<CartridgeController>();
        private ICartridgeHandler _cartridgeHandler;

        public CartridgeController(ICartridgeHandler cartridgeHandler)
        {
            this._cartridgeHandler = cartridgeHandler;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllCartridges(int offset = 0, int count = 25)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Cartridge.GetAllCartridges by {ip}");

            var cartridges = await this._cartridgeHandler.GetAllCartridgesAsync(offset, count);
            return Ok(cartridges);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCartridgeById(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Cartridge.GetCartridgeById by {ip}");

            var cartridge = await this._cartridgeHandler.GetCartridgeByIdAsync(id);
            return Ok(cartridge);
        }

        [HttpGet("manufacturer/name")]
        public async Task<IActionResult> GetCartridgeByManufacturerName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Cartridge.GetCartridgeByManufacturerName by {ip}");

            var cartridges = await this._cartridgeHandler.GetCartridgesByManufacturerNameAsync(name);
            return Ok(cartridges);
        }

        [HttpGet("manufacturer/id")]
        public async Task<IActionResult> GetCartridgeByManufacturerId(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Cartridge.GetCartridgeByManufacturerId by {ip}");

            var cartridges = await this._cartridgeHandler.GetCartridgesByManufacturerIdAsync(id);
            return Ok(cartridges);
        }

        [HttpGet("chip/partnumber")]
        public async Task<IActionResult> GetCartridgeByChipPartNumber(string partnumber)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Cartridge.GetCartridgeByChipPartNumber by {ip}");

            var cartridges = await this._cartridgeHandler.GetCartridgesByChipPartNumberAsync(partnumber);
            return Ok(cartridges);
        }

        [HttpGet("chip/id")]
        public async Task<IActionResult> GetCartridgeByChipId(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Cartridge.GetCartridgeByChipId by {ip}");

            var cartridges = await this._cartridgeHandler.GetCartridgesByChipIdAsync(id);
            return Ok(cartridges);
        }
    }
}
