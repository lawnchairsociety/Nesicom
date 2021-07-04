using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class CartridgeSqlHandler
    {
        public static List<string> CreateSqlStatements(List<CartridgeDto> cartridges)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Cartridges](\n" +
                "\t[CartridgeId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[ManufacturerId] UNIQUEIDENTIFIER NULL,\n" +
                "\t[Color] NVARCHAR(MAX) NULL,\n" +
                "\t[FormFactor] NVARCHAR(MAX) NULL,\n" +
                "\t[EmbossedText] NVARCHAR(MAX) NULL,\n" +
                "\t[FrontLabelEntry] NVARCHAR(MAX) NULL,\n" +
                "\t[SealOfQuality] NVARCHAR(MAX) NULL,\n" +
                "\t[MfgStrPresent] BIT NULL,\n" +
                "\t[BackLabelEntry] NVARCHAR(MAX) NULL,\n" +
                "\t[TwoDigitCode] NVARCHAR(MAX) NULL,\n" +
                "\t[Revision] NVARCHAR(MAX) NULL,\n" +
                "\t[PcbId] UNIQUEIDENTIFIER NULL,\n" +
                "\t[CICType] NVARCHAR(MAX) NULL,\n" +
                "\t[Hardware] NVARCHAR(MAX) NULL,\n" +
                "\t[WRAM] NVARCHAR(MAX) NULL,\n" +
                "\t[VRAM] NVARCHAR(MAX) NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Cartridges] PRIMARY KEY ([CartridgeId]),\n" +
                "\tCONSTRAINT [FK_Cartridges_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers]([ManufacturerId]),\n" +
                "\tCONSTRAINT [FK_Cartridges_PcbId] FOREIGN KEY ([PcbId]) REFERENCES [Pcbs]([PcbId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in cartridges)
            {
                var manu_id = "null";
                if (item.ManufacturerId != null)
                {
                    manu_id = $"\'{item.ManufacturerId}\'";
                }

                var pcb_id = "null";
                if (item.PcbId != null)
                {
                    pcb_id = $"\'{item.PcbId}\'";
                }

                var color = "null";
                if (item.Color != null)
                {
                    color = item.Color.Contains("'") ? $"\'{item.Color.Replace("'", "''")}\'" : $"\'{item.Color}\'";
                }

                var form_factor = "null";
                if (item.FormFactor != null)
                {
                    form_factor = item.FormFactor.Contains("'") ? $"\'{item.FormFactor.Replace("'", "''")}\'" : $"\'{item.FormFactor}\'";
                }

                var embossed_text = "null";
                if (item.EmbossedText != null)
                {
                    embossed_text = item.EmbossedText.Contains("'") ? $"\'{item.EmbossedText.Replace("'", "''")}\'" : $"\'{item.EmbossedText}\'";
                }

                var front_label = "null";
                if (item.FrontLabelEntry != null)
                {
                    front_label =  item.FrontLabelEntry.Contains("'") ? $"\'{item.FrontLabelEntry.Replace("'", "''")}\'" : $"\'{item.FrontLabelEntry}\'";
                }

                var seal = "null";
                if (item.SealOfQuality != null)
                {
                    seal = item.SealOfQuality.Contains("'") ? $"\'{item.SealOfQuality.Replace("'", "''")}\'" : $"\'{item.SealOfQuality}\'";
                }

                var mfg_string = "0";
                if (item.MfgStringPresent)
                {
                    mfg_string = "1";
                }

                var back_label = "null";
                if (item.BackLabelEntry != null)
                {
                    back_label = item.BackLabelEntry.Contains("'") ? $"\'{item.BackLabelEntry.Replace("'", "''")}\'" : $"\'{item.BackLabelEntry}\'";
                }

                var two_code = "null";
                if (item.TwoDigitCode != null)
                {
                    two_code = item.TwoDigitCode.Contains("'") ? $"\'{item.TwoDigitCode.Replace("'", "''")}\'" : $"\'{item.TwoDigitCode}\'";
                }

                var rev = "null";
                if (item.Revision != null)
                {
                    rev = item.Revision.Contains("'") ? $"\'{item.Revision.Replace("'", "''")}\'" : $"\'{item.Revision}\'";
                }

                var cic = "null";
                if (item.CICType != null)
                {
                    cic = item.CICType.Contains("'") ? $"\'{item.CICType.Replace("'", "''")}\'" : $"\'{item.CICType}\'";
                }

                var hardware = "null";
                if (item.Hardware != null)
                {
                    hardware = item.Hardware.Contains("'") ? $"\'{item.Hardware.Replace("'", "''")}\'" : $"\'{item.Hardware}\'";
                }

                var wram = "null";
                if (item.WRAM != null)
                {
                    wram = item.WRAM.Contains("'") ? $"\'{item.WRAM.Replace("'", "''")}\'" : $"\'{item.WRAM}\'";
                }

                var vram = "null";
                if (item.VRAM != null)
                {
                    vram = item.VRAM.Contains("'") ? $"\'{item.VRAM.Replace("'", "''")}\'" : $"\'{item.VRAM}\'";
                }

                var temp = string.Format("INSERT INTO Cartridges (CartridgeId, ManufacturerId, Color, FormFactor, EmbossedText, FrontLabelEntry, SealOfQuality, MfgStrPresent, BackLabelEntry, TwoDigitCode, Revision, PcbId, CICType, Hardware, WRAM, VRAM) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15});",
                    $"\'{item.Id}\'",
                    manu_id,
                    color,
                    form_factor,
                    embossed_text,
                    front_label,
                    seal,
                    mfg_string,
                    back_label,
                    two_code,
                    rev,
                    pcb_id,
                    cic,
                    hardware,
                    wram,
                    vram);

                statements.Add(temp);
            }

            return statements;
        }
    }
}
