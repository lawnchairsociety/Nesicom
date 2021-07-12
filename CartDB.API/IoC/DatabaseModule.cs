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
                var options = new DbContextOptionsBuilder<NesicomPostgreContext>();
                if (dbConfig.DatabaseType == "SqlServer")
                {
                    options.UseSqlServer(connString);
                }
                else
                {
                    options.UseNpgsql(connString);
                }

                return new NesicomPostgreContext(options.Options);
            })
                .As<NesicomPostgreContext>()
                .InstancePerLifetimeScope();
        }
    }
}
