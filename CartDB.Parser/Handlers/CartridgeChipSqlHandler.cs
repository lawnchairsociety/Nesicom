using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class CartridgeChipSqlHandler
    {
        public static List<string> CreateSqlStatements(List<CartridgeChipDto> cartridgeChips)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [CartridgeChips](\n" +
                "\t[CartridgeChipId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[PartNumber] NVARCHAR(MAX) NOT NULL,\n" +
                "\t[ManufacturerId] UNIQUEIDENTIFIER NULL,\n" +
                "\t[Designation] NVARCHAR(MAX) NULL,\n" +
                "\t[Type] NVARCHAR(MAX) NULL,\n" +
                "\t[Package] NVARCHAR(MAX) NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_CartridgeChips] PRIMARY KEY ([CartridgeChipId]),\n" +
                "\tCONSTRAINT [FK_CartridgeChips_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers]([ManufacturerId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in cartridgeChips)
            {
                var manu_id = "null";
                if (item.ManufacturerId != null)
                {
                    manu_id = $"\'{item.ManufacturerId}\'";
                }

                var temp = string.Format("INSERT INTO CartridgeChips (CartridgeChipId, PartNumber, ManufacturerId, Designation, Type, Package) VALUES ({0}, {1}, {2}, {3}, {4}, {5});",
                    $"\'{item.Id}\'",
                    (item.PartNumber != null && item.PartNumber.Contains("'") ? $"\'{item.PartNumber.Replace("'", "''")}\'" : $"\'{item.PartNumber}\'"),
                    manu_id,
                    (item.Designation != null && item.Designation.Contains("'") ? $"\'{item.Designation.Replace("'", "''")}\'" : $"\'{item.Designation}\'"),
                    (item.Type != null && item.Type.Contains("'") ? $"\'{item.Type.Replace("'", "''")}\'" : $"\'{item.Type}\'"),
                    (item.Package != null && item.Package.Contains("'") ? $"\'{item.Package.Replace("'", "''")}\'" : $"\'{item.Package}\'"));

                statements.Add(temp);
            }

            return statements;
        }
    }
}
