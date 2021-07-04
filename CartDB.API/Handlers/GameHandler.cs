using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.API.Models;
using CartDB.API.Mappers;
using CartDB.Database.Data;
using Serilog;

namespace CartDB.API.Handlers
{
    public class GameHandler : IGameHandler
    {
        private static readonly ILogger Logger = Log.ForContext<GameHandler>();
        private readonly NesicomContext _context;
        private readonly GameModelToDtoMapper _gameMapper;

        public GameHandler(NesicomContext context, GameModelToDtoMapper gameMapper)
        {
            this._context = context;
            this._gameMapper = gameMapper;
        }


        public async Task<List<GameDto>> GetAllGamesAsync()
        {
            var games = this._context.Games.ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<GameDto> GetGameByIdAsync(Guid id)
        {
            var game = this._context.Games
                        .Where(g => g.GameId == id)
                        .FirstOrDefault();

            var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
            var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
            var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
            game.Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
            game.Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
            game.Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);

            var result = this._gameMapper.MapDto(game);

            return result;
        }

        public async Task<List<GameDto>> GetGameByNameAsync(string name)
        {
            var games = this._context.Games
                .Where(g => g.GameName == name).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<List<GameDto>> GetGamesByDeveloperIdAsync(Guid id)
        {
            var games = this._context.Games
                .Where(g => g.DeveloperId == id).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<List<GameDto>> GetGamesByDeveloperNameAsync(string name)
        {
            var games = this._context.Games
                .Where(g => g.Developer.DeveloperName == name).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<List<GameDto>> GetGamesByPublisherIdAsync(Guid id)
        {
            var games = this._context.Games
                .Where(g => g.PublisherId == id).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<List<GameDto>> GetGamesByPublisherNameAsync(string name)
        {
            var games = this._context.Games
                .Where(g => g.Publisher.PublisherName == name).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<List<GameDto>> GetGamesByRegionIdAsync(Guid id)
        {
            var games = this._context.Games
                .Where(g => g.RegionId == id).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<List<GameDto>> GetGamesByRegionNameAsync(string name)
        {
            var games = this._context.Games
                .Where(g => g.Region.RegionName == name).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                var publisherId = this._context.Games.Select(p => p.PublisherId).FirstOrDefault();
                var developerId = this._context.Games.Select(p => p.DeveloperId).FirstOrDefault();
                var regionId = this._context.Games.Select(p => p.RegionId).FirstOrDefault();
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == publisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == developerId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == regionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }
    }
}
