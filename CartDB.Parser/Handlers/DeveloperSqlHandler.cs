using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class DeveloperSqlHandler
    {
        public static List<string> CreateSqlStatements(List<DeveloperDto> developers)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Developers](\n" +
                "\t[DeveloperId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[DeveloperName] NVARCHAR(MAX) NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Developers] PRIMARY KEY ([DeveloperId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in developers)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var temp = string.Format("INSERT INTO Developers (DeveloperId, DeveloperName) VALUES ({0}, {1});",
                        $"\'{item.Id}\'",
                        (item.Name.Contains("'") ? $"\'{item.Name.Replace("'", "''")}\'" : $"\'{item.Name}\'"));

                    statements.Add(temp);
                }
            }

            return statements;
        }
    }
}
