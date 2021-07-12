using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using CartDB.Database.Data;

namespace CartDB.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            using NesicomSqlServerContext context = new NesicomSqlServerContext();

            var manufacturerImagePath = Directory.GetCurrentDirectory() + @"\Resources\images\manufacturers\";
            var regionImagePath = Directory.GetCurrentDirectory() + @"\Resources\images\regions\";
            var peripheralsImagePath = Directory.GetCurrentDirectory() + @"\Resources\images\peripherals\";
            var pcbsImagePath = Directory.GetCurrentDirectory() + @"\Resources\images\pcb\";
            var cartsImagePath = Directory.GetCurrentDirectory() + @"\Resources\images\cartridges\";

            // if directories dont exist, create them
            Directory.CreateDirectory(manufacturerImagePath);
            Directory.CreateDirectory(regionImagePath);
            Directory.CreateDirectory(peripheralsImagePath);
            Directory.CreateDirectory(pcbsImagePath);
            Directory.CreateDirectory(cartsImagePath);

            Stopwatch regionTimer = new Stopwatch();
            Stopwatch overallTimer = new Stopwatch();
            overallTimer.Start();

            #region Download Manufacturer Images
            regionTimer.Start();

            var manufacturerImages = context.Manufacturers.Select(o => o.Image).Distinct().ToList();
            foreach (var image in manufacturerImages)
            {
                if (string.IsNullOrWhiteSpace(image) || !image.Contains("http://"))
                {
                    continue;
                }

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(image, manufacturerImagePath + image.Split('/')[image.Split('/').Length - 1]);
                        UpdateManufacturerImage(image, image.Split('/')[image.Split('/').Length - 1], context);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error Downloading {image} - {e.Message}");
                    }
                }
            }

            regionTimer.Stop();
            Console.WriteLine($"Download of manufacturer images complete - {regionTimer.Elapsed}");
            #endregion

            #region Download Region Images
            regionTimer.Reset();
            regionTimer.Start();

            var regionImages = context.Regions.Select(o => o.Image).Distinct().ToList();
            foreach (var image in regionImages)
            {
                if (string.IsNullOrWhiteSpace(image) || !image.Contains("http://"))
                {
                    continue;
                }

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(image, regionImagePath + image.Split('/')[image.Split('/').Length - 1]);
                        UpdateRegionImage(image, image.Split('/')[image.Split('/').Length - 1], context);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error Downloading {image} - {e.Message}");
                    }
                }
            }

            regionTimer.Stop();
            Console.WriteLine($"Download of region images complete - {regionTimer.Elapsed}");
            #endregion

            #region Download Peripherals Images
            regionTimer.Reset();
            regionTimer.Start();

            var peripheralsImages = context.Games.Select(o => o.PeripheralsImage).Distinct().ToList();
            foreach (var image in peripheralsImages)
            {
                if (string.IsNullOrWhiteSpace(image) || !image.Contains("http://"))
                {
                    continue;
                }

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(image, peripheralsImagePath + image.Split('/')[image.Split('/').Length - 1]);
                        UpdatePeripheralsImage(image, image.Split('/')[image.Split('/').Length - 1], context);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error Downloading {image} - {e.Message}");
                    }
                }
            }

            regionTimer.Stop();
            Console.WriteLine($"Download of peripherals images complete - {regionTimer.Elapsed}");
            #endregion

            #region Download PCB Images
            regionTimer.Reset();
            regionTimer.Start();

            var pcbImages = context.Images.Where(o=>o.PcbId != null).Select(o => o.Filename).Distinct().ToList();
            foreach (var image in pcbImages)
            {
                if (string.IsNullOrWhiteSpace(image) || !image.Contains("http://"))
                {
                    continue;
                }

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        var pcbFileId = image.Replace("http://bootgod.dyndns.org:7777/imagegen.php?ImageID=", "").Replace("&width=400", "");
                        var newFileName = pcbFileId + ".png";


                        Stream stream = client.OpenRead(image);
                        Bitmap bitmap = new Bitmap(stream);
                        if (bitmap != null)
                        {
                            bitmap.Save(pcbsImagePath + newFileName, ImageFormat.Png);
                        }

                        stream.Flush();
                        stream.Close();

                        UpdateImage(image, newFileName, context);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error Downloading {image} - {e.Message}");
                    }
                }
            }

            regionTimer.Stop();
            Console.WriteLine($"Download of pcb images complete - {regionTimer.Elapsed}");
            #endregion

            #region Download Cartridge Images
            regionTimer.Reset();
            regionTimer.Start();

            var cartImages = context.Images.Where(o => o.CartridgeId != null).Select(o => o.Filename).Distinct().ToList();
            foreach (var image in cartImages)
            {
                if (string.IsNullOrWhiteSpace(image) || !image.Contains("http://"))
                {
                    continue;
                }

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        var cartFileId = image.Replace("http://bootgod.dyndns.org:7777/imagegen.php?width=10000&ImageID=", "");
                        var newFileName = cartFileId + ".png";


                        Stream stream = client.OpenRead(image);
                        Bitmap bitmap = new Bitmap(stream);
                        if (bitmap != null)
                        {
                            bitmap.Save(cartsImagePath + newFileName, ImageFormat.Png);
                        }

                        stream.Flush();
                        stream.Close();

                        UpdateImage(image, newFileName, context);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error Downloading {image} - {e.Message}");
                    }
                }
            }

            regionTimer.Stop();
            Console.WriteLine($"Download of cartridge images complete - {regionTimer.Elapsed}");
            #endregion

            overallTimer.Stop();
            Console.WriteLine($"All downloads and database updates complete - {overallTimer.Elapsed}");
        }

        /// <summary>
        /// Updates the Manufacturer images with new filenames
        /// </summary>
        /// <param name="oldFilename">the old filename we are replacing</param>
        /// <param name="newFilename">the new filename we have saved images to</param>
        /// <param name="context">the database context</param>
        private static void UpdateManufacturerImage(string oldFilename, string newFilename, NesicomSqlServerContext context)
        {
            var updateManufacturers = context.Manufacturers
                .Where(o => o.Image == oldFilename).ToList();

            foreach(var manufacturer in updateManufacturers)
            {
                manufacturer.Image = newFilename;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the Region images with new filenames
        /// </summary>
        /// <param name="oldFilename">the old filename we are replacing</param>
        /// <param name="newFilename">the new filename we have saved images to</param>
        /// <param name="context">the database context</param>
        private static void UpdateRegionImage(string oldFilename, string newFilename, NesicomSqlServerContext context)
        {
            var updateRegions = context.Regions
                .Where(o => o.Image == oldFilename).ToList();

            foreach (var region in updateRegions)
            {
                region.Image = newFilename;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the peripherals images with new filenames
        /// </summary>
        /// <param name="oldFilename">the old filename we are replacing</param>
        /// <param name="newFilename">the new filename we have saved images to</param>
        /// <param name="context">the database context</param>
        private static void UpdatePeripheralsImage(string oldFilename, string newFilename, NesicomSqlServerContext context)
        {
            var updatePeripherals = context.Games
                .Where(o => o.PeripheralsImage == oldFilename).ToList();

            foreach (var peripheral in updatePeripherals)
            {
                peripheral.PeripheralsImage = newFilename;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the main images with new filenames
        /// </summary>
        /// <param name="oldFilename">the old filename we are replacing</param>
        /// <param name="newFilename">the new filename we have saved images to</param>
        /// <param name="context">the database context</param>
        private static void UpdateImage(string oldFilename, string newFilename, NesicomSqlServerContext context)
        {
            var updateImages = context.Images
                .Where(o => o.Filename == oldFilename).ToList();

            foreach (var image in updateImages)
            {
                image.Filename = newFilename;

                context.SaveChanges();
            }
        }
    }
}
