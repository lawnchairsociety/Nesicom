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
                var nesContext = context.Resolve<NesicomContext>();
                var cartridgeDtoMapper = new CartridgeModelToDtoMapper();

                return new CartridgeHandler(nesContext, cartridgeDtoMapper);
            })
                .As<ICartridgeHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomContext>();
                var gameDtoMapper = new GameModelToDtoMapper();

                return new GameHandler(nesContext, gameDtoMapper);
            })
                .As<IGameHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomContext>();
                var manufacturerDtoMapper = new ManufacturerModelToDtoMapper();

                return new ManufacturerHandler(nesContext, manufacturerDtoMapper);
            })
                .As<IManufacturerHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomContext>();
                var pcbDtoMapper = new PcbModelToDtoMapper();

                return new PcbHandler(nesContext, pcbDtoMapper);
            })
                .As<IPcbHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomContext>();
                var regionDtoMapper = new RegionModelToDtoMapper();

                return new RegionHandler(nesContext, regionDtoMapper);
            })
                .As<IRegionHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomContext>();
                var developerDtoMapper = new DeveloperModelToDtoMapper();

                return new DeveloperHandler(nesContext, developerDtoMapper);
            })
                .As<IDeveloperHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomContext>();
                var publisherDtoMapper = new PublisherModelToDtoMapper();

                return new PublisherHandler(nesContext, publisherDtoMapper);
            })
                .As<IPublisherHandler>()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var nesContext = context.Resolve<NesicomContext>();
                
                return new StatsHandler(nesContext);
            })
                .As<IStatsHandler>()
                .InstancePerLifetimeScope();
        }
    }
}
