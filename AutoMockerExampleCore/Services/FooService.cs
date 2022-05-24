using AutoMockerExampleCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoMockerExampleCore.Services
{
    public class FooService : IFooService
    {
        private readonly ILogger<FooService> _logger;

        public FooService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooService>();
        }

        public void DoFooThing(int number)
        {
            _logger.LogInformation($"Doing the foo work with number: {number}");
        }
    }
}