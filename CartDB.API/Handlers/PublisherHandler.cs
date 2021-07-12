using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartDB.API.Mappers;
using CartDB.API.Models;
using CartDB.Database.Data;
using Serilog;

namespace CartDB.API.Handlers
{
    public class PublisherHandler : IPublisherHandler
    {
        private static readonly ILogger Logger = Log.ForContext<PublisherHandler>();
        private readonly NesicomPostgreContext _context;
        private readonly PublisherModelToDtoMapper _publisherMapper;

        public PublisherHandler(NesicomPostgreContext context, PublisherModelToDtoMapper publisherMapper)
        {
            this._context = context;
            this._publisherMapper = publisherMapper;
        }

        public async Task<List<PublisherDto>> GetAllPublishersAsync()
        {
            var publishers = this._context.Publishers.ToList();

            var result = this._publisherMapper.MapDto(publishers).ToList();

            return result;
        }

        public async Task<PublisherDto> GetPublisherByIdAsync(Guid id)
        {
            var publisher = this._context.Publishers
                                .Where(p => p.PublisherId == id)
                                .FirstOrDefault();

            var result = this._publisherMapper.MapDto(publisher);

            return result;
        }

        public async Task<PublisherDto> GetPublisherByNameAsync(string name)
        {
            var publisher = this._context.Publishers
                                .Where(p => p.PublisherName == name)
                                .FirstOrDefault();

            var result = this._publisherMapper.MapDto(publisher);

            return result;
        }
    }
}
