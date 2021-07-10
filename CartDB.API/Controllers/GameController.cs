using System;
using System.Threading.Tasks;
using CartDB.API.Handlers;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger Logger = Log.ForContext<GameController>();
        private IGameHandler _gameHandler;

        public GameController(IGameHandler gameHandler)
        {
            this._gameHandler = gameHandler;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllGames(int offset = 0, int count = 25)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetAllGames by {ip}");

            var games = await this._gameHandler.GetAllGamesAsync(offset, count);
            return Ok(games);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetGameById(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameById by {ip}");

            var game = await this._gameHandler.GetGameByIdAsync(id);
            return Ok(game);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetGamesByName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGamesByName by {ip}");

            var games = await this._gameHandler.GetGameByNameAsync(name);
            return Ok(games);
        }

        [HttpGet("catalogentry")]
        public async Task<IActionResult> GetGameByCatalogEntry(string catalogentry)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameByCatalogEntry by {ip}");

            var game = await this._gameHandler.GetGameByCatalogEntryAsync(catalogentry);
            return Ok(game);
        }

        [HttpGet("publisher/name")]
        public async Task<IActionResult> GetGameByPublisherName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameByPublisherName by {ip}");

            var games = await this._gameHandler.GetGamesByPublisherNameAsync(name);
            return Ok(games);
        }

        [HttpGet("publisher/id")]
        public async Task<IActionResult> GetGameByPublisherId(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameByPublisherId by {ip}");

            var games = await this._gameHandler.GetGamesByPublisherIdAsync(id);
            return Ok(games);
        }

        [HttpGet("developer/name")]
        public async Task<IActionResult> GetGameByDeveloperName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameByDeveloperName by {ip}");

            var games = await this._gameHandler.GetGamesByDeveloperNameAsync(name);
            return Ok(games);
        }

        [HttpGet("developer/id")]
        public async Task<IActionResult> GetGameByDeveloperId(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameByDeveloperId by {ip}");

            var games = await this._gameHandler.GetGamesByDeveloperIdAsync(id);
            return Ok(games);
        }

        [HttpGet("region/name")]
        public async Task<IActionResult> GetGameByRegionName(string name)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameByRegionName by {ip}");

            var games = await this._gameHandler.GetGamesByRegionNameAsync(name);
            return Ok(games);
        }

        [HttpGet("region/id")]
        public async Task<IActionResult> GetGameByRegionId(Guid id)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Game.GetGameByRegionId by {ip}");

            var games = await this._gameHandler.GetGamesByRegionIdAsync(id);
            return Ok(games);
        }
    }
}
