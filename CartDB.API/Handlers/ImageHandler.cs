using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using CartDB.API.Mappers;
using CartDB.API.Models;
using CartDB.Database.Data;
using Serilog;

namespace CartDB.API.Handlers
{
    public class ImageHandler : IImageHandler
    {
        private static readonly ILogger Logger = Log.ForContext<ImageHandler>();
        private readonly NesicomContext _context;
        private readonly ImageModelToDtoMapper _imageMapper;
        private readonly BlobContainerClient _client;

        public ImageHandler(NesicomContext context, ImageModelToDtoMapper imageMapper, BlobContainerClient client)
        {
            this._context = context;
            this._imageMapper = imageMapper;
            this._client = client;
        }

        public async Task<List<ImageDto>> GetImageUrlByIdAsync(Guid id)
        {
            var images = this._context.Images
                            .Where(i => i.ImageId == id).ToList();

            var result = this._imageMapper.MapDto(images).ToList();

            return result;
        }
    }
}
