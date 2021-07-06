using System;
using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public class PcbMapper
    {
        // (CREATE ENUM FOR BATTERYPRESENT)
        // (CREATE ENUM FOR MIRRORING)
        // (REMOVE "CIC versions used: " FROM CIC)
        // (REMOVE "Other chips used: " FROM OTHERCHIPS)
        // (REPLACE "No mappers or additional chips present" WITH "None" FOR OTHERCHIPS)
        public static List<Pcb> MapData(List<TransientPcbModel> pcbs, List<Manufacturer> manufacturers, List<Image> images)
        {
            var result = new List<Pcb>();

            foreach (var pcb in pcbs)
            {
                var newPcb = new Pcb
                {
                    PcbId = pcb.Nid,
                    ManufacturerId = null,
                    PcbName = pcb.PcbName,
                    PcbNotes = pcb.PcbNotes,
                    PcbClass = pcb.PcbClass,
                    Mapper = pcb.Mapper,
                    PrgRom = pcb.PRGRom,
                    PrgRam = pcb.PRGRam,
                    ChrRom = pcb.CHRRom,
                    ChrRam = pcb.CHRRam,
                    BatteryPresent = 0,
                    Mirroring = 0,
                    CIC = pcb.CIC.Replace("CIC versions used: ", ""),
                    OtherChips = pcb.OtherChips.Replace("Other chips used: ", "").Replace("No mappers or additional chips present", "None"),
                    Images = images.Where(i => i.PcbId == pcb.Nid).ToList()
                };

                // manufacturer id
                if (manufacturers.Where(m => m.ManufacturerName == pcb.Manufacturer).Count() != 0)
                {
                    newPcb.ManufacturerId = manufacturers.Where(m => m.ManufacturerName == pcb.Manufacturer).FirstOrDefault().ManufacturerId;
                }

                // lifespans
                if (string.IsNullOrEmpty(pcb.LifeSpan))
                {
                    newPcb.LifeSpanStart = null;
                    newPcb.LifeSpanEnd = null;
                }
                else
                {
                    var lfParts = pcb.LifeSpan.Split(" - ");
                    newPcb.LifeSpanStart = DateTime.Parse(lfParts[0]);

                    if (lfParts.Length > 1)
                    {
                        newPcb.LifeSpanEnd = DateTime.Parse(lfParts[1]);
                    }
                }

                // batteryPresent
                switch(pcb.BatteryPresent)
                {
                    case "Battery is not available":
                        newPcb.BatteryPresent = 1;
                        break;
                    case "Battery is optional":
                        newPcb.BatteryPresent = 2;
                        break;
                    case "Battery is present":
                        newPcb.BatteryPresent = 3;
                        break;
                    default:
                        newPcb.BatteryPresent = 0;
                        break;
                }

                // mirroring
                switch (pcb.Mirroring)
                {
                    case "Uses vertical mirroring":
                        newPcb.Mirroring = 1;
                        break;
                    case "Uses mapper controlled mirroring":
                        newPcb.Mirroring = 2;
                        break;
                    case "Uses horizontal or vertical mirroring":
                        newPcb.Mirroring = 3;
                        break;
                    case "Uses horizontal mirroring":
                        newPcb.Mirroring = 4;
                        break;
                    case "Uses four screen mirroring":
                        newPcb.Mirroring = 5;
                        break;
                    case "Uses one screen mirroring":
                        newPcb.Mirroring = 6;
                        break;
                    default:
                        newPcb.Mirroring = 0;
                        break;
                }

                result.Add(newPcb);
            }

            return result;
        }
    }
}
