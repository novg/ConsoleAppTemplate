using ConsoleAppTemplate.Contracts;
using ConsoleAppTemplate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleAppTemplate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            ConfigureLogger(host.Services.GetService<IConfiguration>());

            var logger = host.Services.GetService<ILogger<Program>>();

            logger.LogInformation("Starting app");


            var bar = host.Services.GetService<IBarService>();
            bar.DoSomeRealWork();

            logger.LogInformation("All is done!");

            //await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureServices(services =>
                services
                    .AddSingleton<IFooService, FooService>()
                    .AddSingleton<IBarService, BarService>()
            );

        private static void ConfigureLogger(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger()
                ;
        }
    }
}