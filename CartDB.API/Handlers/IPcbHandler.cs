using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartDB.API.Models;

namespace CartDB.API.Handlers
{
    public interface IPcbHandler
    {
        /// <summary>
        /// Gets a list of all PCBs
        /// </summary>
        /// <returns>list of PCBs</returns>
        Task<List<PcbDto>> GetAllPcbsAsync();

        /// <summary>
        /// Gets a PCB by its ID
        /// </summary>
        /// <param name="id">the id of the PCB wanted</param>
        /// <returns>a PCB</returns>
        Task<PcbDto> GetPcbByIdAsync(Guid id);

        /// <summary>
        /// Gets a PCB by its manufacturer's name
        /// </summary>
        /// <param name="name">the name of the manufacturer of the PCB</param>
        /// <returns>a PCB</returns>
        Task<List<PcbDto>> GetPcbByManufacturerNameAsync(string name);

        /// <summary>
        /// Gets a PCB by its manufacturer's ID
        /// </summary>
        /// <param name="id">the id of the manufacturer of the PCB</param>
        /// <returns>a PCB</returns>
        Task<List<PcbDto>> GetPcbByManufacturerIdAsync(Guid id);
    }
}
