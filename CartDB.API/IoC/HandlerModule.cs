using Autofac;
using CartDB.API.Handlers;
using CartDB.API.Mappers;
using CartDB.Database.Data;

namespace CartDB.API.IoC
{
    public class HandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Registrations
            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var cartridgeDtoMapper = new CartridgeModelToDtoMapper();

                return new CartridgeHandler(nesContext, cartridgeDtoMapper);
            })
                .As<ICartridgeHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var gameDtoMapper = new GameModelToDtoMapper();

                return new GameHandler(nesContext, gameDtoMapper);
            })
                .As<IGameHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var manufacturerDtoMapper = new ManufacturerModelToDtoMapper();

                return new ManufacturerHandler(nesContext, manufacturerDtoMapper);
            })
                .As<IManufacturerHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var pcbDtoMapper = new PcbModelToDtoMapper();

                return new PcbHandler(nesContext, pcbDtoMapper);
            })
                .As<IPcbHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var regionDtoMapper = new RegionModelToDtoMapper();

                return new RegionHandler(nesContext, regionDtoMapper);
            })
                .As<IRegionHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var developerDtoMapper = new DeveloperModelToDtoMapper();

                return new DeveloperHandler(nesContext, developerDtoMapper);
            })
                .As<IDeveloperHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var publisherDtoMapper = new PublisherModelToDtoMapper();

                return new PublisherHandler(nesContext, publisherDtoMapper);
            })
                .As<IPublisherHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                
                return new StatsHandler(nesContext);
            })
                .As<IStatsHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomPostgreContext>();
                var cartridgeChipDtoMapper = new CartridgeChipModelToDtoMapper();
                var cartridgeDtoMapper = new CartridgeModelToDtoMapper();
                var developerDtoMapper = new DeveloperModelToDtoMapper();
                var gameDtoMapper = new GameModelToDtoMapper();
                var manufacturerDtoMapper = new ManufacturerModelToDtoMapper();
                var pcbDtoMapper = new PcbModelToDtoMapper();
                var publisherDtoMapper = new PublisherModelToDtoMapper();
                var regionDtoMapper = new RegionModelToDtoMapper();

                return new SearchHandler(nesContext, cartridgeChipDtoMapper, cartridgeDtoMapper, developerDtoMapper, gameDtoMapper,
                            manufacturerDtoMapper, pcbDtoMapper, publisherDtoMapper, regionDtoMapper);
            })
                .As<ISearchHandler>()
                .InstancePerLifetimeScope();
        }
    }
}
