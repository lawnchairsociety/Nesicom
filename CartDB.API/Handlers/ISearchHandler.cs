using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface ISearchHandler
    {
        /// <summary>
        /// Searches the context for the query string
        /// </summary>
        /// <param name="query">the query value</param>
        /// <returns>search results</returns>
        Task<SearchDto> SearchContextsAsync(string query);
    }
}
