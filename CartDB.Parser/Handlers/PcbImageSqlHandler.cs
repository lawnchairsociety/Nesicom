using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class PcbImageSqlHandler
    {
        public static List<string> CreateSqlStatements(List<PcbImageDto> pcbImages)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [PcbImages](\n" +
                "\t[PcbImageId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[PcbId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\t[ImageId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_PcbImages] PRIMARY KEY ([PcbImageId]),\n" +
                "\tCONSTRAINT [FK_PcbImages_PcbId] FOREIGN KEY ([PcbId]) REFERENCES [Pcbs]([PcbId]),\n" +
                "\tCONSTRAINT [FK_PcbImages_ImageId] FOREIGN KEY ([ImageId]) REFERENCES [Images]([ImageId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in pcbImages)
            {
                var temp = string.Format("INSERT INTO PcbImages (PcbImageId, PcbId, ImageId) VALUES ({0}, {1}, {2});",
                    $"\'{item.Id}\'",
                    $"\'{item.PcbId}\'",
                    $"\'{item.ImageId}\'");

                statements.Add(temp);
            }

            return statements;
        }
    }
}
