using System;
using System.Collections.Generic;
using System.Linq;
using CartDB.Database.Models;
using CartDB.Parser.TransientModels;

namespace CartDB.Parser.Mappers
{
    public static class DeveloperMapper
    {
        // (DROP IF NAME EMPTY)
        public static List<Developer> MapData(List<TransientDeveloperModel> developers)
        {
            var result = new List<Developer>();

            foreach(var dev in developers)
            {
                if (!string.IsNullOrEmpty(dev.Name) && result.Where(d => d.DeveloperName == dev.Name).Count() == 0)
                {
                    result.Add(new Developer
                    {
                        DeveloperId = dev.Nid,
                        DeveloperName = dev.Name
                    });
                }
            }

            return result;
        }
    }
}
