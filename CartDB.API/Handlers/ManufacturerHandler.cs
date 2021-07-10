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
    public class ManufacturerHandler : IManufacturerHandler
    {
        private static readonly ILogger Logger = Log.ForContext<ManufacturerHandler>();
        private readonly NesicomContext _context;
        private readonly ManufacturerModelToDtoMapper _manufacturerMapper;

        public ManufacturerHandler(NesicomContext context, ManufacturerModelToDtoMapper manufacturerMapper)
        {
            this._context = context;
            this._manufacturerMapper = manufacturerMapper;
        }

        public async Task<List<ManufacturerDto>> GetAllManufacturersAsync()
        {
            var manufacturers = this._context.Manufacturers.ToList();

            var result = this._manufacturerMapper.MapDto(manufacturers).ToList();

            return result;
        }

        public async Task<ManufacturerDto> GetManufacturerByIdAsync(Guid id)
        {
            var manufacturer = this._context.Manufacturers
                                .Where(m => m.ManufacturerId == id)
                                .FirstOrDefault();

            var result = this._manufacturerMapper.MapDto(manufacturer);

            return result;
        }

        public async Task<ManufacturerDto> GetManufacturerByNameAsync(string name)
        {
            var manufacturer = this._context.Manufacturers
                                .Where(m => m.ManufacturerName == name)
                                .FirstOrDefault();

            var result = this._manufacturerMapper.MapDto(manufacturer);

            return result;
        }
    }
}
