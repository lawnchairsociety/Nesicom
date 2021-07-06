using System;
using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public static class PublisherMapper
    {
        public static List<Publisher> MapData(List<TransientPublisherModel> publishers)
        {
            var result = new List<Publisher>();

            foreach (var pub in publishers)
            {
                if (!string.IsNullOrEmpty(pub.Name) && result.Where(p => p.PublisherName == pub.Name).Count() == 0)
                {
                    result.Add(new Publisher
                    {
                        PublisherId = pub.Nid,
                        PublisherName = pub.Name
                    });
                }
            }

            return result;
        }
    }
}
