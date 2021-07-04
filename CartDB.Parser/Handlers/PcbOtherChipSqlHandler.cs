using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class PcbOtherChipSqlHandler
    {
        public static List<string> CreateSqlStatements(List<PcbOtherChipDto> pcbOtherChips)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [PcbOtherChips](\n" +
                "\t[PcbOtherChipId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[PcbId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\t[OtherChipId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_PcbOtherChips] PRIMARY KEY ([PcbOtherChipId]),\n" +
                "\tCONSTRAINT [FK_PcbOtherChips_PcbId] FOREIGN KEY ([PcbId]) REFERENCES [Pcbs]([PcbId]),\n" +
                "\tCONSTRAINT [FK_PcbOtherChips_OtherChipId] FOREIGN KEY ([OtherChipId]) REFERENCES [OtherChips]([OtherChipId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in pcbOtherChips)
            {
                var temp = string.Format("INSERT INTO PcbOtherChips (PcbOtherChipId, PcbId, OtherChipId) VALUES ({0}, {1}, {2});",
                    $"\'{item.Id}\'",
                    $"\'{item.PcbId}\'",
                    $"\'{item.OtherChipId}\'");

                statements.Add(temp);
            }

            return statements;
        }
    }
}
