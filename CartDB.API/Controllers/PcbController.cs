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
    public class PcbController : ControllerBase
    {
        private static readonly ILogger Logger = Log.ForContext<PcbController>();
        private IPcbHandler _pcbHandler;

        public PcbController(IPcbHandler pcbHandler)
        {
            this._pcbHandler = pcbHandler;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllPcbs()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Pcb.GetAllPcbs by {ip}");

            var pcbs = await this._pcbHandler.GetAllPcbsAsync();
            return Ok(pcbs);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPcbById(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Pcb.GetPcbById by {ip}");

            var pcb = await this._pcbHandler.GetPcbByIdAsync(id);
            return Ok(pcb);
        }

        [HttpGet("manufacturer/name")]
        public async Task<IActionResult> GetPcbByManufacturerName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Pcb.GetPcbByManufacturerName by {ip}");

            var pcb = await this._pcbHandler.GetPcbByManufacturerNameAsync(name);
            return Ok(pcb);
        }

        [HttpGet("manufacturer/id")]
        public async Task<IActionResult> GetPcbByManufacturerId(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Pcb.GetPcbByManufacturerId by {ip}");

            var pcb = await this._pcbHandler.GetPcbByManufacturerIdAsync(id);
            return Ok(pcb);
        }

        [HttpGet("chip/partnumber")]
        public async Task<IActionResult> GetPcbByChipPartNumber(string partnumber)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Pcb.GetPcbByChipPartNumber by {ip}");

            var pcbs = await this._pcbHandler.GetPcbByChipPartNumberAsync(partnumber);
            return Ok(pcbs);
        }

        [HttpGet("chip/id")]
        public async Task<IActionResult> GetPcbByChipId(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Pcb.GetPcbByChipId by {ip}");

            var pcbs = await this._pcbHandler.GetPcbByChipIdAsync(id);
            return Ok(pcbs);
        }
    }
}
