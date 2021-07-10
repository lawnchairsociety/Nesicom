using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IStatsHandler
    {
        /// <summary>
        /// Gets the stats on the data we have
        /// </summary>
        /// <returns>stats information</returns>
        Task<StatsDto> GetDataStatsAsync();
    }
}
