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
    public class PcbHandler : IPcbHandler
    {
        private static readonly ILogger Logger = Log.ForContext<PcbHandler>();
        private readonly NesicomContext _context;
        private readonly PcbModelToDtoMapper _pcbMapper;

        public PcbHandler(NesicomContext context, PcbModelToDtoMapper pcbMapper)
        {
            this._context = context;
            this._pcbMapper = pcbMapper;
        }

        public async Task<List<PcbDto>> GetAllPcbsAsync(int offset, int count)
        {
            var pcbs = this._context.Pcbs.Skip(offset).Take(count).ToList();

            foreach(var pcb in pcbs)
            {
                pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == pcb.ManufacturerId);
                pcb.Images = this._context.Images.Where(i => i.PcbId == pcb.PcbId).ToList();
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }

        public async Task<PcbDto> GetPcbByIdAsync(Guid id)
        {
            var pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == id);
            pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == pcb.ManufacturerId);
            pcb.Images = this._context.Images.Where(i => i.PcbId == pcb.PcbId).ToList();

            var result = this._pcbMapper.MapDto(pcb);

            return result;
        }

        public async Task<List<PcbDto>> GetPcbByManufacturerIdAsync(Guid id)
        {
            var pcbs = this._context.Pcbs
                .Where(p => p.ManufacturerId == id).ToList();

            foreach (var pcb in pcbs)
            {
                pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == pcb.ManufacturerId);
                pcb.Images = this._context.Images.Where(i => i.PcbId == pcb.PcbId).ToList();
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }

        public async Task<List<PcbDto>> GetPcbByManufacturerNameAsync(string name)
        {
            var pcbs = this._context.Pcbs
                .Where(p => p.Manufacturer.ManufacturerName == name).ToList();

            foreach (var pcb in pcbs)
            {
                pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == pcb.ManufacturerId);
                pcb.Images = this._context.Images.Where(i => i.PcbId == pcb.PcbId).ToList();
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }
    }
}
