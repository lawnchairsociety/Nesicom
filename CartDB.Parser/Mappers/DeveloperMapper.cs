using System.Linq;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Models;

namespace CartDB.Parser.Mappers
{
    public static class DeveloperMapper
    {
        public static Developer Map(DeveloperModel model, NesicomContext context)
        {
            var developer = context.Developers.FirstOrDefault(o => o.DeveloperName == model.Name);
            if (developer == null)
            {
                developer = new Developer
                {
                    DeveloperName = model.Name
                };
            }



            return developer;
        }
    }
}
