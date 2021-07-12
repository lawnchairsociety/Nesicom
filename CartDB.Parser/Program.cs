using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            using NesicomSqlServerContext context = new NesicomSqlServerContext();

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
            var jsonPcbs = JsonConvert.DeserializeObject<List<PcbModel>>(pcbContent);

            regionTimer.Stop();

            Console.WriteLine($"Deserializing JSON files complete - {regionTimer.Elapsed}");
            #endregion

            #region Build Database Objects
            regionTimer.Reset();
            regionTimer.Start();

            // pcb objects
            foreach(var jPcb in jsonPcbs)
            {
                if(string.IsNullOrWhiteSpace(jPcb.PcbName))
                {
                    continue;
                }

                var pcb = PcbMapper.Map(jPcb, context);
                context.Add(pcb);
                context.SaveChanges();
            }

            // cartridge objects
            foreach(var jCart in jsonCartridges)
            {
                var cartridge = CartridgeMapper.Map(jCart, context);
                context.Add(cartridge);
                context.SaveChanges();
            }

            regionTimer.Stop();

            Console.WriteLine($"Building of database objects complete - {regionTimer.Elapsed}");
            #endregion

            overallTimer.Stop();
            Console.WriteLine($"All operaions complete - {overallTimer.Elapsed}");
        }
    }
}
