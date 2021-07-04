using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class ImageSqlHandler
    {
        public static List<string> CreateSqlStatements(List<ImageDto> images)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Images](\n" +
                "\t[ImageId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[Filename] NVARCHAR(MAX) NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Images] PRIMARY KEY ([ImageId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in images)
            {
                var temp = string.Format("INSERT INTO Images (ImageId, Filename) VALUES ({0}, {1});",
                    $"\'{item.Id}\'",
                    $"\'{item.Filename}\'");

                statements.Add(temp);
            }

            return statements;
        }
    }
}
