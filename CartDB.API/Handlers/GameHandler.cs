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
    public class GameHandler : IGameHandler
    {
        private static readonly ILogger Logger = Log.ForContext<GameHandler>();
        private readonly NesicomPostgreContext _context;
        private readonly GameModelToDtoMapper _gameMapper;

        public GameHandler(NesicomPostgreContext context, GameModelToDtoMapper gameMapper)
        {
            this._context = context;
            this._gameMapper = gameMapper;
        }


        public async Task<List<GameDto>> GetAllGamesAsync(int offset, int count)
        {
            var games = this._context.Games.Skip(offset).Take(count).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<GameDto> GetGameByIdAsync(Guid id)
        {
            var game = this._context.Games
                        .Where(g => g.GameId == id)
                        .FirstOrDefault();

            game.Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == game.PublisherId);
            game.Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == game.DeveloperId);
            game.Region = this._context.Regions.FirstOrDefault(m => m.RegionId == game.RegionId);

            var result = this._gameMapper.MapDto(game);

            return result;
        }

        public async Task<List<GameDto>> GetGameByNameAsync(string name)
        {
            var games = this._context.Games
                .Where(g => g.GameName == name).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }

        public async Task<GameDto> GetGameByCatalogEntryAsync(string catalogentry)
        {
            var game = this._context.Games
                .FirstOrDefault(g => g.CatalogEntry == catalogentry);

            game.Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == game.PublisherId);
            game.Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == game.DeveloperId);
            game.Region = this._context.Regions.FirstOrDefault(m => m.RegionId == game.RegionId);

            var result = this._gameMapper.MapDto(game);

            return result;
        }

        public async Task<List<GameDto>> GetGamesByDeveloperIdAsync(Guid id)
        {
            var games = this._context.Games
                .Where(g => g.DeveloperId == id).ToList();

            for (var i = 0; i < games.Count; i++)
            {
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
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
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
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
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
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
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
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
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
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
                games[i].Publisher = this._context.Publishers.FirstOrDefault(m => m.PublisherId == games[i].PublisherId);
                games[i].Developer = this._context.Developers.FirstOrDefault(m => m.DeveloperId == games[i].DeveloperId);
                games[i].Region = this._context.Regions.FirstOrDefault(m => m.RegionId == games[i].RegionId);
            }

            var result = this._gameMapper.MapDto(games).ToList();

            return result;
        }
    }
}
