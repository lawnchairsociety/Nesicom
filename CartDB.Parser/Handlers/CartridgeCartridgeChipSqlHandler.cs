using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class CartridgeCartridgeChipSqlHandler
    {
        public static List<string> CreateSqlStatements(List<CartridgeCartridgeChipDto> cartridgeCartridgeChips)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [CartridgeCartridgeChips](\n" +
                "\t[CartridgeCartridgeChipId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[CartridgeId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\t[CartridgeChipId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_CartridgeCartridgeChips] PRIMARY KEY ([CartridgeCartridgeChipId]),\n" +
                "\tCONSTRAINT [FK_CartridgeCartridgeChips_CartridgeId] FOREIGN KEY ([CartridgeId]) REFERENCES [Cartridges]([CartridgeId]),\n" +
                "\tCONSTRAINT [FK_CartridgeCartridgeChips_CartridgeChipId] FOREIGN KEY ([CartridgeChipId]) REFERENCES [CartridgeChips]([CartridgeChipId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in cartridgeCartridgeChips)
            {
                var temp = string.Format("INSERT INTO CartridgeCartridgeChips (CartridgeCartridgeChipId, CartridgeId, CartridgeChipId)  VALUES ({0}, {1}, {2});",
                    $"\'{item.Id}\'",
                    $"\'{item.CartridgeId}\'",
                    $"\'{item.CartridgeChipId}\'");

                statements.Add(temp);
            }

            return statements;
        }
    }
}
