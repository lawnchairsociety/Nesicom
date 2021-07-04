using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class CartridgeImageSqlHandler
    {
        public static List<string> CreateSqlStatements(List<CartridgeImageDto> cartridgeImages)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [CartridgeImages](\n" +
                "\t[CartridgeImageId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[CartridgeId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\t[ImageId] UNIQUEIDENTIFIER NOT NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_CartridgeImages] PRIMARY KEY ([CartridgeImageId]),\n" +
                "\tCONSTRAINT [FK_CartridgeImages_CartridgeId] FOREIGN KEY ([CartridgeId]) REFERENCES [Cartridges]([CartridgeId]),\n" +
                "\tCONSTRAINT [FK_CartridgeImages_ImageId] FOREIGN KEY ([ImageId]) REFERENCES [Images]([ImageId])\n" +
                ")";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in cartridgeImages)
            {
                var temp = string.Format("INSERT INTO CartridgeImages (CartridgeImageId, CartridgeId, ImageId) VALUES ({0}, {1}, {2});",
                    $"\'{item.Id}\'",
                    $"\'{item.CartridgeId}\'",
                    $"\'{item.ImageId}\'");

                statements.Add(temp);
            }

            return statements;
        }
    }
}
