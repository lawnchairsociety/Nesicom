using System;
using Autofac;
using CartDB.API.Configuration;
using CartDB.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace CartDB.API.IoC
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Settings
            var dbConfig = ConfigurationHelper.DatabaseConfig;
            var connString = dbConfig.ConnectionString;

            if (string.IsNullOrEmpty(connString))
            {
                throw new InvalidOperationException("Connection String cannot be empty");
            }

            // Registrations
            builder.Register(context =>
            {
                var options = new DbContextOptionsBuilder<NesicomContext>();
                options.UseSqlServer(connString);

                return new NesicomContext(options.Options);
            })
                .As<NesicomContext>()
                .InstancePerLifetimeScope();
        }
    }
}
