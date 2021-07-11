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
    public class RegionHandler : IRegionHandler
    {
        private static readonly ILogger Logger = Log.ForContext<RegionHandler>();
        private readonly NesicomContext _context;
        private readonly RegionModelToDtoMapper _regionMapper;

        public RegionHandler(NesicomContext context, RegionModelToDtoMapper regionMapper)
        {
            this._context = context;
            this._regionMapper = regionMapper;
        }

        public async Task<List<RegionDto>> GetAllRegionsAsync()
        {
            var regions = this._context.Regions.ToList();
            
            var result = this._regionMapper.MapDto(regions).ToList();

            return result;
        }

        public async Task<RegionDto> GetRegionByIdAsync(Guid id)
        {
            var region = this._context.Regions
                            .Where(r => r.RegionId == id)
                            .FirstOrDefault();
            
            var result = this._regionMapper.MapDto(region);

            return result;
        }

        public async Task<RegionDto> GetRegionByNameAsync(string name)
        {
            var region = this._context.Regions
                            .Where(r => r.RegionName == name)
                            .FirstOrDefault();
            
            var result = this._regionMapper.MapDto(region);

            return result;
        }
    }
}
