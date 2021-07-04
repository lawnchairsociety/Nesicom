using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class RegionSqlHandler
    {
        public static List<string> CreateSqlStatements(List<RegionDto> regions)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Regions](\n" +
                "\t[RegionId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[RegionName] NVARCHAR(MAX) NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Regions] PRIMARY KEY ([RegionId])\n" +
                ")";
            
            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in regions)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var temp = string.Format("INSERT INTO Regions (RegionId, RegionName) VALUES ({0}, {1});",
                        $"\'{item.Id}\'",
                        (item.Name.Contains("'") ? $"\'{item.Name.Replace("'", "''")}\'" : $"\'{item.Name}\'"));

                    statements.Add(temp);
                }
            }

            return statements;
        }
    }
}
