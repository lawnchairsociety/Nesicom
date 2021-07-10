using Autofac.Extensions.DependencyInjection;
using CartDB.API.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CartDB.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = BuildLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static ILogger BuildLogger()
        {
            var serilogConfig = ConfigurationHelper.SerilogConfig;
            var loggerConfig = new LoggerConfiguration()
                .Enrich.WithProperty("Program", "CartDB API");
            var serilogEnv = string.IsNullOrWhiteSpace(serilogConfig.Environment)
                ? "Development"
                : serilogConfig.Environment;

            loggerConfig.Enrich.WithProperty("Environment", serilogEnv);
            if (serilogEnv == "Development")
            {
                loggerConfig.MinimumLevel.Verbose();
                loggerConfig.WriteTo.Console(outputTemplate: serilogConfig.ConsoleOutputTemplate);
            }
            else
            {
                loggerConfig.MinimumLevel.Information();
                loggerConfig.WriteTo.Console(outputTemplate: serilogConfig.ConsoleOutputTemplate);
            }

            return loggerConfig.CreateLogger();
        }
    }
}
