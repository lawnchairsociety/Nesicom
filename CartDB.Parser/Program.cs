using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using CartDB.Parser.Handlers;
using CartDB.Parser.Models;
using CartDB.Parser.Models.Dtos;
using Newtonsoft.Json;

namespace CartDB.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var downloadFiles = false;
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
            PCBListModel pcbList = JsonConvert.DeserializeObject<PCBListModel>(pcbContent);
            CartridgeChipListModel cartChipList = JsonConvert.DeserializeObject<CartridgeChipListModel>(cartChipContent);
            CartridgeListModel cartList = JsonConvert.DeserializeObject<CartridgeListModel>(cartContent);
            DeveloperListModel developerList = JsonConvert.DeserializeObject<DeveloperListModel>(developerContent);
            GameListModel gameList = JsonConvert.DeserializeObject<GameListModel>(gameContent);
            ProducerListModel producerList = JsonConvert.DeserializeObject<ProducerListModel>(producerContent);
            PublisherListModel publisherList = JsonConvert.DeserializeObject<PublisherListModel>(publisherContent);
            RegionListModel regionList = JsonConvert.DeserializeObject<RegionListModel>(regionContent);
            regionTimer.Stop();

            Console.WriteLine($"Deserializing JSON files complete - {regionTimer.Elapsed}");
            #endregion

            #region Build primary DTOs
            regionTimer.Reset();
            regionTimer.Start();
            // DeveloperDto
            List<DeveloperDto> developers = new List<DeveloperDto>();
            foreach (var item in developerList.Developers)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    var temp = developers.FirstOrDefault(o => o.Name == item.Name);
                    if (temp == null)
                    {
                        developers.Add(new DeveloperDto { Name = item.Name, Id = Guid.NewGuid() });
                    }
                }
            }

            // ImageDto
            List<ImageDto> images = new List<ImageDto>();
            foreach (var pcb in pcbList.PCBs)
            {
                var mfg = images.FirstOrDefault(o => o.Filename == pcb.ManufacturerLogo);
                if (mfg == null)
                {
                    if (!string.IsNullOrEmpty(pcb.ManufacturerLogo))
                    {
                        images.Add(new ImageDto { Filename = pcb.ManufacturerLogo, Id = Guid.NewGuid() });
                    }
                }

                foreach (var item in pcb.PCBImages)
                {
                    var temp = images.FirstOrDefault(o => o.Filename == item);
                    if (temp == null)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            images.Add(new ImageDto { Filename = item, Id = Guid.NewGuid() });
                        }
                    }
                }
            }

            foreach (var cart in cartList.Cartridges)
            {
                foreach (var item in cart.Images)
                {
                    var temp = images.FirstOrDefault(o => o.Filename == item);
                    if (temp == null)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            images.Add(new ImageDto { Filename = item, Id = Guid.NewGuid() });
                        }
                    }
                }
            }

            foreach (var chip in cartChipList.CartridgeChips)
            {
                var temp = images.FirstOrDefault(o => o.Filename == chip.ManufacturerLogo);
                if (temp == null)
                {
                    if (!string.IsNullOrEmpty(chip.ManufacturerLogo))
                    {
                        images.Add(new ImageDto { Filename = chip.ManufacturerLogo, Id = Guid.NewGuid() });
                    }
                }
            }

            // ManufacturerDto
            List<ManufacturerDto> manufacturers = new List<ManufacturerDto>();
            foreach (var pcb in pcbList.PCBs)
            {
                if (!string.IsNullOrEmpty(pcb.Manufacturer))
                {
                    var temp = manufacturers.FirstOrDefault(o => o.Name == pcb.Manufacturer);
                    if (temp == null)
                    {
                        manufacturers.Add(new ManufacturerDto { Name = pcb.Manufacturer, Id = Guid.NewGuid() });
                    }
                }
            }

            foreach (var prod in producerList.Producers)
            {
                if (!string.IsNullOrEmpty(prod.Name))
                {
                    var temp = manufacturers.FirstOrDefault(o => o.Name == prod.Name);
                    if (temp == null)
                    {
                        manufacturers.Add(new ManufacturerDto { Name = prod.Name, Id = Guid.NewGuid() });
                    }
                }
            }

            foreach (var cc in cartChipList.CartridgeChips)
            {
                if (!string.IsNullOrEmpty(cc.ManufacturerName))
                {
                    var temp = manufacturers.FirstOrDefault(o => o.Name == cc.ManufacturerName);
                    if (temp == null)
                    {
                        manufacturers.Add(new ManufacturerDto { Name = cc.ManufacturerName, Id = Guid.NewGuid() });
                    }
                }
            }

            // PublisherDto
            List<PublisherDto> publishers = new List<PublisherDto>();
            foreach (var pub in publisherList.Publishers)
            {
                if(!string.IsNullOrEmpty(pub.Name))
                {
                    var temp = publishers.FirstOrDefault(o => o.Name == pub.Name);
                    if (temp == null)
                    {
                        publishers.Add(new PublisherDto { Name = pub.Name, Id = Guid.NewGuid() });
                    }
                }
            }

            // RegionDto
            List<RegionDto> regions = new List<RegionDto>();
            foreach (var reg in regionList.Regions)
            {
                if (!string.IsNullOrEmpty(reg.Name))
                {
                    var temp = regions.FirstOrDefault(o => o.Name == reg.Name);
                    if (temp == null)
                    {
                        regions.Add(new RegionDto { Name = reg.Name, Id = Guid.NewGuid() });
                    }
                }
            }

            // OtherChipDto
            List<OtherChipDto> otherChips = new List<OtherChipDto>();
            foreach (var pcb in pcbList.PCBs)
            {
                foreach (var item in pcb.OtherChips)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var temp = otherChips.FirstOrDefault(o => o.Name == item);
                        if (temp == null)
                        {
                            otherChips.Add(new OtherChipDto { Name = item, Id = Guid.NewGuid() });
                        }
                    }
                }
            }
            regionTimer.Stop();

            Console.WriteLine($"Building of primary DTOs complete - {regionTimer.Elapsed}");
            #endregion

            #region Build secondary DTOs
            regionTimer.Reset();
            regionTimer.Start();
            // CartridgeChipDto
            List<CartridgeChipDto> cartridgeChips = new List<CartridgeChipDto>();
            foreach (var cc in cartChipList.CartridgeChips)
            {
                if (!string.IsNullOrEmpty(cc.PartNumber))
                {
                    var temp = new CartridgeChipDto
                    {
                        Id = Guid.NewGuid(),
                        PartNumber = cc.PartNumber,
                        Designation = cc.Designation,
                        Type = cc.Type,
                        Package = cc.Package
                    };

                    if (!string.IsNullOrEmpty(cc.ManufacturerName))
                    {
                        temp.ManufacturerId = manufacturers.Find(o => o.Name == cc.ManufacturerName).Id;
                    }
                    else
                    {
                        temp.ManufacturerId = null;
                    }

                    cartridgeChips.Add(temp);
                }
            }

            // GameDto
            List<GameDto> games = new List<GameDto>();
            var gCounter = 0;
            foreach (var g in gameList.Games)
            {
                var pub_name = publisherList.Publishers.Find(o => o.Id == g.Id).Name;
                var dev_name = developerList.Developers.Find(o => o.Id == g.Id).Name;
                var playerParsed = Int32.TryParse(g.Players, out var players);
                var releaseParsed = DateTime.TryParse(g.ReleaseDate, out var releaseDate);

                var temp = new GameDto
                {
                    Id = Guid.NewGuid(),
                    Name = g.Name,
                    Class = g.CartClass,
                    CatalogEntry = g.CatalogEntry,
                    RegionId = regions.Find(o => o.Name == regionList.Regions[gCounter].Name).Id
                };

                if (!string.IsNullOrEmpty(pub_name))
                {
                    temp.PublisherId = publishers.Find(o => o.Name == pub_name).Id;
                }

                if (!string.IsNullOrEmpty(dev_name))
                {
                    temp.DeveloperId = developers.Find(o => o.Name == dev_name).Id;
                }

                if (playerParsed)
                {
                    temp.Players = players;
                }

                if (releaseParsed)
                {
                    temp.ReleaseDate = releaseDate;
                }

                games.Add(temp);
            }
            
            // PcbDto
            List<PcbDto> pcbs = new List<PcbDto>();
            foreach (var p in pcbList.PCBs)
            {
                var temp = new PcbDto
                {
                    Id = Guid.NewGuid(),
                    Name = p.PCBName,
                    Notes = p.PCBNotes,
                    Class = p.PCBClass,
                    Mapper = p.Mapper,
                    PrgRom = p.PrgRom,
                    PrgRam = p.PrgRam,
                    ChrRom = p.ChrRom,
                    ChrRam = p.ChrRam,
                    CIC = p.CIC
                };

                if (!string.IsNullOrEmpty(p.Manufacturer))
                {
                    temp.ManufacturerId = manufacturers.Find(o => o.Name == p.Manufacturer).Id;
                }
                else
                {
                    temp.ManufacturerId = null;
                }

                switch (p.BatteryPresent)
                {
                    case "Battery is not available":
                        temp.BatteryPresent = BatteryPresentType.NotAvailable;
                        break;
                    case "Battery is optional":
                        temp.BatteryPresent = BatteryPresentType.Optional;
                        break;
                    case "Battery is present":
                        temp.BatteryPresent = BatteryPresentType.Present;
                        break;
                    default:
                        temp.BatteryPresent = BatteryPresentType.Unknown;
                        break;
                }

                switch (p.Mirroring)
                {
                    case "Uses vertical mirroring":
                        temp.Mirroring = MirroringType.Vertical;
                        break;
                    case "Uses mapper controlled mirroring":
                        temp.Mirroring = MirroringType.MapperControlled;
                        break;
                    case "Uses horizontal or vertical mirroring":
                        temp.Mirroring = MirroringType.HorizontalVertical;
                        break;
                    case "Uses horizontal mirroring":
                        temp.Mirroring = MirroringType.Horizontal;
                        break;
                    case "Uses four screen mirroring":
                        temp.Mirroring = MirroringType.FourScreen;
                        break;
                    case "Uses one screen mirroring":
                        temp.Mirroring = MirroringType.OneScreen;
                        break;
                    default:
                        temp.Mirroring = MirroringType.Unknown;
                        break;
                }

                if (!string.IsNullOrEmpty(p.LifeSpan.Trim()))
                {
                    var span = p.LifeSpan.Split(" - ");
                    temp.LifeSpanStart = DateTime.Parse(span[0]);
                    if (span.Length == 2)
                    {
                        temp.LifeSpanEnd = DateTime.Parse(span[1]);
                    }
                }

                //if (p.PCBImages.Count > 0)
                //{
                //    temp.ImageId = images.Find(o => o.Filename == p.PCBImages[0]).Id;
                //}

                pcbs.Add(temp);
            }

            // CartridgeDto
            List<CartridgeDto> cartridges = new List<CartridgeDto>();
            var cCounter = 0;
            foreach (var c in cartList.Cartridges)
            {
                var manu_name = producerList.Producers.Find(o => o.Id == c.Id).Name;

                var temp = new CartridgeDto
                {
                    Id = Guid.NewGuid(),
                    GameId = games[cCounter].Id,
                    Color = c.Color,
                    FormFactor = c.FormFactor,
                    EmbossedText = c.EmbossedText,
                    FrontLabelEntry = c.FrontLabelEntry,
                    SealOfQuality = c.SealOfQuality,
                    BackLabelEntry = c.BackLabelEntry,
                    TwoDigitCode = c.TwoDigitCode,
                    Revision = c.Revision,
                    PcbId = pcbs.Find(o => o.Name == c.Pcb).Id,
                    CICType = c.CICType,
                    Hardware = c.Hardware,
                    WRAM = c.WRAM,
                    VRAM = c.VRAM
                };

                if (!string.IsNullOrEmpty(manu_name))
                {
                    temp.ManufacturerId = manufacturers.Find(o => o.Name == manu_name).Id;
                }
                else
                {
                    temp.ManufacturerId = null;
                }

                if (!string.IsNullOrEmpty(c.MfgStrPresent))
                {
                    if (c.MfgStrPresent == "Yes")
                    {
                        temp.MfgStringPresent = true;
                    }
                }

                cartridges.Add(temp);
                cCounter++;
            }
            regionTimer.Stop();

            Console.WriteLine($"Building of secondary DTOs complete - {regionTimer.Elapsed}");
            #endregion

            #region Build tertiary DTOs
            regionTimer.Reset();
            regionTimer.Start();
            // CartridgeCartridgeChipDto
            List<CartridgeCartridgeChipDto> cartridgeCartridgeChips = new List<CartridgeCartridgeChipDto>();
            var cccCounter = 0;
            foreach (var ccc in cartChipList.CartridgeChips)
            {
                var cartIndex = cartList.Cartridges.IndexOf(cartList.Cartridges.Find(o => o.Id == ccc.CartId));
                var temp = new CartridgeCartridgeChipDto
                {
                    Id = Guid.NewGuid(),
                    CartridgeId = cartridges[cartIndex].Id,
                    CartridgeChipId = cartridgeChips[cccCounter].Id
                };

                cartridgeCartridgeChips.Add(temp);
                cccCounter++;
            }

            // CartridgeImageDto
            List<CartridgeImageDto> cartridgeImages = new List<CartridgeImageDto>();
            var ciCounter = 0;
            foreach (var cart in cartList.Cartridges)
            {
                foreach (var item in cart.Images)
                {
                    if (images.Find(o => o.Filename == item) != null)
                    {
                        var temp = new CartridgeImageDto
                        {
                            Id = Guid.NewGuid(),
                            CartridgeId = cartridges[ciCounter].Id,
                            ImageId = images.Find(o => o.Filename == item).Id
                        };

                        cartridgeImages.Add(temp);
                    }
                }

                ciCounter++;
            }

            // ManufacturerImageDto
            List<ManufacturerImageDto> manufacturerImages = new List<ManufacturerImageDto>();
            foreach (var item in pcbList.PCBs)
            {
                if(!string.IsNullOrEmpty(item.Manufacturer))
                {
                    if (images.Find(o => o.Filename == item.ManufacturerLogo) != null)
                    {
                        var temp = new ManufacturerImageDto
                        {
                            Id = Guid.NewGuid(),
                            ManufacturerId = manufacturers.Find(o => o.Name == item.Manufacturer).Id,
                            ImageId = images.Find(o => o.Filename == item.ManufacturerLogo).Id
                        };

                        manufacturerImages.Add(temp);
                    }
                }
            }

            foreach (var item in cartChipList.CartridgeChips)
            {
                if (!string.IsNullOrEmpty(item.ManufacturerName))
                {
                    if (images.Find(o => o.Filename == item.ManufacturerLogo) != null)
                    {
                        var temp = new ManufacturerImageDto
                        {
                            Id = Guid.NewGuid(),
                            ManufacturerId = manufacturers.Find(o => o.Name == item.ManufacturerName).Id,
                            ImageId = images.Find(o => o.Filename == item.ManufacturerLogo).Id
                        };

                        manufacturerImages.Add(temp);
                    }
                }
            }

            // PcbImageDto
            List<PcbImageDto> pcbImages = new List<PcbImageDto>();
            var pCounter = 0;
            foreach (var p in pcbList.PCBs)
            {
                foreach (var item in p.PCBImages)
                {
                    if (images.Find(o => o.Filename == item) != null)
                    {
                        var temp = new PcbImageDto
                        {
                            Id = Guid.NewGuid(),
                            PcbId = pcbs[pCounter].Id,
                            ImageId = images.Find(o => o.Filename == item).Id
                        };

                        pcbImages.Add(temp);
                    }
                }

                pCounter++;
            }

            //PcbOtherChipDto
            List<PcbOtherChipDto> pcbOtherChips = new List<PcbOtherChipDto>();
            var poCounter = 0;
            foreach (var p in pcbList.PCBs)
            {
                foreach (var item in p.OtherChips)
                {
                    var temp = new PcbOtherChipDto
                    {
                        Id = Guid.NewGuid(),
                        PcbId = pcbs[poCounter].Id,
                        OtherChipId = otherChips.Find(o => o.Name == item).Id
                    };

                    pcbOtherChips.Add(temp);
                }

                poCounter++;
            }
            regionTimer.Stop();

            Console.WriteLine($"Building of tertiary DTOs complete - {regionTimer.Elapsed}");
            #endregion

            #region Download Images
            regionTimer.Reset();
            regionTimer.Start();
            if (downloadFiles)
            {
                Dictionary<Guid, string> errors = new Dictionary<Guid, string>();
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Resources\images\");

                for (var i = 0; i < images.Count; i++)
                {
                    // download all the files
                    using (WebClient client = new WebClient())
                    {
                        var imgPath = Directory.GetCurrentDirectory() + @"\Resources\images\" + images[i].Id + ".png";
                        try
                        {
                            client.DownloadFile(new Uri(images[i].Filename), imgPath);

                            images[i].Filename = images[i].Id + ".png";
                        }
                        catch (Exception e)
                        {
                            errors[images[i].Id] = images[i].Filename;
                            Console.WriteLine($"\tError downloading {0}", images[i].Filename);
                            Console.WriteLine("\t\t" + e.Message);
                        }
                    }
                }

                if (errors.Count > 0)
                {
                    var errorFile = Directory.GetCurrentDirectory() + @"\Resources\errors.txt";
                    using (StreamWriter file = new StreamWriter(errorFile))
                    {
                        foreach(var error in errors)
                        {
                            file.WriteLine("{0} >> {1}", error.Key, error.Value);
                        }
                    }
                }
            }
            regionTimer.Stop();

            Console.WriteLine($"Downloading of images complete - {regionTimer.Elapsed}");
            #endregion

            #region Create SQL Statements
            regionTimer.Reset();
            regionTimer.Start();
            // Developers Table
            var devSql = DeveloperSqlHandler.CreateSqlStatements(developers);
            
            // Images Table
            var imgSql = ImageSqlHandler.CreateSqlStatements(images);
            
            // Manufacturers Table
            var manuSql = ManufacturerSqlHandler.CreateSqlStatements(manufacturers);
            
            // Publishers Table
            var pubSql = PublisherSqlHandler.CreateSqlStatements(publishers);
            
            // Regions Table
            var regSql = RegionSqlHandler.CreateSqlStatements(regions);
            
            // CartridgeChips Table
            var cartChipSql = CartridgeChipSqlHandler.CreateSqlStatements(cartridgeChips);
            
            // Games Table
            var gameSql = GameSqlHandler.CreateSqlStatements(games);
            
            // PCBs Table
            var pcbSql = PcbSqlHandler.CreateSqlStatements(pcbs);
            
            // Cartridges Table
            var cartSql = CartridgeSqlHandler.CreateSqlStatements(cartridges);
            
            // CartridgeCartridgeChips Table
            var cartCartChipSql = CartridgeCartridgeChipSqlHandler.CreateSqlStatements(cartridgeCartridgeChips);
            
            // CartridgeImages Table
            var cartImgSql = CartridgeImageSqlHandler.CreateSqlStatements(cartridgeImages);
            
            // ManufacturerImages Table
            var manuImgSql = ManufacturerImageSqlHandler.CreateSqlStatements(manufacturerImages);
            
            // PcbImages Table
            var pcbImgSql = PcbImageSqlHandler.CreateSqlStatements(pcbImages);
            
            // OtherChips Table
            var otherChipSql = OtherChipSqlHandler.CreateSqlStatements(otherChips);
            
            // PcbOtherChips Table
            var pcbOtherChipSql = PcbOtherChipSqlHandler.CreateSqlStatements(pcbOtherChips);
            regionTimer.Stop();

            Console.WriteLine($"Creating SQL statements complete - {regionTimer.Elapsed}");
            #endregion

            #region Write SQL Files
            regionTimer.Reset();
            regionTimer.Start();
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Resources\SQL\");

            var devSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\01-Developers.sql";
            using(TextWriter tw = new StreamWriter(devSqlPath))
            {
                foreach(string s in devSql)
                {
                    tw.WriteLine(s);
                }
            }
            
            var imgSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\02-Images.sql";
            using (TextWriter tw = new StreamWriter(imgSqlPath))
            {
                foreach (string s in imgSql)
                {
                    tw.WriteLine(s);
                }
            }
            
            var manuSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\03-Manufacturers.sql";
            using (TextWriter tw = new StreamWriter(manuSqlPath))
            {
                foreach (string s in manuSql)
                {
                    tw.WriteLine(s);
                }
            }

            var pubSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\04-Publishers.sql";
            using (TextWriter tw = new StreamWriter(pubSqlPath))
            {
                foreach (string s in pubSql)
                {
                    tw.WriteLine(s);
                }
            }

            var regSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\05-Regions.sql";
            using (TextWriter tw = new StreamWriter(regSqlPath))
            {
                foreach (string s in regSql)
                {
                    tw.WriteLine(s);
                }
            }

            var otherChipSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\06-OtherChips.sql";
            using (TextWriter tw = new StreamWriter(otherChipSqlPath))
            {
                foreach (string s in otherChipSql)
                {
                    tw.WriteLine(s);
                }
            }

            var cartChipSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\07-CartridgeChips.sql";
            using (TextWriter tw = new StreamWriter(cartChipSqlPath))
            {
                foreach (string s in cartChipSql)
                {
                    tw.WriteLine(s);
                }
            }

            var gameSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\08-Games.sql";
            using (TextWriter tw = new StreamWriter(gameSqlPath))
            {
                foreach (string s in gameSql)
                {
                    tw.WriteLine(s);
                }
            }

            var pcbSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\09-Pcbs.sql";
            using (TextWriter tw = new StreamWriter(pcbSqlPath))
            {
                foreach (string s in pcbSql)
                {
                    tw.WriteLine(s);
                }
            }

            var cartSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\10-Cartridges.sql";
            using (TextWriter tw = new StreamWriter(cartSqlPath))
            {
                foreach (string s in cartSql)
                {
                    tw.WriteLine(s);
                }
            }

            var cartCartChipSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\11-CartridgeCartridgeChips.sql";
            using (TextWriter tw = new StreamWriter(cartCartChipSqlPath))
            {
                foreach (string s in cartCartChipSql)
                {
                    tw.WriteLine(s);
                }
            }

            var cartImgSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\12-CartridgeImages.sql";
            using (TextWriter tw = new StreamWriter(cartImgSqlPath))
            {
                foreach (string s in cartImgSql)
                {
                    tw.WriteLine(s);
                }
            }

            var manuImgSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\13-ManufacturerImages.sql";
            using (TextWriter tw = new StreamWriter(manuImgSqlPath))
            {
                foreach (string s in manuImgSql)
                {
                    tw.WriteLine(s);
                }
            }

            var pcbImgSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\14-PcbImages.sql";
            using (TextWriter tw = new StreamWriter(pcbImgSqlPath))
            {
                foreach (string s in pcbImgSql)
                {
                    tw.WriteLine(s);
                }
            }

            var pcbOtherChipSqlPath = Directory.GetCurrentDirectory() + @"\Resources\SQL\15-PcbOtherChips.sql";
            using (TextWriter tw = new StreamWriter(pcbOtherChipSqlPath))
            {
                foreach (string s in pcbOtherChipSql)
                {
                    tw.WriteLine(s);
                }
            }
            regionTimer.Stop();

            Console.WriteLine($"Writing SQL files complete - {regionTimer.Elapsed}");
            #endregion

            overallTimer.Stop();
            Console.WriteLine($"All operaions complete - {overallTimer.Elapsed}");
        }
    }
}
