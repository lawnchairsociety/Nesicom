using System.Collections.Generic;
using CartDB.Parser.Models.Dtos;

namespace CartDB.Parser.Handlers
{
    public static class GameSqlHandler
    {
        public static List<string> CreateSqlStatements(List<GameDto> games)
        {
            List<string> statements = new List<string>();

            var createStatement = "CREATE TABLE [Games](\n" +
                "\t[GameId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),\n" +
                "\t[GameName] NVARCHAR(MAX) NOT NULL,\n" +
                "\t[Class] NVARCHAR(MAX) NOT NULL,\n" +
                "\t[CatalogEntry] NVARCHAR(MAX) NULL,\n" +
                "\t[PublisherId] UNIQUEIDENTIFIER NULL,\n" +
                "\t[DeveloperId] UNIQUEIDENTIFIER NULL,\n" +
                "\t[RegionId] UNIQUEIDENTIFIER NULL,\n" +
                "\t[Players] INT NULL,\n" +
                "\t[ReleaseDate] DATETIME NULL,\n" +
                "\n" +
                "\tCONSTRAINT [PK_Games] PRIMARY KEY ([GameId]),\n" +
                "\tCONSTRAINT [FK_Games_PublisherId] FOREIGN KEY ([PublisherId]) REFERENCES [Publishers]([PublisherId]),\n" +
                "\tCONSTRAINT [FK_Games_DeveloperId] FOREIGN KEY ([DeveloperId]) REFERENCES [Developers]([DeveloperId]),\n" +
                "\tCONSTRAINT [FK_Games_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions]([RegionId])\n" +
                ")\n" +
                "";

            statements.Add(createStatement);
            statements.Add("");

            foreach (var item in games)
            {
                var pub_id = "null";
                var dev_id = "null";
                var reg_id = "null";
                var players = "null";
                var rel_date = "null";

                if (item.PublisherId != null)
                {
                    pub_id = $"\'{item.PublisherId}\'";
                }

                if(item.DeveloperId != null)
                {
                    dev_id = $"\'{item.DeveloperId}\'";
                }

                if (item.RegionId != null)
                {
                    reg_id = $"\'{item.RegionId}\'";
                }

                if (item.Players != null)
                {
                    players = item.Players.ToString();
                }

                if (item.ReleaseDate != null)
                {
                    rel_date = $"\'{item.ReleaseDate}\'";
                }

                var temp = string.Format("INSERT INTO Games (GameId, GameName, Class, CatalogEntry, PublisherId, DeveloperId, RegionId, Players, ReleaseDate) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8});",
                    $"\'{item.Id}\'",
                    (item.Name != null && item.Name.Contains("'") ? $"\'{item.Name.Replace("'", "''")}\'" : $"\'{item.Name}\'"),
                    (item.Class != null && item.Class.Contains("'") ? $"\'{item.Class.Replace("'", "''")}\'" : $"\'{item.Class}\'"),
                    (item.CatalogEntry != null && item.CatalogEntry.Contains("'") ? $"\'{item.CatalogEntry.Replace("'", "''")}\'" : $"\'{item.CatalogEntry}\'"),
                    pub_id,
                    dev_id,
                    reg_id,
                    players,
                    rel_date);

                statements.Add(temp);
            }

            return statements;
        }
    }
}
