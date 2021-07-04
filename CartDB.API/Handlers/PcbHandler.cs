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

        public async Task<List<PcbDto>> GetAllPcbsAsync()
        {
            var pcbs = this._context.Pcbs.ToList();

            for(var i = 0; i < pcbs.Count; i++)
            {
                var manufacturerId = this._context.Pcbs.Select(p => p.ManufacturerId).FirstOrDefault();
                pcbs[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }

        public async Task<PcbDto> GetPcbByIdAsync(Guid id)
        {
            var pcb = this._context.Pcbs.FirstOrDefault(p => p.PcbId == id);

            var manufacturerId = this._context.Pcbs.Select(p => p.ManufacturerId).FirstOrDefault();
            pcb.Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);

            var result = this._pcbMapper.MapDto(pcb);

            return result;
        }

        public async Task<List<PcbDto>> GetPcbByChipIdAsync(Guid id)
        {
            var pcbs = this._context.Pcbs
                .Where(p => p.PcbOtherChips.Contains(
                        this._context.PcbOtherChips.FirstOrDefault(oc => oc.OtherChipId == id)
                 )).ToList();

            for (var i = 0; i < pcbs.Count; i++)
            {
                var manufacturerId = this._context.Pcbs.Select(p => p.ManufacturerId).FirstOrDefault();
                pcbs[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }

        public async Task<List<PcbDto>> GetPcbByChipPartNumberAsync(string partnumber)
        {
            var pcbs = this._context.Pcbs
                .Where(p => p.PcbOtherChips.Contains(
                        this._context.PcbOtherChips.FirstOrDefault(oc => oc.OtherChip.OtherChipName == partnumber)
                 )).ToList();

            for (var i = 0; i < pcbs.Count; i++)
            {
                var manufacturerId = this._context.Pcbs.Select(p => p.ManufacturerId).FirstOrDefault();
                pcbs[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }

        public async Task<List<PcbDto>> GetPcbByManufacturerIdAsync(Guid id)
        {
            var pcbs = this._context.Pcbs
                .Where(p => p.ManufacturerId == id).ToList();

            for (var i = 0; i < pcbs.Count; i++)
            {
                var manufacturerId = this._context.Pcbs.Select(p => p.ManufacturerId).FirstOrDefault();
                pcbs[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }

        public async Task<List<PcbDto>> GetPcbByManufacturerNameAsync(string name)
        {
            var pcbs = this._context.Pcbs
                .Where(p => p.Manufacturer.ManufacturerName == name).ToList();

            for (var i = 0; i < pcbs.Count; i++)
            {
                var manufacturerId = this._context.Pcbs.Select(p => p.ManufacturerId).FirstOrDefault();
                pcbs[i].Manufacturer = this._context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == manufacturerId);
            }

            var result = this._pcbMapper.MapDto(pcbs).ToList();

            return result;
        }
    }
}
