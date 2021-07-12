using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class PublisherMapper
    {
        public static Publisher Map(PublisherModel model, NesicomSqlServerContext context)
        {
            var publisher = context.Publishers.FirstOrDefault(o => o.PublisherName == model.Name);
            if (publisher == null)
            {
                publisher = new Publisher
                {
                    PublisherName = model.Name
                };
            }

            return publisher;


            
        }
    }
}
