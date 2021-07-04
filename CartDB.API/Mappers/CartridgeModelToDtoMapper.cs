﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDB.API.Models;
using CartDB.Database.Models;

namespace CartDB.API.Mappers
{
    public class CartridgeModelToDtoMapper : AbstractModelToDtoMapper<Cartridge, CartridgeDto>
    {
        public override CartridgeDto MapDto(Cartridge model)
        {
            ManufacturerModelToDtoMapper manufacturerMapper = new ManufacturerModelToDtoMapper();
            PcbModelToDtoMapper pcbMapper = new PcbModelToDtoMapper();

            if (model == null)
            {
                return null;
            }

            return new CartridgeDto
            {
                Id = model.CartridgeId,
                // TODO - game
                Manufacturer = manufacturerMapper.MapDto(model.Manufacturer),
                Pcb = pcbMapper.MapDto(model.Pcb),
                // TODO - cartridgechips
                // TODO - images
                Color = model.Color,
                FormFactor = model.FormFactor,
                EmbossedText = model.EmbossedText,
                FrontLabelEntry = model.FrontLabelEntry,
                SealOfQuality = model.SealOfQuality,
                MfgStringPresent = model.MfgStrPresent.Value,
                BackLabelEntry = model.BackLabelEntry,
                TwoDigitCode = model.TwoDigitCode,
                Revision = model.Revision,
                CICType = model.Cictype,
                Hardware = model.Hardware,
                WRAM = model.Wram,
                VRAM = model.Vram
            };
        }
    }
}
