using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class ManufacturerImageSqlHandler
    {
        public static List<string> CreateSqlStatements(List<ManufacturerImageDto> manufacturerImages)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [ManufacturerImages](\n" +
                "\t[ManufacturerImageId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[ManufacturerId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\t[ImageId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_ManufacturerImages] PRIMARY KEY ([ManufacturerImageId]),\n" +
                "\tCONSTRAINT [FK_ManufacturerImages_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers]([ManufacturerId]),\n" +
                "\tCONSTRAINT [FK_ManufacturerImages_ImageId] FOREIGN KEY ([ImageId]) REFERENCES [Images]([ImageId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in manufacturerImages)
            {
                var temp = string.Format("INSERT INTO ManufacturerImages (ManufacturerImageId, ManufacturerId, ImageId) VALUES ({0}, {1}, {2});",
                    $"\'{item.Id}\'",
                    $"\'{item.ManufacturerId}\'",
                    $"\'{item.ImageId}\'");

                statements.Add(temp);
            }

            return statements;
        }
    }
}
