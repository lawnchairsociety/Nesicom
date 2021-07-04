using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CartDB.API.Configuration
{
    public class ConfigurationHelper
    {
        public static readonly IConfiguration Configuration;

        static ConfigurationHelper()
        {
            var env = Environment.GetEnvironmentVariable("CartDBAPIEnvironment");
            if (string.IsNullOrEmpty(env))
            {
                env = "Local";
            }

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public static SerilogConfiguration SerilogConfig
        {
            get
            {
                var serilogConfig = new SerilogConfiguration();
                Configuration.GetSection("Serilog").Bind(serilogConfig);

                return serilogConfig;
            }
        }

        public static DatabaseConfiguration DatabaseConfig
        {
            get
            {
                var databaseConfig = new DatabaseConfiguration();
                Configuration.GetSection("Database").Bind(databaseConfig);

                return databaseConfig;
            }
        }
    }
}
