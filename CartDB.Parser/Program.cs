using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using CartDB.Database.Data;
using CartDB.Database.Models;
using CartDB.Parser.Mappers;
using CartDB.Parser.TransientModels;
using Newtonsoft.Json;

namespace CartDB.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch regionTimer = new Stopwatch();
            Stopwatch overallTimer = new Stopwatch();
            overallTimer.Start();

            #region Read JSON files
            regionTimer.Start();
            var pcbPath = Directory.GetCurrentDirectory() + @"\Resources\pcbs.json";
            var pcbContent = File.ReadAllText(pcbPath);
            var cartChipPath = Directory.GetCurrentDirectory() + @"\Resources\cartridgechips.json";
            var cartChipContent = File.ReadAllText(cartChipPath);
            var cartPath = Directory.GetCurrentDirectory() + @"\Resources\cartridges.json";
            var cartContent = File.ReadAllText(cartPath);
            var developerPath = Directory.GetCurrentDirectory() + @"\Resources\developers.json";
            var developerContent = File.ReadAllText(developerPath);
            var gamePath = Directory.GetCurrentDirectory() + @"\Resources\games.json";
            var gameContent = File.ReadAllText(gamePath);
            var producerPath = Directory.GetCurrentDirectory() + @"\Resources\producers.json";
            var producerContent = File.ReadAllText(producerPath);
            var publisherPath = Directory.GetCurrentDirectory() + @"\Resources\publishers.json";
            var publisherContent = File.ReadAllText(publisherPath);
            var regionPath = Directory.GetCurrentDirectory() + @"\Resources\regions.json";
            var regionContent = File.ReadAllText(regionPath);
            regionTimer.Stop();

            Console.WriteLine($"Reading JSON files complete - {regionTimer.Elapsed}");
            #endregion

            #region Deserialize all of the JSON files
            regionTimer.Reset();
            regionTimer.Start();

            // primary
            var transientDevelopers = JsonConvert.DeserializeObject<TransientDeveloperListModel>(developerContent);
            var transientProducers = JsonConvert.DeserializeObject<TransientProducerListModel>(producerContent);
            var transientPublishers = JsonConvert.DeserializeObject<TransientPublisherListModel>(publisherContent);
            var transientRegions = JsonConvert.DeserializeObject<TransientRegionsListModel>(regionContent);
            // secondary
            var transientCartridgeChips = JsonConvert.DeserializeObject<TransientCartridgeChipListModel>(cartChipContent);
            var transientGames = JsonConvert.DeserializeObject<TransientGameListModel>(gameContent);
            var transientPcbs = JsonConvert.DeserializeObject<TransientPcbListModel>(pcbContent); 
            var transientCartridges = JsonConvert.DeserializeObject<TransientCartridgeListModel>(cartContent);

            var msp_types = transientCartridges.Cartridges.Select(c => c.MfgStrPresent).Distinct().ToList();
            var ct_types = transientCartridges.Cartridges.Select(c => c.CICType).Distinct().ToList();

            // update ids
            for (var i = 0; i < transientPcbs.Pcbs.Count; i++)
            {
                var newId = Guid.NewGuid();
                while (transientPcbs.Pcbs.Where(i => i.CartridgeId == newId).Count() != 0)
                {
                    newId = Guid.NewGuid();
                }
                transientPcbs.Pcbs[i].Nid = newId;
            }

            for (var i = 0; i < transientCartridgeChips.CartridgeChips.Count; i++)
            {
                var newId = Guid.NewGuid();
                while (transientCartridgeChips.CartridgeChips.Where(i => i.CartridgeId == newId).Count() != 0)
                {
                    newId = Guid.NewGuid();
                }
                transientCartridgeChips.CartridgeChips[i].Nid = newId;
            }

            for (var i = 0; i < transientDevelopers.Developers.Count; i++)
            {
                var newCartId = Guid.NewGuid();
                while (transientCartridges.Cartridges.Where(i => i.Nid == newCartId).Count() != 0)
                {
                    newCartId = Guid.NewGuid();
                }
                transientCartridges.Cartridges[i].Nid = newCartId;

                var newDevId = Guid.NewGuid();
                while (transientDevelopers.Developers.Where(i => i.Nid == newDevId).Count() != 0)
                {
                    newDevId = Guid.NewGuid();
                }
                transientDevelopers.Developers[i].Nid = newDevId;

                var newProdId = Guid.NewGuid();
                while (transientProducers.Producers.Where(i => i.Nid == newProdId).Count() != 0)
                {
                    newProdId = Guid.NewGuid();
                }
                transientProducers.Producers[i].Nid = newProdId;

                var newPubId = Guid.NewGuid();
                while (transientPublishers.Publishers.Where(i => i.Nid == newPubId).Count() != 0)
                {
                    newPubId = Guid.NewGuid();
                }
                transientPublishers.Publishers[i].Nid = newPubId;

                var newRegId = Guid.NewGuid();
                while (transientRegions.Regions.Where(i => i.Nid == newRegId).Count() != 0)
                {
                    newRegId = Guid.NewGuid();
                }
                transientRegions.Regions[i].Nid = newRegId;

                var newGameId = Guid.NewGuid();
                while (transientGames.Games.Where(i => i.Nid == newGameId).Count() != 0)
                {
                    newGameId = Guid.NewGuid();
                }
                transientGames.Games[i].Nid = newGameId;

                transientDevelopers.Developers[i].CartridgeId = transientCartridges.Cartridges[i].Nid;
                transientProducers.Producers[i].CartridgeId = transientCartridges.Cartridges[i].Nid;
                transientPublishers.Publishers[i].CartridgeId = transientCartridges.Cartridges[i].Nid;
                transientRegions.Regions[i].CartridgeId = transientCartridges.Cartridges[i].Nid;
                transientGames.Games[i].CartridgeId = transientCartridges.Cartridges[i].Nid;

                transientGames.Games[i].Region = transientRegions.Regions[i].Name;
                transientGames.Games[i].Publisher = transientPublishers.Publishers[i].Name;
                transientGames.Games[i].Developer = transientDevelopers.Developers[i].Name;


                foreach (var cc in transientCartridgeChips.CartridgeChips)
                {
                    if (cc.CartId == transientCartridges.Cartridges[i].Id)
                    {
                        cc.CartridgeId = transientCartridges.Cartridges[i].Nid;
                    }
                }
            }

            regionTimer.Stop();

            Console.WriteLine($"Deserializing JSON files complete - {regionTimer.Elapsed}");
            #endregion

            #region Build primary DTOs
            regionTimer.Reset();
            regionTimer.Start();

            var developers = DeveloperMapper.MapData(transientDevelopers.Developers);
            var manufacturers = ProducerMapper.MapData(transientProducers.Producers, transientPcbs.Pcbs);
            var publishers = PublisherMapper.MapData(transientPublishers.Publishers);
            var regions = RegionMapper.MapData(transientRegions.Regions);
            var images = ImageMapper.MapData(transientPcbs.Pcbs, transientCartridges.Cartridges);

            regionTimer.Stop();

            Console.WriteLine($"Building of primary DTOs complete - {regionTimer.Elapsed}");
            #endregion

            #region Build secondary DTOs
            regionTimer.Reset();
            regionTimer.Start();

            var games = GameMapper.MapData(transientGames.Games, publishers, developers, regions);
            var pcbs = PcbMapper.MapData(transientPcbs.Pcbs, manufacturers, images);
            var cartridges = CartridgeMapper.MapData(transientCartridges.Cartridges, transientProducers.Producers, transientGames.Games, images);
            var cartridgeChips = CartridgeChipMapper.MapData(transientCartridgeChips.CartridgeChips, manufacturers);

            var imageCount = images.Select(i => i.ImageId).Count();
            var distinctImageCount = images.Select(i => i.ImageId).Distinct().Count();
            regionTimer.Stop();

            Console.WriteLine($"Building of secondary DTOs complete - {regionTimer.Elapsed}");
            #endregion

            #region Insert data into database
            regionTimer.Reset();
            regionTimer.Start();

            using NesicomContext context = new NesicomContext();

            context.AddRange(developers);
            context.SaveChanges();
            Console.WriteLine("Developer Inserts complete.");

            context.AddRange(manufacturers);
            context.SaveChanges();
            Console.WriteLine("Manufacturer Inserts complete.");

            context.AddRange(publishers);
            context.SaveChanges();
            Console.WriteLine("Publisher Inserts complete.");

            context.AddRange(regions);
            context.SaveChanges();
            Console.WriteLine("Region Inserts complete.");

            context.AddRange(pcbs);
            context.SaveChanges();
            Console.WriteLine("PCB Inserts complete.");

            context.AddRange(games);
            context.SaveChanges();
            Console.WriteLine("Game Inserts complete.");

            context.AddRange(cartridges);
            context.SaveChanges();
            Console.WriteLine("Cartridge Inserts complete.");

            context.AddRange(cartridgeChips);
            context.SaveChanges();
            Console.WriteLine("CartridgeChip Inserts complete.");

            regionTimer.Stop();

            Console.WriteLine($"Insertion of data into database complete - {regionTimer.Elapsed}");
            #endregion

            overallTimer.Stop();
            Console.WriteLine($"All operaions complete - {overallTimer.Elapsed}");
        }
    }
}
