using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TemplateApi01
{
    /// <summary>
    /// Standard entry point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Startup method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            if (!string.IsNullOrWhiteSpace((environment)) && environment == "Development")
            {
                config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.development.json", optional: true)
                    .Build();
            }

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            try
            {
                Log.Information("TemplateApi01 starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TemplateApi01 failed");
            }
            finally
            {
                Log.Information("TemplateApi01 shutting down");
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
