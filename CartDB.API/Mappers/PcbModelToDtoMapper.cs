using System.Linq;
using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class PcbModelToDtoMapper : AbstractModelToDtoMapper<Pcb, PcbDto>
    {
        ManufacturerModelToDtoMapper manufacturerMapper = new ManufacturerModelToDtoMapper();
        ImageModelToDtoMapper imageMapper = new ImageModelToDtoMapper();
        
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
                CIC = model.CIC,
                OtherChips = model.OtherChips,
                Images = imageMapper.MapDto(model.Images).ToList()
            };
        }
    }
}
