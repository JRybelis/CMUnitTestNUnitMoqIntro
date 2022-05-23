using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace AutoMockerExampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddLogging(builder => builder.AddConsole())
                .AddSingleton<IFooService, FooService>().AddSingleton<IBarService, BarService>().BuildServiceProvicer();

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogInformation("Starting application");

            var bar = serviceProvider.GetService<IBarService>();
            bar.DoBarThing();

            logger.LogDebug("All done!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}