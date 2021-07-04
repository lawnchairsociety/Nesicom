using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class PcbModelToDtoMapper : AbstractModelToDtoMapper<Pcb, PcbDto>
    {
        ManufacturerModelToDtoMapper manufacturerMapper = new ManufacturerModelToDtoMapper();
        
        public override PcbDto MapDto(Pcb model)
        {
            if (model == null)
            {
                return null;
            }

            return new PcbDto
            {
                Id = model.PcbId,
                Manufacturer = manufacturerMapper.MapDto(model.Manufacturer),
                Name = model.PcbName,
                Notes = model.PcbNotes,
                // TODO: images
                LifeSpanStart = model.LifeSpanStart,
                LifeSpanEnd = model.LifeSpanEnd,
                Class = model.PcbClass,
                Mapper = model.Mapper,
                PrgRom = model.PrgRom,
                PrgRam = model.PrgRam,
                ChrRom = model.ChrRom,
                ChrRam = model.ChrRam,
                BatteryPresent = (BatteryPresentType)model.BatteryPresent,
                Mirroring = (MirroringType)model.Mirroring,
                CIC = model.Cic
            };
        }
    }
}
