using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class OtherChipSqlHandler
    {
        public static List<string> CreateSqlStatements(List<OtherChipDto> otherChips)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [OtherChips](\n" +
                "\t[OtherChipId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[OtherChipName] NVARCHAR(MAX) NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_OtherChips] PRIMARY KEY ([OtherChipId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in otherChips)
            {
                if(!string.IsNullOrEmpty(item.Name))
                {
                    var temp = string.Format("INSERT INTO OtherChips (OtherChipId, OtherChipName) VALUES ({0}, {1});",
                        $"\'{item.Id}\'",
                        (item.Name.Contains("'") ? $"\'{item.Name.Replace("'", "''")}\'" : $"\'{item.Name}\'"));

                    statements.Add(temp);
                }
            }

            return statements;
        }
    }
}
