using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class ManufacturerSqlHandler
    {
        public static List<string> CreateSqlStatements(List<ManufacturerDto> manufacturers)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Manufacturers](\n" +
                "\t[ManufacturerId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[ManufacturerName] NVARCHAR(MAX) NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Manufacturers] PRIMARY KEY ([ManufacturerId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in manufacturers)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var temp = string.Format("INSERT INTO Manufacturers (ManufacturerId, ManufacturerName) VALUES ({0}, {1});",
                        $"\'{item.Id}\'",
                        (item.Name.Contains("'") ? $"\'{item.Name.Replace("'", "''")}\'" : $"\'{item.Name}\'"));

                    statements.Add(temp);
                }
            }

            return statements;
        }
    }
}
