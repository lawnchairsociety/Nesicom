using System;
using System.Threading.Tasks;
using CartDB.API.Handlers;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger Logger = Log.ForContext<PublisherController>();
        private IPublisherHandler _publisherHandler;

        public PublisherController(IPublisherHandler publisherHandler)
        {
            this._publisherHandler = publisherHandler;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllPublishers()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Publisher.GetAllPublishers by {ip}");

            var publishers = await this._publisherHandler.GetAllPublishersAsync();
            return Ok(publishers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPublisherById(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Publisher.GetPublisherById by {ip}");

            var publisher = await this._publisherHandler.GetPublisherByIdAsync(id);
            return Ok(publisher);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetPublisherByName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Publisher.GetPublisherByName by {ip}");

            var publisher = await this._publisherHandler.GetPublisherByNameAsync(name);
            return Ok(publisher);
        }
    }
}
