using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using CartDB.API.Handlers;

namespace CartDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private static readonly ILogger Logger = Log.ForContext<SearchController>();
        private ISearchHandler _searchHandler;

        public SearchController(ISearchHandler searchHandler)
        {
            this._searchHandler = searchHandler;
        }

        [HttpGet]
        public async Task<IActionResult> SearchContextsAsync(string query)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Logger.Information($"Cartridge.GetAllCartridges by {ip}");

            var results = await this._searchHandler.SearchContextsAsync(query);
            return Ok(results);
        }
    }
}
