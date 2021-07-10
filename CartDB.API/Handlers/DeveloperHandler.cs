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
    public class DeveloperHandler : IDeveloperHandler
    {
        private static readonly ILogger Logger = Log.ForContext<DeveloperHandler>();
        private readonly NesicomContext _context;
        private readonly DeveloperModelToDtoMapper _developerMapper;

        public DeveloperHandler(NesicomContext context, DeveloperModelToDtoMapper developerMapper)
        {
            this._context = context;
            this._developerMapper = developerMapper;
        }

        public async Task<List<DeveloperDto>> GetAllDevelopersAsync()
        {
            var developers = this._context.Developers.ToList();

            var result = this._developerMapper.MapDto(developers).ToList();

            return result;
        }

        public async Task<DeveloperDto> GetDeveloperByIdAsync(Guid id)
        {
            var developer = this._context.Developers
                                .Where(p => p.DeveloperId == id)
                                .FirstOrDefault();

            var result = this._developerMapper.MapDto(developer);

            return result;
        }

        public async Task<DeveloperDto> GetDeveloperByNameAsync(string name)
        {
            var developer = this._context.Developers
                                .Where(p => p.DeveloperName == name)
                                .FirstOrDefault();

            var result = this._developerMapper.MapDto(developer);

            return result;
        }
    }
}
