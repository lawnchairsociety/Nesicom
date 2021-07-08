using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CartDB.Database.Data;
using CartDB.Parser.Mappers;
using CartDB.Parser.Models;
using Newtonsoft.Json;

namespace CartDB.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up database context
            using NesicomContext context = new NesicomContext();

            Stopwatch regionTimer = new Stopwatch();
            Stopwatch overallTimer = new Stopwatch();
            overallTimer.Start();

            #region Read JSON files
            regionTimer.Start();
            // cartridges
            var cartPath = Directory.GetCurrentDirectory() + @"\Resources\cartridges.json";
            var cartContent = File.ReadAllText(cartPath);
            // pcbs
            var pcbPath = Directory.GetCurrentDirectory() + @"\Resources\pcbs.json";
            var pcbContent = File.ReadAllText(pcbPath);

            regionTimer.Stop();

            Console.WriteLine($"Reading JSON files complete - {regionTimer.Elapsed}");
            #endregion

            #region Deserialize all of the JSON files
            regionTimer.Reset();
            regionTimer.Start();

            var jsonCartridges = JsonConvert.DeserializeObject<List<CartridgeModel>>(cartContent);
            var jsonPcbs = JsonConvert.DeserializeObject<PcbListModel>(pcbContent);

            // temp fix for Developer/Publisher/Region placement
            foreach (var jsonCartridge in jsonCartridges)
            {
                jsonCartridge.Game.Developer = jsonCartridge.Developer;
                jsonCartridge.Game.Publisher = jsonCartridge.Publisher;
                jsonCartridge.Game.Region = jsonCartridge.Region;
            }

            regionTimer.Stop();

            Console.WriteLine($"Deserializing JSON files complete - {regionTimer.Elapsed}");
            #endregion

            #region Build Database Objects
            regionTimer.Reset();
            regionTimer.Start();

            // pcb objects 
            var pcbs = jsonPcbs.Pcbs
                .GroupBy(o => o.PcbName)
                .Select(o => o.First(x => !string.IsNullOrWhiteSpace(x.PcbName)))
                .Select(o => PcbMapper.Map(o, context))
                .ToList();

            // cartridge objects
            var cartridges = jsonCartridges
                .GroupBy(o => o.Id)
                .Select (o => o.First())
                .Select(o => CartridgeMapper.Map(o, context))
                .ToList();

            regionTimer.Stop();

            Console.WriteLine($"Building of database objects complete - {regionTimer.Elapsed}");
            #endregion

            #region Insert objects to database
            regionTimer.Reset();
            regionTimer.Start();

            context.AddRange(pcbs);
            context.SaveChanges();

            context.AddRange(cartridges);
            context.SaveChanges();

            regionTimer.Stop();

            Console.WriteLine($"Database inserts complete - {regionTimer.Elapsed}");
            #endregion

            overallTimer.Stop();
            Console.WriteLine($"All operaions complete - {overallTimer.Elapsed}");
        }
    }
}
