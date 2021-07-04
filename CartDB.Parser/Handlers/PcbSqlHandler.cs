using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class PcbSqlHandler
    {
        public static List<string> CreateSqlStatements(List<PcbDto> pcbs)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Pcbs](\n" +
                "\t[PcbId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[ManufacturerId] UNIQUEIDENTIFIER NULL,\n" +
                "\t[PcbName] NVARCHAR(MAX) NOT NULL,\n" +
                "\t[PcbNotes] NVARCHAR(MAX) NOT NULL,\n" +
                "\t[LifeSpanStart] DATETIME NULL,\n" +
                "\t[LifeSpanEnd] DATETIME NULL,\n" +
                "\t[PcbClass] NVARCHAR(MAX) NOT NULL,\n" +
                "\t[Mapper] NVARCHAR(MAX) NOT NULL,\n" +
                "\t[PrgRom] NVARCHAR(MAX) NULL,\n" +
                "\t[PrgRam] NVARCHAR(MAX) NULL,\n" +
                "\t[ChrRom] NVARCHAR(MAX) NULL,\n" +
                "\t[ChrRam] NVARCHAR(MAX) NULL,\n" +
                "\t[BatteryPresent] INT NOT NULL DEFAULT 0,\n" +
                "\t[Mirroring] INT NOT NULL DEFAULT 0,\n" +
                "\t[CIC] NVARCHAR(MAX) NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Pcbs] PRIMARY KEY ([PcbId]),\n" +
                "\tCONSTRAINT [FK_Pcbs_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers]([ManufacturerId])\n" +
                ")\n" +
                "";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in pcbs)
            {
                var manu_id = "null";
                if (item.ManufacturerId != null)
                {
                    manu_id = $"\'{item.ManufacturerId}\'";
                }

                var ls_start = "null";
                if (item.LifeSpanStart != null)
                {
                    ls_start = $"\'{item.LifeSpanStart}\'";
                }

                var ls_end = "null";
                if (item.LifeSpanEnd != null)
                {
                    ls_end = $"\'{item.LifeSpanEnd}\'";
                }

                var temp = string.Format("INSERT INTO Pcbs (PcbId, ManufacturerId, PcbName, PcbNotes, LifeSpanStart, LifeSpanEnd, PcbClass, Mapper, PrgRom, PrgRam, ChrRom, ChrRam, BatteryPresent, Mirroring, CIC) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14});",
                    $"\'{item.Id}\'",
                    manu_id,
                    (item.Name != null && item.Name.Contains("'") ? $"\'{item.Name.Replace("'", "''")}\'" : $"\'{item.Name}\'"),
                    (item.Notes!= null && item.Notes.Contains("'") ? $"\'{item.Notes.Replace("'", "''")}\'" : $"\'{item.Notes}\'"),
                    ls_start,
                    ls_end,
                    (item.Class != null && item.Class.Contains("'") ? $"\'{item.Class.Replace("'", "''")}\'" : $"\'{item.Class}\'"),
                    (item.Mapper != null && item.Mapper.Contains("'") ? $"\'{item.Mapper.Replace("'", "''")}\'" : $"\'{item.Mapper}\'"),
                    (item.PrgRom != null && item.PrgRom.Contains("'") ? $"\'{item.PrgRom.Replace("'", "''")}\'" : $"\'{item.PrgRom}\'"),
                    (item.PrgRam != null && item.PrgRam.Contains("'") ? $"\'{item.PrgRam.Replace("'", "''")}\'" : $"\'{item.PrgRam}\'"),
                    (item.ChrRom != null && item.ChrRom.Contains("'") ? $"\'{item.ChrRom.Replace("'", "''")}\'" : $"\'{item.ChrRom}\'"),
                    (item.ChrRam != null && item.ChrRam.Contains("'") ? $"\'{item.ChrRam.Replace("'", "''")}\'" : $"\'{item.ChrRam}\'"),
                    (int)item.BatteryPresent,
                    (int)item.Mirroring,
                    (item.CIC != null && item.CIC.Contains("'") ? $"\'{item.CIC.Replace("'", "''")}\'" : $"\'{item.CIC}\'"));

                statements.Add(temp);
            }

            return statements;
        }
    }
}
