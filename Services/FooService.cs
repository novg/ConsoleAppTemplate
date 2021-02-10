using System.Threading;
using ConsoleAppTemplate.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleAppTemplate.Services
{
    public class FooService : IFooService
    {
        private readonly ILogger<FooService> _logger;
        private readonly IConfiguration _configuration;

        public FooService(ILogger<FooService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void DoThing(int number)
        {
            string host = _configuration["SettingsData:host"];
            _logger.LogInformation($"Doing the thing {number} for host: {host}");
            Thread.Sleep(10);
        }
    }
}