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

        /// <summary>
        /// Gets a list PCBs by the chip's part number
        /// </summary>
        /// <param name="partnumber">the partnumber of the chip on the PCB</param>
        /// <returns>a list of PCBs</returns>
        Task<List<PcbDto>> GetPcbByChipPartNumberAsync(string partnumber);

        /// <summary>
        /// Gets a list PCBs by the chip's id
        /// </summary>
        /// <param name="id">the id of the chip on the PCB</param>
        /// <returns>a list of PCBs</returns>
        Task<List<PcbDto>> GetPcbByChipIdAsync(Guid id);
    }
}
