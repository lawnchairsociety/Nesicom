using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class PublisherSqlHandler
    {
        public static List<string> CreateSqlStatements(List<PublisherDto> publishers)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Publishers](\n" +
                "\t[PublisherId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[PublisherName] NVARCHAR(MAX) NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Publishers] PRIMARY KEY ([PublisherId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in publishers)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var temp = string.Format("INSERT INTO Publishers (PublisherId, PublisherName) VALUES ({0}, {1});",
                        $"\'{item.Id}\'",
                        (item.Name.Contains("'") ? $"\'{item.Name.Replace("'", "''")}\'" : $"\'{item.Name}\'"));

                    statements.Add(temp);
                }
            }

            return statements;
        }
    }
}
