using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IGameHandler
    {
        /// <summary>
        /// Gets a list of all games
        /// </summary>
        /// <returns>list of games</returns>
        Task<List<GameDto>> GetAllGamesAsync();

        /// <summary>
        /// Gets a game by its ID
        /// </summary>
        /// <param name="id">the id of the game wanted</param>
        /// <returns>a game</returns>
        Task<GameDto> GetGameByIdAsync(Guid id);

        /// <summary>
        /// Gets a game by its name
        /// </summary>
        /// <param name="name">the name of the game wanted</param>
        /// <returns>a list of games</returns>
        Task<List<GameDto>> GetGameByNameAsync(string name);

        /// <summary>
        /// Gets a list of games by their publisher's name
        /// </summary>
        /// <param name="name">the name of the publisher of the games</param>
        /// <returns>a list of games</returns>
        Task<List<GameDto>> GetGamesByPublisherNameAsync(string name);

        /// <summary>
        /// Gets a list of games by their publisher's id
        /// </summary>
        /// <param name="id">the id of the publisher of the games</param>
        /// <returns>a list of games</returns>
        Task<List<GameDto>> GetGamesByPublisherIdAsync(Guid id);

        /// <summary>
        /// Gets a list of games by their developer's name
        /// </summary>
        /// <param name="name">the name of the developer of the games</param>
        /// <returns>a list of games</returns>
        Task<List<GameDto>> GetGamesByDeveloperNameAsync(string name);

        /// <summary>
        /// Gets a list of games by their developer's id
        /// </summary>
        /// <param name="id">the id of the developer of the games</param>
        /// <returns>a list of games</returns>
        Task<List<GameDto>> GetGamesByDeveloperIdAsync(Guid id);

        /// <summary>
        /// Gets a list games by the region name
        /// </summary>
        /// <param name="name">the name of the region</param>
        /// <returns>a list of games</returns>
        Task<List<GameDto>> GetGamesByRegionNameAsync(string name);

        /// <summary>
        /// Gets a list games by the region id
        /// </summary>
        /// <param name="id">the id of the region</param>
        /// <returns>a list of games</returns>
        Task<List<GameDto>> GetGamesByRegionIdAsync(Guid id);
    }
}
