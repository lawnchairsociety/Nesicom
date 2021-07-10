using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartDB.API.Mappers;
using CartDB.API.Models;
using CartDB.Database.Data;
using Serilog;

namespace CartDB.API.Handlers
{
    public class StatsHandler : IStatsHandler
    {
        public static readonly ILogger Logger = Log.ForContext<StatsHandler>();
        private readonly NesicomContext _context;

        public StatsHandler(NesicomContext context)
        {
            this._context = context;
        }

        public async Task<StatsDto> GetDataStatsAsync()
        {
            return new StatsDto
            {
                CartridgeCount = this._context.Cartridges.ToList().Count,
                GameCount = this._context.Games.ToList().Count,
                PcbCount = this._context.Pcbs.ToList().Count,
                DeveloperCount = this._context.Developers.ToList().Count,
                PublisherCount = this._context.Publishers.ToList().Count,
                ManufacturerCount = this._context.Manufacturers.ToList().Count,
                RegionCount = this._context.Regions.ToList().Count,
                CartridgeChipCount = this._context.CartridgeChips.ToList().Count
            };
        }
    }
}
